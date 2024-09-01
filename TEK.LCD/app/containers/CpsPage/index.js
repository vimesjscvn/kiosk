/* eslint-disable spaced-comment */
/* eslint-disable no-continue */
/* eslint-disable no-restricted-syntax */
/* eslint-disable no-useless-return */
/* eslint-disable arrow-body-style */
/* eslint-disable react/prop-types */
/* eslint-disable react/no-array-index-key */
/* eslint-disable prettier/prettier */
/* eslint-disable import/order */
/* eslint-disable no-unused-vars */
/* eslint-disable func-names */
/* eslint-disable consistent-return */
/* eslint-disable global-require */
/* eslint-disable jsx-a11y/alt-text */
import React, { useEffect, memo, useState, useRef, useMemo } from 'react';
import * as Global from 'containers/App/selectors';
import * as appActions from 'containers/App/actions';
import * as _ from 'lodash';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer } from 'utils/injectReducer';
import { useInjectSaga } from 'utils/injectSaga';
import { AppConfig } from '../../public/appConfig';
import { AppContainer } from 'components/AppContainer';
import { PatientHelper, comparer } from 'containers/App/helper';
import PropTypes from 'prop-types';
import appReducer, { key } from 'containers/App/reducer';
import appSaga from 'containers/App/saga';
import LoadingIndicator from 'components/LoadingIndicator';
import WrapLogo from 'components/WrapLogo';
import styled, { keyframes } from 'styled-components';
import './CpsPage.css';
import ReactAudioPlayer from 'react-audio-player';


const CPSTitle = styled.div`
  justify-content: center;
  align-items: center;
  display: flex;
  font-size: 2.5rem;
  font-weight: bold;
  border-bottom: 1px solid black;
  min-height: 90px;
  padding: 10px 0;
  @media (max-width: 1400px) {
    font-size: 1.5rem;
    min-height: initial;
  }
  & > p {
    margin: 0;
    padding: 0;
    line-height: 1.5;
    @media (max-width: 1400px) {
      line-height: initial;
    }
  }
`;

const CPSList = styled.div`
  width: 100%;
  display: flex;
  flex-wrap: wrap;
  flex: 1;
  & > div {
    border-bottom: 1px solid #000;
  }
  & > div:nth-child(odd) {
    border-right: 1px solid #000;
    border-left: 1px solid #000;
  }
  & > div:nth-child(even) {
    border-right: 1px solid #000;
  }
`;

const CPS = styled.div`
  background: ${props => PatientHelper.setPatientColor(props.cps)};
  width: 50%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
`;

const TitleHeader = styled.div`
  width: 100%;
  display: flex;
  flex-direction: row;
  height: 20%;
`;

const TitleMiddle = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  width: 100%;
  height: 10%;
`;

const TitleBody = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  width: 100%;
  height: 70%;
  margin-top: 10px;
`;

const TitleSubBody = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  width: 100%;
`;

const CPSContainer = styled.div`
  height: 100%;
  width: 100%;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
`;

const CPSContent = styled.div`
  display: flex;
  align-items: center;
`;

const TextNote = styled.p`
  font-weight: bold;
  text-align: left;
  font-size: 1.2rem;
  margin: 0;
  padding: 0 0 10px 0;
`;

const CPSNumber = styled.p`
  flex: 1;
  text-align: center;
  font-weight: bold;
  color: white;
  margin: 0;
  @media (min-width: 768px) {
    font-size: 8em;
  }
  @media (min-width: 1360px) {
    font-size: 10em;
  }
`;

const CPSSubTitle = styled.p`
  margin: 10px;
  flex: 1;
  text-align: center;
  font-weight: bold;
  color: white;
  @media (min-width: 768px) {
    font-size: 3rem;
  }
  @media (min-width: 1360px) {
    font-size: 3.5rem;
  }
`;

CpsPage.propTypes = {
  loading: PropTypes.bool,
  listCPS: PropTypes.array,
  device: PropTypes.any,
  system: PropTypes.object,
  getListCPS: PropTypes.func,
};

export function CpsPage({ listCPS, device, loading, ...props }) {
  useInjectReducer({ key, reducer: appReducer });
  useInjectSaga({ key, saga: appSaga });
  const [cpsChange, setCPSChange] = useState([]);
  const intervalRef = useRef(null);
  const listCPSRef = useRef(null);

  useEffect(() => {
    function compareCPS() {
      if (listCPSRef.current && listCPS.length) {
        const changed = listCPSRef.current.filter(comparer(listCPS));
        setCPSChange(changed);
      }
      listCPSRef.current = listCPS;
    }
    compareCPS();
  }, [loading]);

  useEffect(() => {
    props.getListCPS(device);
    intervalRef.current = setInterval(() => {
      props.getListCPS(device);
    }, AppConfig.ROOM_TIMER);
    return () => {
      clearInterval(intervalRef.current);
    };
  }, [device]);

  const redirect = () => {
    props.history.push('/');
    props.changeDeviceType(0);
  };

  // Audio
  const [audio, setAudio] = useState('');
  const audios = useMemo(
    () =>
      (listCPS || [])
        .filter(c => !_.isEmpty(c.url_audio))
        .map(c => ({
          from: c.from,
          url_audio: c.url_audio,
        }))
        .sort((a, b) => a.from - b.from),
    [listCPS],
  );

  const calledFromList = useRef(null);
  useEffect(() => {
    if (_.isEmpty(listCPS)) return;
    if (calledFromList.current !== null) return;
    calledFromList.current = audios.map(a => a.from);
  }, [listCPS, audios]);

  useEffect(() => {
    if (calledFromList.current === null) return;
    if (audio !== '' /* || audio2 !== ''*/) return;
    for (const c of audios) {
      if (calledFromList.current.includes(c.from)) continue;
      calledFromList.current.push(c.from);
      setAudio(`${AppConfig.END_POINT}/${c.url_audio}`);
      break;
    }
  }, [audios]);

  useEffect(() => {
    // localStorage.removeItem('_type_start');
  }, []);

  if (_.isEmpty(listCPS) || !listCPS.length) return <LoadingIndicator />;

  const render = () => {
    const formatCPS = listCPS.map(_cps => {
      if (cpsChange.length) {
        const cpsChanged = cpsChange.find(cpsCurrent => {
          return cpsCurrent.table.code === _cps.table.code;
        });
        if (cpsChanged)
          return {
            ..._cps,
            isChange: true,
          };
      }
      return _cps;
    });
    return formatCPS.map((cps, idx) => (
      cps.table.is_active === true ? (
        <CPS key={idx} cps={cps} className={cps.isChange && 'blink_me'}>
          <TitleHeader>
            <CPSSubTitle listCPS={listCPS}>QUẦY SỐ {cps.table.store}</CPSSubTitle>
          </TitleHeader>
          <TitleBody>
            <CPSNumber listCPS={listCPS}>{(cps.to > 0 && cps.to) || '0'}</CPSNumber>
          </TitleBody>
        </CPS>) : (<CPS key={idx} cps={cps} className={cps.isChange && 'blink_me'}>
        </CPS>)
    ));
  };

  return (
    <>
      <AppContainer style={{ display: 'flex', flexDirection: 'column' }}>
        <CPSContainer>
          <CPSTitle onClick={() => redirect()}>
            <p>BẢNG ĐIỀU KHIỂN TRUNG TÂM</p>
          </CPSTitle>
          <CPSList>{render()}</CPSList>
        </CPSContainer>
      </AppContainer>
      {/* {!_.isEmpty(audio) && ( */}
      {/* <ReactAudioPlayer
        src={audio}
        autoPlay
        onEnded={() => {
          setAudio('');
          //setAudio2(audio);
        }}
      /> */}
      {/* )} */}
      {/*!_.isEmpty(audio2) && <ReactAudioPlayer
        src={audio2}
        autoPlay
        onEnded={() => {
          setAudio2('');
        }}
      /> */}
    </>
  );
}

export function mapDispatchToProps(dispatch) {
  return {
    getListCPS: (departmentCode, limit) =>
      dispatch(appActions.getListCPS(departmentCode, limit)),
    changeDeviceType: () => dispatch(appActions.changeDeviceType(0)),
  };
}
const mapStateToProps = createStructuredSelector({
  listCPS: Global.selectListCPS(),
  device: Global.selectDeviceSetting(),
  system: Global.selectSystemSetting(),
  loading: Global.selectLoading(),
});

const withConnect = connect(
  mapStateToProps,
  mapDispatchToProps,
);

export default compose(
  withConnect,
  memo,
)(CpsPage);

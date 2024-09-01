/* eslint-disable react/no-unused-prop-types */
/* eslint-disable import/no-duplicates */
/* eslint-disable react/jsx-curly-brace-presence */
/* eslint-disable no-empty */
/* eslint-disable no-unused-vars */
/* eslint-disable import/order */
/* eslint-disable jsx-a11y/alt-text */
/* eslint-disable no-restricted-globals */
/* eslint-disable jsx-a11y/click-events-have-key-events */
/* eslint-disable jsx-a11y/no-static-element-interactions */
import React, { useEffect, memo, useState } from 'react';
import * as Global from 'containers/App/selectors';
import * as appActions from 'containers/App/actions';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer } from 'utils/injectReducer';
import { useInjectSaga } from 'utils/injectSaga';
import _, { isEmpty } from 'lodash';
import { AppConfig } from '../../public/appConfig';
import { AppContainer } from 'components/AppContainer';
import { PatientHelper } from 'containers/App/helper';
import { Main } from 'components/Main';
import DateTimeWeather from 'components/DateTimeWeather';
import propTypes from 'prop-types';
import LoadingIndicator from 'components/LoadingIndicator';
import appReducer, { key } from 'containers/App/reducer';
import appSaga from 'containers/App/saga';
import ReactPlayer from 'react-player';
import styled, { keyframes } from 'styled-components';
import ReactAudioPlayer from 'react-audio-player';
import './TNB.css';

const TNBContent = styled.div`
  flex: 1;
  width: 100%;
  height: 100%;
  display: flex;
  border: 1px solid black;
`;

const Text = styled.div`
  color: #34458b;
  font-weight: 500;
  text-align: center;
`;

function renderNumberSize(numberTo, numberFrom) {
  if (numberTo >= 1000 && numberFrom >= 1000) return 'calc(7em + 5vmax)';
  if (numberTo >= 100 && numberFrom >= 1000) return 'calc(7em + 5vmax)';
  if (numberTo >= 100 && numberFrom >= 100) return 'calc(8em + 5vmax)';
  if (numberTo >= 10 && numberFrom >= 100) return 'calc(9em + 6vmax)';
  return 'calc(13em + 7vmax)';
}

const TextNumber = styled.p`
  font-size: ${props => renderNumberSize(props.numberTo, props.numberFrom)};
  font-weight: bold;
  margin: 0;
`;

const TextFrom = styled.p`
  font-size: calc(3em);
  margin: 0;
  font-weight: bold;
`;

const TextLine = styled.p`
  color: #34458b;
  font-weight: 500;
  margin-right: 30px;
  margin-left: 30px;
  font-size: ${props => renderNumberSize(props.numberTo, props.numberFrom)};
  font-weight: bold;
  text-align: center;
`;

TNBPage.propTypes = {
  patient: propTypes.object,
  temperature: propTypes.number,
  device: propTypes.any,
  history: propTypes.any,
  getTNB: propTypes.func,
  changeDeviceType: propTypes.func,
};

export function TNBPage({ patient, device, temperature, ...props }) {
  const [audio, setAudio] = useState('');
  useInjectReducer({ key, reducer: appReducer });
  useInjectSaga({ key, saga: appSaga });

  useEffect(() => {
    if (device.type === 1) {
      setAudio(`${AppConfig.END_POINT}/${patient.url_audio}`);
    }
    return () => {
      setAudio('');
    };
  }, [_.get(patient, 'from'), _.get(patient, 'to')]);

  useEffect(() => {
    function callTNB(code) {
      if (code === '' || !code) return;
      props.getTNB(code, 5);
    }
    callTNB(device.code);
    const interval = setInterval(
      callTNB.bind(callTNB, device.code),
      AppConfig.TNB_TIMER,
    );
    return () => {
      clearInterval(interval);
    };
  }, [device]);

  const canRender = data => {
    if (isEmpty(data) || (data.from < 0 && data.to < 0)) return false;
    return true;
  };

  const redirect = () => {
    props.history.push('/');
    props.changeDeviceType(0);
  };

  if (isEmpty(patient) || isEmpty(device)) return <LoadingIndicator />;

  const renderSTT = () => {
    if (!canRender(patient)) {
      return (
        <div className="player-wrapper">
          <ReactPlayer
            className="react-player"
            loop
            playing
            url={AppConfig.URL_VIDEO}
            width="100%"
            height="100%"
          />
        </div>
      );
    }
    return (
      <div className="item" style={{ flex: '3.4' }}>
        <div
          className="item3"
          style={{
            background: PatientHelper.setPatientColor(patient),
          }}
        >
          SỐ THỨ TỰ TIẾP ĐÓN
        </div>
        {patient.from !== patient.to ? (
          <div className="item4">
            <Text>
              <TextFrom>TỪ</TextFrom>
              <TextNumber numberTo={patient.to} numberFrom={patient.from}>
                {patient.from}
              </TextNumber>
            </Text>
            <TextLine>→</TextLine>
            <Text>
              <TextFrom>ĐẾN</TextFrom>
              <TextNumber numberTo={patient.to} numberFrom={patient.from}>
                {patient.to}
              </TextNumber>
            </Text>
          </div>
        ) : (
          <div className="item4">
            <Text>
              <TextFrom>BỆNH NHÂN ĐANG PHỤC VỤ</TextFrom>
              <TextNumber numberTo={patient.to} numberFrom={patient.from}>
                {patient.from}
              </TextNumber>
            </Text>
          </div>
        )}
        {audio !== '' && (
          <ReactAudioPlayer src={audio} autoPlay onEnded={() => setAudio('')} />
        )}
      </div>
    );
  };

  return (
    <AppContainer>
      <Main>
        <TNBContent>
          <div className="item1">
            <div
              className="item2"
              style={{
                background:
                  canRender(patient) && PatientHelper.setPatientColor(patient),
                borderBottomWidth: '2px',
                cursor: 'pointer',
              }}
              onClick={redirect}
            >
              <h1 className="tbn__textTable">BÀN SỐ</h1>
              <h1 className="tbn__textNumberTable">
                {PatientHelper.formatRoomTitle(device.code)}
              </h1>
            </div>
            <DateTimeWeather />
          </div>
          {renderSTT()}
        </TNBContent>
      </Main>
    </AppContainer>
  );
}

const mapStateToProps = createStructuredSelector({
  patient: Global.selectTNB(),
  device: Global.selectDeviceSetting(),
  temperature: Global.selectTemperature(),
});

export function mapDispatchToProps(dispatch) {
  return {
    getTNB: (tableCode, limit) => dispatch(appActions.getTNB(tableCode, limit)),
    changeDeviceType: () => dispatch(appActions.changeDeviceType(0)),
  };
}

const withConnect = connect(
  mapStateToProps,
  mapDispatchToProps,
);

export default compose(
  withConnect,
  memo,
)(TNBPage);

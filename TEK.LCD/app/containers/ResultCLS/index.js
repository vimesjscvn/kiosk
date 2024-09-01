/* eslint-disable consistent-return */
/* eslint-disable react/no-array-index-key */
/* eslint-disable react/prop-types */
/* eslint-disable react/no-unused-prop-types */
/* eslint-disable import/order */
/* eslint-disable arrow-body-style */
/* eslint-disable no-unused-vars */
/* eslint-disable react/jsx-curly-brace-presence */
/* eslint-disable react/jsx-boolean-value */
/* eslint-disable no-restricted-globals */
/* eslint-disable jsx-a11y/click-events-have-key-events */
/* eslint-disable jsx-a11y/no-static-element-interactions */
/* eslint-disable global-require */
/* eslint-disable jsx-a11y/alt-text */
/* eslint-disable jsx-a11y/media-has-caption */
import React, { useEffect, memo, useState, useRef } from 'react';
import * as Global from 'containers/App/selectors';
import * as Util from '../../utils/Function';
import * as _ from 'lodash';
import * as appActions from 'containers/App/actions';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer } from 'utils/injectReducer';
import { useInjectSaga } from 'utils/injectSaga';
import { AppConfig } from '../../public/appConfig';
import { AppContainer } from 'components/AppContainer';
import { ListCLS } from './ListCLS';
import { DataManagement } from '../../mock/PatienData';
import { ModalCLS } from './ModalCls';
import Slider from 'react-slick';
import appReducer, { key } from 'containers/App/reducer';
import appSaga from 'containers/App/saga';
import propTypes from 'prop-types';
import styled from 'styled-components';
import LoadingIndicator from '../../components/LoadingIndicator';
import logo from '../../images/logo-wrap.jpg';
import './ResultCLS.css';

const CLSWrap = styled.div`
  display: flex;
  flex-wrap: wrap;
  height: 100%;
`;

const Header = styled.header`
  height: 180px;
`;

const Main = styled.main`
  flex: 1;
  overflow: hidden;
  height: 100%;
`;

const Time = styled.div`
  cursor: pointer;
  text-align: center;
  width: 8.5vw;
  font-weight: bold;
  @media (min-width: 800px) {
    font-size: 2rem;
  }
`;

const Location = styled.div`
  font-weight: 700;
  font-size: calc(1em + 1vmin);
  margin: 0;
  text-align: center;
  width: 10vw;
  @media (max-width: 1600px) {
    font-size: 1.3rem;
  }
`;

const Temp = styled.p`
  font-weight: bold;
  line-height: 0;
  font-size: 2rem;
  @media (max-width: 1600px) {
    font-size: 1.3rem;
  }
`;

ResultCLS.propTypes = {
  loading: propTypes.bool,
  clsList: propTypes.array,
  history: propTypes.any,
  system: propTypes.object,
  temperature: propTypes.any,
  getResultCLS: propTypes.func,
};

export function ResultCLS({ temperature, getResultCLS, clsList, ...props }) {
  const mockData = DataManagement.generateCLSResult(58);
  useInjectReducer({ key, reducer: appReducer });
  useInjectSaga({ key, saga: appSaga });
  const [currentTime, setCurrentTime] = useState(null);
  const clsRef = useRef(null);
  const [openModal, setOpenModal] = useState(false);

  useEffect(() => {
    getResultCLS();
    const timer = setInterval(() => {
      setCurrentTime(Util.getCurrentTime());
    }, 1000);
    clsRef.current = setInterval(getResultCLS, AppConfig.CLS_TIMER);
    return () => {
      clearInterval(timer);
      clearInterval(clsRef.current);
    };
  }, []);

  const redirect = () => {
    props.history.push('/');
    props.changeDeviceType(0);
  };

  const render = () => {
    if (clsList && clsList.length > AppConfig.CLS_ROW) {
      return Util.breakdownArray(clsList.sort((a, b) => b.isNew - a.isNew)).map(
        renderEachPage,
      );
    }
    return renderEachPage(clsList.sort((a, b) => b.isNew - a.isNew));
  };

  const renderEachPage = list => {
    return (
      <CLSWrap>
        <ListCLS list={Util.createPlaceHolderList(list)} />
      </CLSWrap>
    );
  };

  return (
    <AppContainer style={{ display: 'flex', flexDirection: 'column' }}>
      <Header>
        <div className="header" style={{ background: '#fff' }}>
          {openModal && (
            <ModalCLS open={true} onClose={() => setOpenModal(false)} />
          )}
          <Time onClick={redirect}>
            {!currentTime ? <LoadingIndicator /> : currentTime}
          </Time>
          <div className="line" />
          <div className="day">
            {_.capitalize(Util.dayName)}, ngày {Util.day} tháng {Util.month} năm{' '}
            {Util.year}
          </div>
          <div className="line" />
          <Location>{AppConfig.CLIENT_LOCATION}</Location>
          <div className="line" />
          <div className="logo-cls">
            <img src={logo} style={{ width: '100%' }} />
          </div>
        </div>
        <p className="result">NGƯỜI BỆNH ĐÃ CÓ KẾT QUẢ</p>
      </Header>
      <Main>
        <Slider {...AppConfig.SLIDER_CONFIG}>{render()}</Slider>
      </Main>
    </AppContainer>
  );
}

const mapStateToProps = createStructuredSelector({
  temperature: Global.selectTemperature(),
  loading: Global.selectLoading(),
  clsList: Global.selectResultCLS(),
  device: Global.selectDeviceSetting(),
  system: Global.selectSystemSetting(),
});

export function mapDispatchToProps(dispatch) {
  return {
    getResultCLS: () => dispatch(appActions.getResultCLS()),
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
)(ResultCLS);

/* eslint-disable prettier/prettier */
/* eslint-disable react/no-unused-prop-types */
/* eslint-disable import/order */
/* eslint-disable no-unused-vars */
import React, { memo, useEffect, useRef } from 'react';
import * as appActions from './actions';
import * as Global from 'containers/App/selectors';
import appReducer, { key } from './reducer';
import appSaga from './saga';
import PropTypes from 'prop-types';
import SettingPage from 'containers/SettingPage/Loadable';
import StartPage from 'containers/StartPage/Loadable';
import CpsPage from 'containers/CpsPage/Loadable';
import BHYTPage from 'containers/BHYTPage/Loadable';
import TNBPage from 'containers/TNBPage/Loadable';
import ResultCLS from 'containers/ResultCLS/Loadable';
import RoomRenew from 'containers/RoomRenew/Loadable';
import RoomCLS from 'containers/RoomCLS/Loadable';
import Endoscopy from 'containers/Endoscopy/Loadable';
import history, { redirectWithTypeStart } from 'utils/history';
import GlobalFonts from 'fonts/fonts';
import { Switch, Route, Router } from 'react-router-dom';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer } from 'utils/injectReducer';
import { useInjectSaga } from 'utils/injectSaga';
import { AppConfig } from '../../public/appConfig';
import { AppWrapper } from 'components/Wrapper';
import { isEmpty } from 'lodash';
import { ROUTING } from 'containers/App/helper';

App.propTypes = {
  systemSetting: PropTypes.object,
  device: PropTypes.any,
  router: PropTypes.object,
  ip: PropTypes.any,
  getSystemSetting: PropTypes.func,
  getIp: PropTypes.func,
  getTemperature: PropTypes.func,
  getDeviceSetting: PropTypes.func,
  getListRoom: PropTypes.func,
  getListTable: PropTypes.func,
  getGroups: PropTypes.func,
};

function App(props) {
  useInjectReducer({ key, reducer: appReducer });
  useInjectSaga({ key, saga: appSaga });
  const settingRef = useRef(null);
  useEffect(() => {
    props.getSystemSetting(AppConfig.CLIENT_KEY);
    props.getDeviceSetting();
    // props.getTemperature();
    props.getListRoom();
    props.getListTable();
    props.getGroups();
    settingRef.current = setInterval(() => {
      props.getSystemSetting(AppConfig.CLIENT_KEY);
    }, AppConfig.SETTING_TIMER);
    return () => clearInterval(settingRef.current);
  }, []);

  useEffect(() => {
    if (!isEmpty(props.device)) {
      redirectWithTypeStart(props.device.type);
    }
  }, [props.device]);

  return (
    <AppWrapper>
      <GlobalFonts />
      <Router history={history}>
        <Switch>
          <Route path={ROUTING.ROOM} component={RoomCLS} />
          <Route path={ROUTING.ROOM_CLS} component={RoomCLS} />
          <Route path={ROUTING.TNB} component={TNBPage} />
          <Route path={ROUTING.CPS} component={CpsPage} />
          <Route path={ROUTING.CLS} component={ResultCLS} />
          <Route path={ROUTING.THUOCBHYT} component={BHYTPage} />
          <Route path={ROUTING.SETTING} component={SettingPage} />
          <Route path={ROUTING.NOISOI} component={Endoscopy} />
          <Route path="**" component={StartPage} />
        </Switch>
      </Router>
    </AppWrapper>
  );
}

export function mapDispatchToProps(dispatch) {
  return {
    getSystemSetting: name => dispatch(appActions.getSystemSetting(name)),
    getIp: () => dispatch(appActions.getIp()),
    // getTemperature: () => dispatch(appActions.getTemperature()),
    getDeviceSetting: ip => dispatch(appActions.getDeviceSetting(ip)),
    getListRoom: () => dispatch(appActions.getListRoom()),
    getListTable: () => dispatch(appActions.getListTable()),
    getGroups: () => dispatch(appActions.getGroups()),
  };
}
const mapStateToProps = createStructuredSelector({
  loading: Global.selectLoading(),
  error: Global.selectError(),
  router: Global.selectRouter(),
  ip: Global.selectIp(),
  device: Global.selectDeviceSetting(),
});

const withConnect = connect(
  mapStateToProps,
  mapDispatchToProps,
);

export default compose(
  withConnect,
  memo,
)(App);

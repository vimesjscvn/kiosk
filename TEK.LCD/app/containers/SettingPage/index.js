/* eslint-disable no-empty */
/* eslint-disable no-unused-expressions */
/* eslint-disable no-unneeded-ternary */
/* eslint-disable react/no-unused-prop-types */
/* eslint-disable no-unused-vars */
/* eslint-disable import/no-unresolved */
/* eslint-disable camelcase */
/* eslint-disable react/jsx-boolean-value */
/* eslint-disable no-restricted-globals */
/* eslint-disable jsx-a11y/click-events-have-key-events */
/* eslint-disable jsx-a11y/no-static-element-interactions */
/* eslint-disable global-require */
/* eslint-disable jsx-a11y/alt-text */
import React, { useEffect, memo, useState } from 'react';
import PropTypes from 'prop-types';
import Select from 'react-select';
import appReducer, { key } from 'containers/App/reducer';
import appSaga from 'containers/App/saga';
import * as Global from 'containers/App/selectors';
import * as appActions from 'containers/App/actions';
import * as fromApp from 'containers/App/constants';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer } from 'utils/injectReducer';
import { useInjectSaga } from 'utils/injectSaga';
import { isEmpty } from 'lodash';
import { Button, withStyles } from '@material-ui/core';
import './Setting.css';
// import LOGO1 from '../../images/LOGO1.png';

const StyledButton = withStyles({
  root: {
    padding: '12px 40px',
    border: '4px',
  },
  label: {
    fontWeight: 'bold',
    color: 'white',
  },
})(Button);

SettingPage.propTypes = {
  system: PropTypes.object,
  options: PropTypes.object,
  success: PropTypes.object,
  getSettingOptions: PropTypes.func,
  setSystemSetting: PropTypes.func,
  getSystemSetting: PropTypes.func,
  clearSuccess: PropTypes.func,
};
export function SettingPage(props) {
  const { system, options } = props;
  const [colorChange, setColorChange] = useState({});
  const [colorProChange, setColorProChange] = useState({});
  const [fontChange, setFontChange] = useState({});
  const [fontSizeChange, setFontSizeChange] = useState({});
  const [backgroundChange, setBackgroundChange] = useState({});
  const [SLBNChange, setSLBNChange] = useState({});
  const [logoChange, setLogoChange] = useState({});
  const [name, setName] = useState({});
  const [startBanner, setStartBanner] = useState({});
  const [timeBanner, setTimeBanner] = useState({});
  const [footer, setFooter] = useState({});

  useInjectReducer({ key, reducer: appReducer });
  useInjectSaga({ key, saga: appSaga });

  useEffect(() => {
    props.getSettingOptions();
  }, []);

  useEffect(() => {
    if (!isEmpty(system)) {
      setName(system.value.option_hospital[0]);
      setColorChange(system.value.option_color[0]);
      setColorProChange(system.value.option_color_by_priority[0]);
      setFontChange(system.value.options_font[0]);
      setFontSizeChange(system.value.options_size_font[0]);
      setBackgroundChange(system.value.option_background[0]);
      setSLBNChange(system.value.options_sl[0]);
      setLogoChange(system.value.logos_url[0]);
      setStartBanner(system.value.options_start_banner[0]);
      setTimeBanner(system.value.options_time_banner[0]);
      setFooter(system.value.options_footer[0]);
    }
  }, [system]);

  useEffect(() => {
    if (
      !isEmpty(props.success) &&
      props.success.key === fromApp.SET_SYSTEM_SETTING_SUCCESS
    ) {
      props.clearSuccess();
    }
  }, [props.success]);

  const save = () => {
    if (
      isEmpty(name) ||
      isEmpty(colorChange) ||
      isEmpty(backgroundChange) ||
      isEmpty(fontChange) ||
      isEmpty(SLBNChange) ||
      isEmpty(colorProChange) ||
      isEmpty(fontSizeChange) ||
      isEmpty(timeBanner) ||
      isEmpty(startBanner) ||
      isEmpty(footer) ||
      isEmpty(logoChange)
    )
      return;
    props.setSystemSetting({
      key: system.key,
      option_hospital: name,
      option_color: colorChange,
      option_background: backgroundChange,
      options_font: fontChange,
      options_sl: SLBNChange,
      option_color_by_priority: colorProChange,
      options_size_font: fontSizeChange,
      logos_url: logoChange,
      options_start_banner: startBanner,
      options_time_banner: timeBanner,
      options_footer: footer,
    });
  };

  const {
    options_font = [],
    option_color = [],
    option_background = [],
    options_sl = [],
    options_size_font = [],
    logos_url = [],
    option_color_by_priority = [],
    option_hospital = [],
    options_start_banner = [],
    options_time_banner = [],
    options_footer = [],
  } = !isEmpty(options) && options;

  return (
    <div className="containerSetting">
      <div className="center">
        {/* <img src={LOGO1} className="logoSettingPage" /> */}
        <p className="title">HỆ THỐNG TEKMEDI.BTC</p>
      </div>
      <div className="frontEnd">
        <div className="theme">
          <form className="wrapType">
            <p className="titleCategory">Name</p>
            <Select
              className="selectSetting"
              onChange={selectedOption => setName(selectedOption)}
              options={option_hospital}
              value={name}
              isSearchable={false}
              inputProps={{ readOnly: true }}
            />
          </form>
          <form className="wrapType">
            <p className="titleCategory">Font</p>
            <Select
              className="selectSetting"
              isSearchable={false}
              onChange={selectedOption => setFontChange(selectedOption)}
              options={options_font}
              value={fontChange}
              inputProps={{ readOnly: true }}
            />
          </form>
          <form className="wrapType">
            <p className="titleCategory">Color</p>
            <Select
              className="selectSetting"
              value={colorChange}
              isSearchable={false}
              onChange={selectedOption => setColorChange(selectedOption)}
              options={option_color}
              inputProps={{ readOnly: true }}
            />
          </form>
          <form className="wrapType">
            <p className="titleCategory">Color Priority</p>
            <Select
              className="selectSetting"
              isSearchable={false}
              value={colorProChange}
              onChange={selectedOption => setColorProChange(selectedOption)}
              options={option_color_by_priority}
              inputProps={{ readOnly: true }}
            />
          </form>
          <form className="wrapType">
            <p className="titleCategory">Background</p>
            <Select
              className="selectSetting"
              isSearchable={false}
              value={backgroundChange}
              onChange={selectedOption => setBackgroundChange(selectedOption)}
              options={option_background}
              inputProps={{ readOnly: true }}
            />
          </form>
          <form className="wrapType">
            <p className="titleCategory">Font Size</p>
            <Select
              className="selectSetting"
              isSearchable={false}
              value={fontSizeChange}
              onChange={selectedOption => setFontSizeChange(selectedOption)}
              options={options_size_font}
              inputProps={{ readOnly: true }}
            />
          </form>
          <form className="wrapType">
            <p className="titleCategory">SL NGƯỜI BỆNH</p>
            <Select
              className="selectSetting"
              isSearchable={false}
              value={SLBNChange}
              onChange={selectedOption => setSLBNChange(selectedOption)}
              options={options_sl}
              inputProps={{ readOnly: true }}
            />
          </form>
          <form className="wrapType">
            <p className="titleCategory">LOGO</p>
            <Select
              className="selectSetting"
              isSearchable={false}
              value={logoChange}
              onChange={selectedOption => setLogoChange(selectedOption)}
              options={logos_url}
              inputProps={{ readOnly: true }}
            />
          </form>

          <form className="wrapType">
            <p className="titleCategory">Start Banner</p>
            <Select
              className="selectSetting"
              isSearchable={false}
              value={startBanner}
              onChange={selectedOption => setStartBanner(selectedOption)}
              options={options_start_banner}
              inputProps={{ readOnly: true }}
            />
          </form>
          <form className="wrapType">
            <p className="titleCategory">Time Banner</p>
            <Select
              className="selectSetting"
              isSearchable={false}
              value={timeBanner}
              onChange={selectedOption => setTimeBanner(selectedOption)}
              options={options_time_banner}
              inputProps={{ readOnly: true }}
            />
          </form>
          <form className="wrapType">
            <p className="titleCategory">Footer</p>
            <Select
              className="selectSetting"
              isSearchable={false}
              value={footer}
              onChange={selectedOption => setFooter(selectedOption)}
              options={options_footer}
              inputProps={{ readOnly: true }}
            />
          </form>
          <div onClick={save} className="wrapButtonSetting">
            <span className="buttonSave">
              <StyledButton>Save</StyledButton>
            </span>
          </div>
        </div>
      </div>
      <p className="footer">
        {new Date().getFullYear()} © {name.value} BTC System Development By
        Tekmedi JSC
      </p>
    </div>
  );
}

export function mapDispatchToProps(dispatch) {
  return {
    getSettingOptions: () => dispatch(appActions.getSettingOptions()),
    setSystemSetting: setting => dispatch(appActions.setSystemSetting(setting)),
    getSystemSetting: name => dispatch(appActions.getSystemSetting(name)),
    clearSuccess: () => dispatch(appActions.clearSuccess()),
  };
}

const mapStateToProps = createStructuredSelector({
  system: Global.selectSystemSetting(),
  options: Global.selectSystemSettingOptions(),
  success: Global.selectSuccess(),
});

const withConnect = connect(
  mapStateToProps,
  mapDispatchToProps,
);

export default compose(
  withConnect,
  memo,
)(SettingPage);

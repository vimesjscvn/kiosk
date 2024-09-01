/* eslint-disable indent */
/* eslint-disable no-alert */
/* eslint-disable arrow-body-style */
/* eslint-disable no-unused-vars */
/* eslint-disable no-unused-expressions */
/* eslint-disable react/button-has-type */
/* eslint-disable jsx-a11y/alt-text */
/* eslint-disable no-underscore-dangle */
/* eslint-disable import/order */
/* eslint-disable default-case */
/* eslint-disable consistent-return */
import React, { useEffect, memo, useState } from 'react';
import * as Global from 'containers/App/selectors';
import * as appActions from 'containers/App/actions';
import propTypes from 'prop-types';
import Select from 'react-select';
import history, { redirectWithTypeStart } from 'utils/history';
import appReducer, { key } from 'containers/App/reducer';
import appSaga from 'containers/App/saga';
// import settingIcon from '../../images/settings.png';
import { Button, withStyles } from '@material-ui/core';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer } from 'utils/injectReducer';
import { useInjectSaga } from 'utils/injectSaga';
import {
  reduceTypeStart,
  typesList,
  TypesStart,
  ROOM,
  ROOM_ENDSCOPY,
  TYPE_START_KEY,
  GROUP_KEY,
  ROOM_CLS,
} from 'containers/App/helper';
import * as _ from 'lodash';
import './StartPage.css';

const StyledButton = withStyles({
  root: {
    padding: '12px 40px',
    background: 'red',
  },
  label: {
    fontWeight: 'bold',
    color: 'white',
  },
})(Button);

StartPage.propTypes = {
  groups: propTypes.any,
  depts: propTypes.any,
  device: propTypes.any,
  table: propTypes.any,
  system: propTypes.object,
  listRoom: propTypes.array,
  listRoomCLS: propTypes.array,
  ip: propTypes.string,
  updateDeviceSettingNotSave: propTypes.func,
  getDeptInGroups: propTypes.func,
};

export function StartPage({
  ip,
  table,
  listRoom,
  listRoomCLS,
  device,
  system,
  groups,
  depts,
  getDeptInGroups,
  updateDeviceSettingNotSave,
}) {
  useInjectReducer({ key, reducer: appReducer });
  useInjectSaga({ key, saga: appSaga });
  const [deviceLoad, setFormatDevice] = useState({});
  const [options, setOptions] = useState([]);
  const [optionSelect, setOptionSelect] = useState({});
  const [isSelect, setSelect] = useState(true);
  const [group, setGroup] = useState(null);
  const validateInitData = () => {
    console.log(listRoom)
    console.log(table)
    console.log(listRoomCLS)
    if (
      listRoom &&
      listRoom.length &&
      table &&
      table.length &&
      listRoomCLS &&
      listRoomCLS.length
    ) {
      return true;
    }
    return false;
  };
  const canActive = () => {
    if (
      _.isEmpty(optionSelect) &&
      deviceLoad &&
      deviceLoad.value !== TypesStart.CLS
    ) {
      return true;
    }
    return false;
  };

  useEffect(() => {
    if (!_.isEmpty(device)) {
      const _device = typesList.find(type => type.value === device.type);

      if (_device) {
        setFormatDevice(_device);
      }
    }
  }, [device]);

  useEffect(() => {
    function getDepts(groupSelect = {}) {
      if (_.isEmpty(groupSelect)) return;
      setOptionSelect(null);
      getDeptInGroups(groupSelect.code);
    }
    getDepts(group);
  }, [group]);
  useEffect(() => {
    console.log(!_.isEmpty(deviceLoad));
    console.log(validateInitData());
    if (!_.isEmpty(deviceLoad)) {
      reduceTypeStart(
        deviceLoad.value,
        setOptions,
        deviceLoad.value === TypesStart.ROOM ? listRoom : listRoomCLS,
        deviceLoad.value === TypesStart.NOISOI && depts.length ? depts : table,
        deviceLoad.value === TypesStart.ROOM_CLS && depts.length && depts,
      );

      if (options.length > 0) {
        const opt = options.find(o => o.value === device.code);
        setOptionSelect(opt);
      }
    }
  }, [deviceLoad, listRoom, table, depts, listRoomCLS]);
  const saveSetting = ({ target: { checked, value, name } }) => {
    const _value = name === 'isGoing' ? checked : value;
    setSelect(_value);
  };

  const onStart = () => {
    let code = '';
    let dvid = '';
    if (deviceLoad.value !== TypesStart.EYES_MANAGE) {
      const codeSelect = optionSelect.code
        ? optionSelect.code
        : optionSelect.value;
      code = codeSelect;
      dvid = optionSelect.dpVid;
    }
    if (deviceLoad.value === TypesStart.ROOM_CLS) {
      code = optionSelect.id;
      dvid = optionSelect.department_virtual_id;
    }
    const settingChanged = {
      ip,
      code,
      dvid,
      type: deviceLoad.value,
    };
    if (isSelect) {
      localStorage.setItem(TYPE_START_KEY, JSON.stringify(settingChanged));
    }
    updateDeviceSettingNotSave(settingChanged);
    redirectWithTypeStart(device.type);
    if (deviceLoad.value === TypesStart.NOISOI) {
      localStorage.setItem(GROUP_KEY, JSON.stringify(group));
      return localStorage.setItem(ROOM_ENDSCOPY, JSON.stringify(optionSelect));
    }
    if (deviceLoad.value === TypesStart.ROOM) {
      return localStorage.setItem(ROOM_CLS, JSON.stringify([optionSelect]));
    }
    if (deviceLoad.value === TypesStart.ROOM_CLS) {
      const data = {
        displayOrder: optionSelect.display_order,
        value: optionSelect.id,
        dpVid: optionSelect.department_virtual_id,
        label: optionSelect.name,
      };
      return localStorage.setItem(ROOM_CLS, JSON.stringify([data]));
    }
  };
console.log(options);
  return (
    <div className="mainContainer">
      <div className="mainContent">
        <div className="company">
          <p className="titleStart">HỆ THỐNG QUẢN LÝ MÀN HÌNH LCD</p>
        </div>
        <div className="wrapSelectStartPage">
          <form className="select">
            <p className="label">LOẠI MÀN HÌNH:</p>
            <Select
              defaultMenuIsOpen={false}
              className="customSelect"
              onChange={option => {
                console.log(option);
                setFormatDevice(option);
                setOptionSelect({});
              }}
              options={typesList.filter(type => type.label !== '')}
              inputProps={{ readOnly: true }}
              menuPosition="absolute"
              value={deviceLoad}
            />
          </form>
        </div>
        {deviceLoad.value !== TypesStart.CLS &&
          deviceLoad.value !== TypesStart.ROOM_CLS &&
          deviceLoad.value !== TypesStart.NOISOI && (
            <div className="wrapSelectStartPage">
              <form className="select">
                <p
                  className="label"
                  style={{
                    textTransform: 'uppercase',
                  }}
                >
                  {deviceLoad.value === TypesStart.TNB ? 'BÀN' : 'MÃ'}{' '}
                  {deviceLoad.label}
                </p>
                <Select
                  className="customSelect"
                  onChange={option => setOptionSelect(option)}
                  options={_.orderBy(options, 'displayOrder')}
                  inputProps={{ readOnly: true }}
                  menuPosition="absolute"
                  value={optionSelect}
                />
              </form>
            </div>
          )}
        {deviceLoad.value === TypesStart.NOISOI && (
          <>
            <div className="wrapSelectStartPage">
              <div className="select">
                <p className="label">MÃ NHÓM PHÒNG CẬN LÂM SÀNG</p>
                <Select
                  placeholder="Chọn nhóm phòng cận lâm sàng"
                  className="customSelect"
                  value={group}
                  options={groups}
                  getOptionLabel={opt => opt.name}
                  getOptionValue={opt => opt.code}
                  onChange={setGroup}
                />
              </div>
            </div>
            <div className="wrapSelectStartPage">
              <div className="select">
                <p className="label">CHỌN SỐ LƯỢNG PHÒNG CẬN LÂM SÀNG:</p>
                <Select
                  placeholder="Chọn phòng cận lâm sàng"
                  className="customSelect"
                  value={
                    !_.isEmpty(optionSelect) && optionSelect.length
                      ? optionSelect
                      : []
                  }
                  isMulti
                  options={options}
                  getOptionLabel={opt => opt.name}
                  getOptionValue={opt => opt}
                  closeMenuOnSelect={false}
                  onChange={value => setOptionSelect(_.sortBy(value, 'code'))}
                />
              </div>
            </div>
          </>
        )}
        {deviceLoad.value === TypesStart.ROOM_CLS && (
          <>
            <div className="wrapSelectStartPage">
              <div className="select">
                <p className="label">CHỌN KHOA PHÒNG:</p>
                <Select
                  placeholder="Chọn khoa phòng"
                  className="customSelect"
                  value={group}
                  options={groups}
                  getOptionLabel={opt => opt.name}
                  getOptionValue={opt => opt.code}
                  onChange={setGroup}
                />
              </div>
            </div>
            <div className="wrapSelectStartPage">
              <div className="select">
                <p className="label">CHỌN PHÒNG:</p>
                <Select
                  placeholder="Chọn phòng"
                  className="customSelect"
                  value={!_.isEmpty(optionSelect) ? optionSelect : null}
                  options={_.orderBy(options, 'displayOrder')}
                  getOptionLabel={opt => opt.name}
                  getOptionValue={opt => opt}
                  onChange={value => setOptionSelect(value)}
                />
              </div>
            </div>
          </>
        )}
        <div className="center">
          <label className="wrapCheckbox">
            <input
              className="checkbox"
              name="isGoing"
              type="checkbox"
              checked={isSelect}
              onChange={saveSetting}
            />
            Lưu cài đặt
          </label>
        </div>
        <div className="wrapButton">
          <StyledButton
            onClick={onStart}
            disabled={canActive(0)}
            style={canActive() ? { opacity: '0.4' } : {}}
          >
            Bắt đầu
          </StyledButton>
        </div>
      </div>
      <button
        onClick={() => history.push('/setting')}
        className="buttonGoSetting"
        style={{ cursor: 'pointer' }}
      >
        {/* <img src={settingIcon} className="imgSetting" /> */}
      </button>
    </div>
  );
}
function mapDispatchToProps(dispatch) {
  return {
    updateDeviceSettingNotSave: setting =>
      dispatch(appActions.updateDeviceSettingNotSave(setting)),
    changeDeviceType: device => dispatch(appActions.changeDeviceType(device)),
    getDeptInGroups: groupCode =>
      dispatch(appActions.getDeptInGroups(groupCode)),
  };
}
const mapStateToProps = createStructuredSelector({
  ip: Global.selectIp(),
  device: Global.selectDeviceSetting(),
  system: Global.selectSystemSetting(),
  table: Global.selectListTable(),
  listRoom: Global.selectListRoom(),
  listRoomCLS: Global.selectListRoomCLS(),
  loading: Global.selectLoading(),
  error: Global.selectError(),
  groups: Global.selectGroups(),
  depts: Global.selectDepts(),
});

const withConnect = connect(
  mapStateToProps,
  mapDispatchToProps,
);

export default compose(
  withConnect,
  memo,
)(StartPage);

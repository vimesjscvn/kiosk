/* eslint-disable import/order */
/* eslint-disable prettier/prettier */
/* eslint-disable no-undef */
/* eslint-disable no-unused-vars */
import { call, put, takeLatest, all } from 'redux-saga/effects';
import {
  getLocalIP,
  callTemperature,
  getLocalStorageSetting,
} from 'utils/Function';
import { isEmpty } from 'lodash';
import { AppConfig } from '../../public/appConfig';
import HttpRequest from 'utils/api';
import * as fromConstant from './constants';
import * as fromActions from './actions';
const http = new HttpRequest();
const deptHttp = new HttpRequest(AppConfig.END_POINT_DEPT);

export function* getSystemSetting(api, action) {
  const response = yield call(api.getSystemSetting, action.payload);
  if (response.ok) {
    yield put(fromActions.getSystemSettingSuccess(response.data.result));
  } else {
    yield put(fromActions.getSystemSettingFail(response.data));
  }
}

export function* getSettingOptions(api, action) {
  const response = yield call(api.getSystemSettingOptions, action.payload);
  if (response.ok) {
    yield put(fromActions.getSettingOptionsSuccess(response.data.result.value));
  } else {
    yield put(fromActions.getSettingOptionsFail(response.data));
  }
}

export function* setSystemSetting(api, action) {
  const response = yield call(api.setSystemSetting, action.payload);
  if (response.ok) {
    yield put(fromActions.setSystemSettingSuccess(response.data.result));
  } else {
    yield put(fromActions.setSystemSettingFail(response.data));
  }
}

export function* getDeviceSetting(api) {
  const response = yield call(api);
  if (response.ok) {
    yield put(fromActions.getDeviceSettingSuccess(response.data));
  } else {
    yield put(fromActions.getDeviceSettingFail(response));
  }
}

export function* setDeviceSetting(api, action) {
  const response = yield call(api.setDeviceSetting, action.payload);
  if (response.ok) {
    yield put(fromActions.setDeviceSettingSuccess(response.data.result));
  } else {
    yield put(fromActions.setDeviceSettingFail(response.data));
  }
}

export function* getIp(api) {
  const response = yield call(api);
  if (response.ok) {
    yield put(fromActions.getIpSuccess(response.data));
  } else {
    yield put(fromActions.getIpFail(response.data));
  }
}

export function* getTemperature(api) {
  const response = yield call(api);
  if (response.ok) {
    yield put(fromActions.getTemperatureSuccess(response.data));
  } else {
    yield put(fromActions.getTemperatureFail(response.error.toJSON()));
  }
}

export function* getListRoom(api) {
  const response = yield call(api.getListRoom);
  if (response.ok) {
    yield put(fromActions.getListRoomSuccess(response.data.result.data));
  } else {
    yield put(fromActions.getListRoomFail(response.data));
  }
}

export function* getListTable(api) {
  const response = yield call(api.getListTable);
  if (response.ok) {
    yield put(fromActions.getListTableSuccess(response.data.result));
  } else {
    yield put(fromActions.getListTableFail(response.data));
  }
}

export function* getListCPS(api, action) {
  const response = yield call(api.getListCps, action.payload);
  if (response.ok) {
    yield put(fromActions.getListCPSSuccess(response.data.result.result));
  } else {
    yield put(fromActions.getListCPSFail(response.data));
  }
}

export function* getCurrentPatientInRoom(api, action) {
  const response = yield call(api.multiCastGetPatientInRoom, action.payload);
  if (HttpRequest.validatePromiseAllReponse(response)) {
    yield put(
      fromActions.getCurrentPatientInRoomSuccess(
        HttpRequest.formatReponsePromiseAll(response),
      ),
    );
  } else {
    yield put(fromActions.getCurrentPatientInRoomFail(response));
  }
}

export function* getPatient(api, action) {
  const response = yield call(api.getListPatient, action.payload);
  if (response.ok) {
    yield put(fromActions.getPatientSuccess(response.data.result));
  } else {
    yield put(fromActions.getPatientFail(response.data));
  }
}

export function* getPatientPriority(api, action) {
  const response = yield call(api.getListPatientPriority, action.payload);
  if (response.ok) {
    yield put(fromActions.getPatientPrioritySuccess(response.data.result));
  } else {
    yield put(fromActions.getPatientPriorityFail(response.data));
  }
}

export function* getTNB(api, action) {
  const response = yield call(api.getTNB, action.payload);
  if (response.ok) {
    yield put(fromActions.getTNBSuccess(response.data.result));
  } else {
    yield put(fromActions.getTNBFail(response));
  }
}

export function* getPresentPatient(api, action) {
  const response = yield call(api.getPresentNumberMec, action.payload);
  if (response.ok) {
    yield put(
      fromActions.getPresentPatientSuccess(
        !isEmpty(response.data.result) && response.data.result[0].queue.number,
      ),
    );
  } else {
    yield put(fromActions.getPresentPatientFail(response.data));
  }
}

export function* getListPresentPatient(api, action) {
  const response = yield call(api.getListPresentMec, action.payload);
  if (response.ok) {
    yield put(fromActions.getListPresentPatientSuccess(response.data.result));
  } else {
    yield put(fromActions.getListPresentPatientFail(response.data));
  }
}

export function* getResultCLS(api, action) {
  const response = yield call(api.getResultCLS, action.payload);
  if (response.ok) {
    yield put(fromActions.getResultCLSSuccess(response.data.result));
  } else {
    yield put(fromActions.getResultCLSFail(response.data));
  }
}

export function* getBHYT(api, action) {
  const response = yield call(api.getThuocBHYT, action.payload);
  if (response.ok) {
    yield put(fromActions.getBHYTSuccess(response.data.result));
  } else {
    yield put(fromActions.getBHYTFail(response));
  }
}

export function* getGroups(api, action) {
  const response = yield call(api.getGroups, action.payload);
  if (response.ok) {
    const { data = [] } = response.data.result;
    yield put(fromActions.getGroupsSuccess(data));
  } else {
    yield put(fromActions.getGroupsFail(response));
  }
}

export function* getDeptInGroups(api, action) {
  const response = yield call(api.getDeptInGroups, action.payload);
  if (response.ok) {
    yield put(fromActions.getDeptInGroupsSuccess(response.data.result));
  } else {
    yield put(fromActions.getDeptInGroupsFail(response));
  }
}

export function* getDeptNameEndo(api, action) {
  const response = yield call(api.getDeptNameEndo, action.payload);
  if (response.ok) {
    yield put(fromActions.getDeptNameEndoSuccess(response.data.result));
  } else {
    yield put(fromActions.getDeptNameEndoFail(response));
  }
}

export function* getNumberRoomEndoscopy(api, action) {
  const response = yield call(api.getNumberRoomEndoscopy, action.payload);
  if (response.ok) {
    yield put(fromActions.getNumberRoomEndoscopySuccess(response.data.result));
  } else {
    yield put(fromActions.getNumberRoomEndoscopyFail(response));
  }
}

export function* getLastPatient(api, action) {
  const response = yield call(api.getLastPatient, action.payload);
  if (response.ok) {
    yield put(fromActions.getLastPatientSuccess(response.data.result));
  } else {
    yield put(fromActions.getLastPatientFail(response));
  }
}

export function* getLastPatientDepVid(api, action) {
  const response = yield call(api.getLastPatientDepVid, action.payload);
  if (response.ok) {
    yield put(fromActions.getLastPatientDepVidSuccess(response.data.result));
  } else {
    yield put(fromActions.getLastPatientDepVidFail(response));
  }
}

export function* getTableBHYT(api, action) {
  const response = yield call(api.getTableBHYT, action.payload);
  if (response.ok) {
    yield put(fromActions.getTableBHYTSuccess(response.data.result));
  } else {
    yield put(fromActions.getTableBHYTFail(response));
  }
}

export default function* appSaga() {
  yield all([
    yield takeLatest(fromConstant.GET_SYSTEM_SETTING, getSystemSetting, http),
    yield takeLatest(fromConstant.GET_SETTING_OPTIONS, getSettingOptions, http),
    yield takeLatest(fromConstant.SET_SYSTEM_SETTING, setSystemSetting, http),
    yield takeLatest(
      fromConstant.GET_DEVICE_SETTING,
      getDeviceSetting,
      getLocalStorageSetting,
    ),
    yield takeLatest(fromConstant.SET_DEVICE_SETTING, setDeviceSetting, http),
    yield takeLatest(fromConstant.GET_LOCAL_IP, getIp, getLocalIP),
    yield takeLatest(
      fromConstant.GET_TEMPERATURE,
      getTemperature,
      callTemperature,
    ),
    yield takeLatest(fromConstant.GET_LIST_ROOM, getListRoom, http),
    yield takeLatest(fromConstant.GET_LIST_TABLE, getListTable, http),
    yield takeLatest(fromConstant.GET_LIST_CPS, getListCPS, http),
    yield takeLatest(
      fromConstant.GET_PATIENT_CURRENT_ROOM,
      getCurrentPatientInRoom,
      http,
    ),
    yield takeLatest(fromConstant.GET_PATIENT, getPatient, http),
    yield takeLatest(
      fromConstant.GET_PRIORITY_PATIENT,
      getPatientPriority,
      http,
    ),
    yield takeLatest(fromConstant.GET_TNB, getTNB, http),
    yield takeLatest(
      fromConstant.GET_LIST_PRESENT_PATIENT,
      getListPresentPatient,
      http,
    ),
    yield takeLatest(fromConstant.GET_PRESENT_PATIENT, getPresentPatient, http),
    yield takeLatest(fromConstant.GET_RESULT_CLS, getResultCLS, http),
    yield takeLatest(fromConstant.GET_BHYT, getBHYT, http),
    yield takeLatest(
      fromConstant.GET_NUMBER_ENDSCOPY,
      getNumberRoomEndoscopy,
      http,
    ),
    yield takeLatest(fromConstant.GET_GROUPS, getGroups, deptHttp),
    yield takeLatest(fromConstant.GET_DEPT_IN_GROUPS, getDeptInGroups, http),
    yield takeLatest(fromConstant.GET_ENDO_NAME, getDeptNameEndo, deptHttp),
    yield takeLatest(fromConstant.GET_LAST_PATIENT, getLastPatient, http),
    yield takeLatest(
      fromConstant.GET_LAST_PATIENT_DEPT_VID,
      getLastPatientDepVid,
      http,
    ),
    yield takeLatest(fromConstant.GET_TABLE_BHYT, getTableBHYT, http),
  ]);
}

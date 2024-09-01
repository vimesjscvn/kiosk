import * as fromApp from './constants';
/* No Effects */

export function resetStore() {
  return {
    type: fromApp.RESET_STORE,
  };
}

export function clearSuccess() {
  return {
    type: fromApp.CLEAR_SUCCESS,
  };
}

export function changeDeviceType(payload) {
  return {
    type: fromApp.CHANGE_DEVICE_TYPE,
    payload,
  };
}

export function setTableBHYT(payload) {
  return {
    type: fromApp.SET_TABLE_BHYT,
    payload,
  };
}

export function updateDeviceSettingNotSave(payload) {
  return {
    type: fromApp.UPDATE_DEVICE_SETTING_NOT_SAVE,
    payload,
  };
}

export function clearEndoscopyList(payload) {
  return {
    type: fromApp.CLEAR_LIST_ENDOSCOPY,
    payload,
  };
}

/* Effects */
export function getDeviceSetting(payload) {
  return {
    type: fromApp.GET_DEVICE_SETTING,
    payload,
  };
}

export function getDeviceSettingSuccess(payload) {
  return {
    type: fromApp.GET_DEVICE_SETTING_SUCCESS,
    payload,
  };
}

export function getDeviceSettingFail(payload) {
  return {
    type: fromApp.GET_DEVICE_SETTING_FAIL,
    payload,
  };
}

export function setDeviceSetting(payload) {
  return {
    type: fromApp.SET_DEVICE_SETTING,
    payload,
  };
}

export function setDeviceSettingSuccess(payload) {
  return {
    type: fromApp.SET_DEVICE_SETTING_SUCCESS,
    payload,
  };
}

export function setDeviceSettingFail(payload) {
  return {
    type: fromApp.SET_DEVICE_SETTING_FAIL,
    payload,
  };
}

export function getSystemSetting(payload) {
  return {
    type: fromApp.GET_SYSTEM_SETTING,
    payload,
  };
}

export function getSystemSettingSuccess(payload) {
  return {
    type: fromApp.GET_SYSTEM_SETTING_SUCCESS,
    payload,
  };
}

export function getSystemSettingFail(payload) {
  return {
    type: fromApp.GET_SYSTEM_SETTING_FAIL,
    payload,
  };
}

export function getSettingOptions(payload) {
  return {
    type: fromApp.GET_SETTING_OPTIONS,
    payload,
  };
}

export function getSettingOptionsSuccess(payload) {
  return {
    type: fromApp.GET_SETTING_OPTIONS_SUCCESS,
    payload,
  };
}

export function getSettingOptionsFail(payload) {
  return {
    type: fromApp.GET_SETTING_OPTIONS_FAIL,
    payload,
  };
}

export function setSystemSetting(payload) {
  return {
    type: fromApp.SET_SYSTEM_SETTING,
    payload,
  };
}

export function setSystemSettingSuccess(payload) {
  return {
    type: fromApp.SET_SYSTEM_SETTING_SUCCESS,
    payload,
  };
}

export function setSystemSettingFail(payload) {
  return {
    type: fromApp.SET_SYSTEM_SETTING_FAIL,
    payload,
  };
}

export function getIp(payload) {
  return {
    type: fromApp.GET_LOCAL_IP,
    payload,
  };
}

export function getIpSuccess(payload) {
  return {
    type: fromApp.GET_LOCAL_IP_SUCCESS,
    payload,
  };
}

export function getIpFail(payload) {
  return {
    type: fromApp.GET_LOCAL_IP_FAIL,
    payload,
  };
}

export function getTemperature(payload) {
  return {
    type: fromApp.GET_TEMPERATURE,
    payload,
  };
}

export function getTemperatureSuccess(payload) {
  return {
    type: fromApp.GET_TEMPERATURE_SUCCESS,
    payload,
  };
}

export function getTemperatureFail(payload) {
  return {
    type: fromApp.GET_TEMPERATURE_FAIL,
    payload,
  };
}

export function getListRoom(payload) {
  return {
    type: fromApp.GET_LIST_ROOM,
    payload,
  };
}

export function getListRoomSuccess(payload) {
  return {
    type: fromApp.GET_LIST_ROOM_SUCCESS,
    payload,
  };
}

export function getListRoomFail(payload) {
  return {
    type: fromApp.GET_LIST_ROOM_FAIL,
    payload,
  };
}

export function getListTable(payload) {
  return {
    type: fromApp.GET_LIST_TABLE,
    payload,
  };
}

export function getListTableSuccess(payload) {
  return {
    type: fromApp.GET_LIST_TABLE_SUCCESS,
    payload,
  };
}

export function getListTableFail(payload) {
  return {
    type: fromApp.GET_LIST_TABLE_FAIL,
    payload,
  };
}

export function getListCPS(payload) {
  return {
    type: fromApp.GET_LIST_CPS,
    payload,
  };
}

export function getListCPSSuccess(payload) {
  return {
    type: fromApp.GET_LIST_CPS_SUCCESS,
    payload,
  };
}

export function getListCPSFail(payload) {
  return {
    type: fromApp.GET_LIST_CPS_FAIL,
    payload,
  };
}

export function getCurrentPatientInRoom(payload) {
  return {
    type: fromApp.GET_PATIENT_CURRENT_ROOM,
    payload,
  };
}

export function getCurrentPatientInRoomSuccess(payload) {
  return {
    type: fromApp.GET_PATIENT_CURRENT_ROOM_SUCCESS,
    payload,
  };
}

export function getCurrentPatientInRoomFail(payload) {
  return {
    type: fromApp.GET_PATIENT_CURRENT_ROOM_FAIL,
    payload,
  };
}

export function getPatient(payload) {
  return {
    type: fromApp.GET_PATIENT,
    payload,
  };
}

export function getPatientSuccess(payload) {
  return {
    type: fromApp.GET_PATIENT_SUCCESS,
    payload,
  };
}

export function getPatientFail(payload) {
  return {
    type: fromApp.GET_PATIENT_FAIL,
    payload,
  };
}

export function getPatientPriority(payload) {
  return {
    type: fromApp.GET_PRIORITY_PATIENT,
    payload,
  };
}

export function getPatientPrioritySuccess(payload) {
  return {
    type: fromApp.GET_PRIORITY_PATIENT_SUCCESS,
    payload,
  };
}

export function getPatientPriorityFail(payload) {
  return {
    type: fromApp.GET_PRIORITY_PATIENT_FAIL,
    payload,
  };
}

export function getTNB(payload) {
  return {
    type: fromApp.GET_TNB,
    payload,
  };
}

export function getTNBSuccess(payload) {
  return {
    type: fromApp.GET_TNB_SUCCESS,
    payload,
  };
}

export function getTNBFail(payload) {
  return {
    type: fromApp.GET_TNB_FAIL,
    payload,
  };
}

export function getListPresentPatient(payload) {
  return {
    type: fromApp.GET_LIST_PRESENT_PATIENT,
    payload,
  };
}

export function getListPresentPatientSuccess(payload) {
  return {
    type: fromApp.GET_LIST_PRESENT_PATIENT_SUCCESS,
    payload,
  };
}

export function getListPresentPatientFail(payload) {
  return {
    type: fromApp.GET_LIST_PRESENT_PATIENT_FAIL,
    payload,
  };
}

export function getPresentPatient(payload) {
  return {
    type: fromApp.GET_PRESENT_PATIENT,
    payload,
  };
}

export function getPresentPatientSuccess(payload) {
  return {
    type: fromApp.GET_PRESENT_PATIENT_SUCCESS,
    payload,
  };
}

export function getPresentPatientFail(payload) {
  return {
    type: fromApp.GET_PRESENT_PATIENT_FAIL,
    payload,
  };
}

export function getResultCLS(payload) {
  return {
    type: fromApp.GET_RESULT_CLS,
    payload,
  };
}

export function getResultCLSSuccess(payload) {
  return {
    type: fromApp.GET_RESULT_CLS_SUCCESS,
    payload,
  };
}

export function getResultCLSFail(payload) {
  return {
    type: fromApp.GET_RESULT_CLS_FAIL,
    payload,
  };
}

export function getBHYT(payload) {
  return {
    type: fromApp.GET_BHYT,
    payload,
  };
}

export function getBHYTSuccess(payload) {
  return {
    type: fromApp.GET_BHYT_SUCCESS,
    payload,
  };
}

export function getBHYTFail(payload) {
  return {
    type: fromApp.GET_BHYT_FAIL,
    payload,
  };
}

export function getGroups(payload) {
  return {
    type: fromApp.GET_GROUPS,
    payload,
  };
}

export function getGroupsSuccess(payload) {
  return {
    type: fromApp.GET_GROUPS_SUCCESS,
    payload,
  };
}

export function getGroupsFail(payload) {
  return {
    type: fromApp.GET_GROUPS_FAIL,
    payload,
  };
}

export function getDeptInGroups(payload) {
  return {
    type: fromApp.GET_DEPT_IN_GROUPS,
    payload,
  };
}

export function getDeptInGroupsSuccess(payload) {
  return {
    type: fromApp.GET_DEPT_IN_GROUPS_SUCCESS,
    payload,
  };
}

export function getDeptInGroupsFail(payload) {
  return {
    type: fromApp.GET_DEPT_IN_GROUPS_FAIL,
    payload,
  };
}

export function getDeptNameEndo(payload) {
  return {
    type: fromApp.GET_ENDO_NAME,
    payload,
  };
}

export function getDeptNameEndoSuccess(payload) {
  return {
    type: fromApp.GET_ENDO_NAME_SUCCESS,
    payload,
  };
}

export function getDeptNameEndoFail(payload) {
  return {
    type: fromApp.GET_ENDO_NAME_FAIL,
    payload,
  };
}

export function getNumberRoomEndoscopy(payload) {
  return {
    type: fromApp.GET_NUMBER_ENDSCOPY,
    payload,
  };
}

export function getNumberRoomEndoscopySuccess(payload) {
  return {
    type: fromApp.GET_NUMBER_ENDSCOPY_SUCCESS,
    payload,
  };
}

export function getNumberRoomEndoscopyFail(payload) {
  return {
    type: fromApp.GET_NUMBER_ENDSCOPY_FAIL,
    payload,
  };
}

export function getLastPatient(payload) {
  return {
    type: fromApp.GET_LAST_PATIENT,
    payload,
  };
}

export function getLastPatientSuccess(payload) {
  return {
    type: fromApp.GET_LAST_PATIENT_SUCCESS,
    payload,
  };
}

export function getLastPatientFail(payload) {
  return {
    type: fromApp.GET_LAST_PATIENT_FAIL,
    payload,
  };
}

export function getLastPatientDepVid(payload) {
  return {
    type: fromApp.GET_LAST_PATIENT_DEPT_VID,
    payload,
  };
}

export function getLastPatientDepVidSuccess(payload) {
  return {
    type: fromApp.GET_LAST_PATIENT_DEPT_VID_SUCCESS,
    payload,
  };
}

export function getLastPatientDepVidFail(payload) {
  return {
    type: fromApp.GET_LAST_PATIENT_DEPT_VID_FAIL,
    payload,
  };
}

export function clearLastPatientDepVidFail() {
  return {
    type: fromApp.CLEAR_LAST_PATIENT_DEPT_VID_FAIL,
  };
}

export function getTableBHYT(payload) {
  return {
    type: fromApp.GET_TABLE_BHYT,
    payload,
  };
}

export function getTableBHYTSuccess(payload) {
  return {
    type: fromApp.GET_TABLE_BHYT_SUCCESS,
    payload,
  };
}

export function getTableBHYTFail(payload) {
  return {
    type: fromApp.GET_TABLE_BHYT_FAIL,
    payload,
  };
}

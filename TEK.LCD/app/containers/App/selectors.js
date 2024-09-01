import { createSelector } from 'reselect';
import { initialState } from './reducer';

const globalState = state => state.global || initialState;
const routerState = state => state.router;

export const selectRouter = () =>
  createSelector(
    routerState,
    router => router.location,
  );

export const selectLoading = () =>
  createSelector(
    globalState,
    global => global.loading,
  );

export const selectError = () =>
  createSelector(
    globalState,
    global => global.error,
  );

export const selectDeviceSetting = () =>
  createSelector(
    globalState,
    global => global.deviceSetting,
  );

export const selectSystemSetting = () =>
  createSelector(
    globalState,
    global => global.systemSetting,
  );

export const selectSystemSettingOptions = () =>
  createSelector(
    globalState,
    global => global.systemSettingOptions,
  );

export const selectTemperature = () =>
  createSelector(
    globalState,
    global => global.temperature,
  );

export const selectIp = () =>
  createSelector(
    globalState,
    global => global.ip,
  );

export const selectSuccess = () =>
  createSelector(
    globalState,
    global => global.success,
  );

export const selectListRoom = () =>
  createSelector(
    globalState,
    global => global.listRoom,
  );

export const selectListRoomCLS = () =>
  createSelector(
    globalState,
    global => global.listRoomCLS,
  );

export const selectListTable = () =>
  createSelector(
    globalState,
    global => global.listTable,
  );

export const selectCurrentPatient = () =>
  createSelector(
    globalState,
    global => global.currentPatients,
  );

export const selectPatients = () =>
  createSelector(
    globalState,
    global => global.patients,
  );

export const selectPatientsDeptVirtual = () =>
  createSelector(
    globalState,
    global => global.patientsDeptVirtual,
  );

export const selectPatientsPriority = () =>
  createSelector(
    globalState,
    global => global.patientsPriority,
  );

export const selectWatingPatients = () =>
  createSelector(
    globalState,
    global => global.waitingPatients,
  );

export const selectTNB = () =>
  createSelector(
    globalState,
    global => global.tnb,
  );

export const selectBHYTPresent = () =>
  createSelector(
    globalState,
    global => global.bhytPresent,
  );

export const selectBHYTPrepare = () =>
  createSelector(
    globalState,
    global => global.bhytPrepare,
  );

export const selectListPresent = () =>
  createSelector(
    globalState,
    global => global.listPresent,
  );

export const selectPresent = () =>
  createSelector(
    globalState,
    global => global.presentNumber,
  );

export const selectResultCLS = () =>
  createSelector(
    globalState,
    global => global.resultCLS,
  );

export const selectListCPS = () =>
  createSelector(
    globalState,
    global => global.listCPS,
  );

export const selectBhyt = () =>
  createSelector(
    globalState,
    global => global.bhyt,
  );

export const selectGroups = () =>
  createSelector(
    globalState,
    global => global.groups,
  );

export const selectDepts = () =>
  createSelector(
    globalState,
    global => global.depts,
  );

export const selectListRoomEndoscopy = () =>
  createSelector(
    globalState,
    global => global.listRoomEndoscopy,
  );

export const selectEndoscopy = () =>
  createSelector(
    globalState,
    global => global.endoscopyList,
  );

export const selectTableBHYT = () =>
  createSelector(
    globalState,
    global => global.tableBHYT,
  );

/* eslint-disable indent */
/* eslint-disable camelcase */
/* eslint-disable prefer-const */
/* eslint-disable consistent-return */
/* eslint-disable arrow-body-style */
/* eslint-disable no-case-declarations */
/* eslint-disable no-debugger */
/* eslint-disable no-duplicate-case */
/* eslint-disable no-unused-vars */
/* eslint-disable import/no-useless-path-segments */
/* eslint-disable import/no-unresolved */
import produce from 'immer';
import _ from 'lodash';
import * as fromApp from './constants';
import { DeptWithOutGroup, DeptWithGroup, searchVNEntity } from './helper';

export const initialState = {
  loading: false,
  error: false,
  success: {},
  ip: '',
  deviceSetting: {},
  systemSetting: {},
  systemSettingOptions: {},
  temperature: 21,
  listRoom: [],
  listRoomCLS: [],
  listTable: [],
  listCPS: null,
  patients: [],
  currentPatients: null,
  patientsPriority: null,
  patientsDeptVirtual: [],
  waitingPatients: null,
  tnb: {},
  listPresent: {},
  presentNumber: null,
  resultCLS: [],
  groups: [],
  depts: [],
  bhyt: [],
  endoscopyList: [],
  tableBHYT: {},
};

export const key = 'global';

const reduceRoom = (rooms = []) => {
  let roomState = {
    listRoom: [],
    listRoomCLS: [],
  };
  if (!rooms.length) return roomState;
  // new
  roomState.listRoom = rooms.filter(r =>
    ['KB', 'KBYC'].includes(r.list_value_code),
  );
  roomState.listRoomCLS = rooms.filter(r =>
    ['CDHA', 'NOISOI', 'XN', 'HHVS'].includes(r.list_value_code),
  );
  /* old
  roomState.listRoom =
    DeptWithOutGroup(rooms) && DeptWithOutGroup(rooms).length
      ? DeptWithOutGroup(rooms).filter(
          room => searchVNEntity(room.code, 'KQ.CLS') < 0,
        )
      : [];
  roomState.listRoomCLS = DeptWithGroup(rooms);
  */
  return roomState;
};

const appReducer = (state = initialState, action) =>
  produce(state, draft => {
    switch (action.type) {
      case fromApp.GET_DEVICE_SETTING:
      case fromApp.SET_DEVICE_SETTING:
      case fromApp.GET_SYSTEM_SETTING:
      case fromApp.SET_SYSTEM_SETTING:
      case fromApp.GET_SETTING_OPTIONS:
      case fromApp.GET_LOCAL_IP:
      case fromApp.GET_TEMPERATURE:
      case fromApp.GET_LIST_ROOM:
      case fromApp.GET_LIST_TABLE:
      case fromApp.GET_LIST_CPS:
      case fromApp.GET_PATIENT_CURRENT_ROOM:
      case fromApp.GET_PATIENT:
      case fromApp.GET_PRIORITY_PATIENT:
      case fromApp.GET_TNB:
      case fromApp.GET_PRESENT_PATIENT:
      case fromApp.GET_LIST_PRESENT_PATIENT:
      case fromApp.GET_RESULT_CLS:
      case fromApp.GET_BHYT:
      case fromApp.GET_GROUPS:
      case fromApp.GET_ENDO_NAME:
      case fromApp.GET_NUMBER_ENDSCOPY:
      case fromApp.GET_LAST_PATIENT:
      case fromApp.GET_LAST_PATIENT_DEPT_VID:
      case fromApp.GET_TABLE_BHYT:
        return {
          ...draft,
          loading: true,
        };
      case fromApp.GET_DEVICE_SETTING_SUCCESS:
      case fromApp.SET_DEVICE_SETTING_SUCCESS:
        return {
          ...draft,
          loading: false,
          deviceSetting: action.payload,
        };
      case fromApp.CHANGE_DEVICE_TYPE:
        return {
          ...draft,
          deviceSetting: {
            ...draft.deviceSetting,
            type: action.payload,
            name: '',
            code: '',
          },
        };
      case fromApp.UPDATE_DEVICE_SETTING_NOT_SAVE:
        return {
          ...draft,
          deviceSetting: action.payload,
        };
      case fromApp.GET_SYSTEM_SETTING_SUCCESS:
        return {
          ...draft,
          loading: false,
          systemSetting: action.payload,
        };
      case fromApp.GET_LOCAL_IP_SUCCESS:
        return {
          ...draft,
          loading: false,
          ip: action.payload,
        };
      case fromApp.GET_TEMPERATURE_SUCCESS:
        return {
          ...draft,
          loading: false,
          temperature: action.payload,
        };
      case fromApp.GET_TEMPERATURE_FAIL:
        return {
          ...draft,
          loading: false,
          temperature: 18,
        };
      case fromApp.GET_SETTING_OPTIONS_SUCCESS:
        return {
          ...draft,
          loading: false,
          systemSettingOptions: action.payload,
        };
      case fromApp.GET_LIST_ROOM_SUCCESS:
        const { listRoom = [], listRoomCLS = [] } = reduceRoom(
          action.payload.map(item => {
            return {
              ...item,
              value: item.code,
              label: item.description,
            };
          }),
        );
        return {
          ...draft,
          loading: false,
          listRoom,
          listRoomCLS,
        };
      case fromApp.GET_LIST_TABLE_SUCCESS:
        console.log(action.payload);
        return {
          ...draft,
          loading: false,
          listTable: action.payload.map(item => {
            return {
              ...item,
              value: item.code,
              label: item.name,
            };
          }),
        };
      case fromApp.GET_LIST_CPS_SUCCESS:
        return {
          ...draft,
          loading: false,
          listCPS: action.payload,
        };
      case fromApp.GET_PATIENT_CURRENT_ROOM_SUCCESS:
        return {
          ...draft,
          currentPatients: action.payload,
          loading: false,
        };
      case fromApp.GET_PATIENT_SUCCESS:
        return {
          ...draft,
          loading: false,
          patients: action.payload,
        };
      case fromApp.GET_PRIORITY_PATIENT_SUCCESS:
        return {
          ...draft,
          loading: false,
          patientsPriority: action.payload,
        };
      case fromApp.GET_TNB_SUCCESS:
        return {
          ...draft,
          loading: false,
          tnb: action.payload,
        };
      case fromApp.GET_PRESENT_PATIENT_SUCCESS:
        return {
          ...draft,
          loading: false,
          presentNumber: action.payload,
        };
      case fromApp.GET_LIST_PRESENT_PATIENT_SUCCESS:
        return {
          ...draft,
          loading: false,
          listPresent: action.payload,
        };
      case fromApp.GET_LIST_PRESENT_PATIENT_SUCCESS:
        return {
          ...draft,
          loading: false,
          listPresent: action.payload,
        };
      case fromApp.GET_RESULT_CLS_SUCCESS:
        return {
          ...draft,
          loading: false,
          resultCLS: AppReducerHelper.formatResultCls(action.payload),
        };
      case fromApp.GET_BHYT_SUCCESS:
        return {
          ...draft,
          loading: false,
          bhyt: action.payload,
        };
      case fromApp.SET_SYSTEM_SETTING_SUCCESS:
        return {
          ...draft,
          loading: false,
          success: {
            key: fromApp.SET_SYSTEM_SETTING_SUCCESS,
          },
        };
      case fromApp.CLEAR_SUCCESS:
        return {
          ...draft,
          success: null,
        };
      case fromApp.GET_GROUPS_SUCCESS:
        return {
          ...draft,
          loading: false,
          groups: action.payload,
        };
      case fromApp.GET_DEPT_IN_GROUPS:
        return {
          ...state,
          depts: [],
        };
      case fromApp.GET_DEPT_IN_GROUPS_SUCCESS:
        return {
          ...draft,
          loading: false,
          depts: action.payload,
        };
      case fromApp.GET_ENDO_NAME_SUCCESS:
        return {
          ...draft,
          loading: false,
          listRoomEndoscopy: action.payload,
        };
      case fromApp.GET_NUMBER_ENDSCOPY_SUCCESS:
        const dataEndscopy = AppReducerHelper.compareList(
          JSON.parse(JSON.stringify(draft.endoscopyList)),
          action.payload,
        );
        return {
          ...draft,
          loading: false,
          endoscopyList: dataEndscopy,
        };
      case fromApp.GET_LAST_PATIENT_SUCCESS:
        const { last_patients = [] } = action.payload;
        const { normal, priority } = AppReducerHelper.seperateListPatient(
          last_patients,
        );
        return {
          ...draft,
          loading: false,
          patients: normal,
          patientsPriority: priority,
          waitingPatients: action.payload,
        };
      case fromApp.GET_LAST_PATIENT_DEPT_VID_SUCCESS:
        const { normal_patients = [] } = action.payload;
        return {
          ...draft,
          patientsDeptVirtual: normal_patients,
        };
      case fromApp.CLEAR_LAST_PATIENT_DEPT_VID_FAIL:
        return {
          ...draft,
          patientsDeptVirtual: [],
        };
      case fromApp.CLEAR_LIST_ENDOSCOPY:
        return {
          ...draft,
          loading: false,
          endoscopyList: [],
          listRoomEndoscopy: [],
        };
      case fromApp.SET_TABLE_BHYT:
      case fromApp.GET_TABLE_BHYT_SUCCESS:
        return {
          ...draft,
          tableBHYT: action.payload,
        };
      case fromApp.RESET_STORE:
        return {
          ...initialState,
        };
      case fromApp.GET_DEVICE_SETTING_FAIL:
      case fromApp.SET_DEVICE_SETTING_FAIL:
      case fromApp.GET_SYSTEM_SETTING_FAIL:
      case fromApp.SET_SYSTEM_SETTING_FAIL:
      case fromApp.GET_LOCAL_IP_FAIL:
      case fromApp.GET_SETTING_OPTIONS_FAIL:
      case fromApp.GET_LIST_ROOM_FAIL:
      case fromApp.GET_LIST_TABLE_FAIL:
      case fromApp.GET_LIST_CPS_FAIL:
      case fromApp.GET_PATIENT_CURRENT_ROOM_FAIL:
      case fromApp.GET_PATIENT_FAIL:
      case fromApp.GET_PRIORITY_PATIENT_FAIL:
      case fromApp.GET_TNB_FAIL:
      case fromApp.GET_PRESENT_PATIENT_FAIL:
      case fromApp.GET_LIST_PRESENT_PATIENT_FAIL:
      case fromApp.GET_RESULT_CLS_FAIL:
      case fromApp.GET_BHYT_FAIL:
      case fromApp.GET_GROUPS_FAIL:
      case fromApp.GET_DEPT_IN_GROUPS_FAIL:
      case fromApp.GET_ENDO_NAME_FAIL:
      case fromApp.GET_NUMBER_ENDSCOPY_FAIL:
      case fromApp.GET_LAST_PATIENT_FAIL:
      case fromApp.GET_LAST_PATIENT_DEPT_VID_FAIL:
      case fromApp.GET_TABLE_BHYT_FAIL:
        return {
          ...draft,
          loading: false,
          error: action.payload,
        };
      default:
        return draft;
    }
  });

export default appReducer;

export class AppReducerHelper {
  static compareList(oldList, newList) {
    if (!oldList.length && !newList.length) return [];
    if (!oldList.length && newList.length) {
      return newList.map(eye => ({
        ...eye,
        isChangeNormal: false,
        isChangePriority: false,
      }));
    }
    return newList.map(newEye => {
      const changeEye = oldList.find(
        oldEye => oldEye.deparment_code === newEye.deparment_code,
      );
      return {
        ...newEye,
        isChangeNormal: newEye.normal_number !== changeEye.normal_number,
        isChangePriority: newEye.priority_number !== changeEye.priority_number,
      };
    });
  }

  static formatListRoom(listRoom = []) {
    if (!listRoom.length) return;
    return listRoom.map(item => {
      return {
        ...item,
        value: item.code,
        label: item.description,
      };
    });
  }

  static changeDeptName(newDepts = [], deptsWithNewName = []) {
    if (!newDepts.length && !deptsWithNewName.length) return [];
    if (newDepts.length && !deptsWithNewName.length) return newDepts;
    return newDepts.map(dept => {
      const newNameDept = deptsWithNewName.find(
        newDept => newDept.code === dept.deparment_code,
      );
      if (newNameDept) {
        return {
          ...dept,
          department_name: newNameDept.name_change,
        };
      }
      return dept;
    });
  }

  static seperateListPatient(patients = []) {
    if (!patients || !patients.length) {
      return { normal: [], priority: [] };
    }
    return {
      normal: patients.filter(({ type }) => !type),
      priority: patients.filter(({ type }) => type),
    };
  }

  static formatResultCls(patients = []) {
    if (!patients || !patients.length) return [];
    return _.orderBy(
      patients.map(patient => {
        const { result_date } = patient;
        const resultTime = new Date(result_date).getTime();
        const currentTime = new Date().getTime();
        return {
          ...patient,
          isNew: currentTime - resultTime < 900000,
        };
      }),
      ['result_date', 'isNew'],
      ['desc'],
    );
  }
}

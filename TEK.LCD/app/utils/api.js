/* eslint-disable prettier/prettier */
/* eslint-disable arrow-body-style */
import apisauce from 'apisauce';
import { get } from 'lodash';
import { AppConfig } from 'public/appConfig';
import { getLocalStorageSetting, formDateTime } from './Function';
import { DataResponse } from '../mock/PatienData';
export default class HttpRequest {
  constructor(baseURL = AppConfig.END_POINT) {
    this.request = apisauce.create({
      baseURL,
      headers: {
        'Cache-Control': 'no-cache',
      },
      timeout: 20000,
    });
  }

  getTNB = (table, limit = 5) =>
    this.request.post('api/Register/queue/table/number', {
      Table: table,
      Limit: limit,
    });

  getListTable = () => this.request.get('api/Table/all');

  getListRoom = () => this.request.get('api/Room/all');

  getListPatient = room =>
    this.request.post('api/Register/queue/patients', {
      room,
      type: 0,
      limit: 5,
    });

  getListPatientPriority = room =>
    this.request.post('api/Register/queue/patients', {
      room,
      type: 1,
      limit: 3,
    });

  getCurrentPatientRoom = room =>
    this.request.get(`/api/QueueNumber/latest/number/${room}`);

  getLastPatient = room =>
    this.request.post('/api/Register/queue/room/last', {
      date: formDateTime(),
      limit: 5,
      room,
    });

  getLastPatientDepVid = room =>
    this.request.post('/api/Register/queue/room/last', {
      date: formDateTime(),
      limit: 5,
      room,
    });

  getResultCLSInRoom = room => {
    return this.request.post('api/Register/queue/result', {
      limit: 3,
      room,
      date: formDateTime(),
    });
  };

  getListCps = table =>
    this.request.post(`api/Register/queue/cps/all`, {
      code: table.code,
      limit: 5,
    });

  getResultCLS = () => {
    return this.request.get('api/Clinic/result?limit=9999');
  };

  getSystemSetting = name => this.request.get(`api/Setting/${name}`);

  getSystemSettingOptions = () => this.request.get(`api/Setting/all`);

  setSystemSetting = setting => {
    return this.request.post('api/Setting/create-or-update', setting);
  };

  setDeviceSetting = request =>
    this.request.post('api/Setting/add-or-update', request);

  multiCastGetPatientInRoom = room => {
    return Promise.all([
      this.getListPatient(room),
      this.getListPatientPriority(room),
      this.getResultCLSInRoom(room),
      this.getCurrentPatientRoom(room),
    ]);
  };

  getThuocBHYT = ({ code, type }) => {
    return this.request.post('api/Register/queue/result', {
      limit: 3,
      room: code,
      type,
      date: formDateTime(),
    });
  };

  getTableBHYT = id => this.request.get('api/Table/' + id);

  static validatePromiseAllReponse(response) {
    const listStatus = response.map(({ status }) => status);
    return listStatus.every(stat => stat === 200);
  }

  static formatReponsePromiseAll(response) {
    return response.map(res => get(res, 'data.result'));
  }

  getGroups = () => this.request.get('/api/Group');

  getDeptInGroups = (groupCode = '') =>
    this.request.get(`/api/DepartmentService/departments/${groupCode}`);

  getDeptNameEndo = (deptCodes = []) =>
    this.request.post('/api/Department/change-department-name', deptCodes);

  getNumberRoomEndoscopy = (listRoom = []) => {
    return this.request.post(
      '/api/Register/multi/departments/endoscopic',
      listRoom,
    );
  };
}

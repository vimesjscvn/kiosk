/* eslint-disable no-plusplus */
/* eslint-disable no-param-reassign */
/* eslint-disable arrow-body-style */
/* eslint-disable no-duplicate-case */
/* eslint-disable consistent-return */
/* eslint-disable func-names */
/* eslint-disable no-unused-vars */
/* eslint-disable no-unused-expressions */
/* eslint-disable array-callback-return */
/* eslint-disable no-case-declarations */
/* eslint-disable no-undef */
/* eslint-disable prettier/prettier */
/* eslint-disable default-case */
/* eslint-disable no-useless-return */
import _, { isEmpty, sortBy, orderBy } from 'lodash';
import { keyframes } from 'styled-components';
import { AppConfig } from 'public/appConfig';
import moment from 'moment';

export const TextGlow = keyframes`
 {
  0%, 50%, 100% {
    opacity: 1;
  }
  25%, 75% {
    opacity: 0.5;
  }
`;

export const getUnique = (arr, comp) => {
  const unique = arr
    .map(e => e[comp])
    .map((e, i, final) => final.indexOf(e) === i && i)
    .filter(e => arr[e])
    .map(e => arr[e]);
  return unique;
};

export const DEFAULT_COLOR = '#0e2157';

export const PRIORITY_COLOR = '#ff0000';

export const NORMAL_COLOR = '#34458b';

export function comparer(otherArray) {
  return function (current) {
    return (
      otherArray.filter(function (other) {
        return (
          other.table.code === current.table.code && other.from === current.from
        );
      }).length === 0
    );
  };
}

export const TypesStart = Object.freeze({
  HOME: 0,
  TNB: 1,
  ROOM: 2,
  THUOCBHYT: 3,
  ROOM_CLS: 4,
  CPS: 5,
  CLS: 6,
  NOISOI: 7,
  SIEUAM: 8,
  XQUANG: 9,
});

export const TypesStartEmum = Object.freeze({
  TNB: 'TNB',
  ROOM: 'ROOM',
  ROOM_CLS: 'ROOM_CLS',
  THUOCBHYT: 'THUOCBHYT',
  CPS: 'CPS',
  CLS: 'CLS',
  NOISOI: 'NOISOI',
  SIEUAM: 'SIEUAM',
  XQUANG: 'XQUANG',
});

export const DeviceEmum = Object.freeze({
  LCD_TNB: 'LCD.TNB',
  LCD_ROOM: 'LCD.ROOM',
  LCD_ROOM_CLS: 'LCD.ROOM_CLS',
  LCD_THUOCBHYT: 'LCD.THUOCBHYT',
  LCD_CPS: 'LCD.CPS',
  LCD_CLS: 'LCD.CLS',
  LCD_NOISOI: 'LCD.NOISOI',
  LCD_SIEUAM: 'LCD.SIEUAM',
  LCD_XQUANG: 'LCD.XQUANG',
});

export const ROUTING = Object.freeze({
  HOME: '/',
  TNB: '/tiep-nhan-benh',
  ROOM: '/phong-kham',
  ROOM_CLS: '/phong-cls',
  THUOCBHYT: '/thuoc',
  CPS: '/cps',
  CLS: '/ketqua-cls',
  NOISOI: '/goi-cls',
  SETTING: '/setting',
});

export const DOCTOR_KEY = '_doctor_name';
export const TYPE_START_KEY = '_type_start';
export const ROOM = '_room';
export const ROOM_CLS = '_room_cls';
export const ROOM_ENDSCOPY = '_room_endscopy';
export const GROUP_KEY = '_group';

export const typesList = [
  { value: TypesStart.HOME, label: '' },
  { value: TypesStart.TNB, label: 'Tiếp Đón' },
  // { value: TypesStart.ROOM, label: 'Phòng khám' },
  { value: TypesStart.ROOM_CLS, label: 'Phòng khám/cận lâm sàng' },
  // { value: TypesStart.NOISOI, label: 'Gọi cận lâm sàng' },
  { value: TypesStart.CPS, label: 'Màn hình hiển thị trung tâm CPS' },
  // { value: TypesStart.CLS, label: 'Kết Quả cận lâm sàng' },
  // { value: TypesStart.THUOCBHYT, label: 'Nhận thuốc BHYT' },
];

export const CPSList = [{ value: 'TNB', label: 'CPS' }];

/**
 * @@ Reduce Selection Options With TypesStart
 * @param typeStart: TypesStart, setListOption: HookState
 * @void
 */
export function reduceTypeStart(
  typeStart,
  setListOption,
  listRoom,
  listTable,
  depts,
) {
  console.log(typeStart);
  const options = [];
  switch (typeStart) {
    case TypesStart.TNB:
      console.log(listTable);
      listTable &&
        getUnique(
          listTable.filter(tableItem => {
            return (
              tableItem.device === DeviceEmum.LCD_TNB
            );
          }),
          'code',
        ).map(tableItem => {
          options.push({
            value: tableItem.code,
            label: `${tableItem.name}`,
            display: tableItem.code,
            department_code: tableItem.department_code,
          });
          const sortOptions = orderBy(options, 'value', 'asc');
          setListOption(sortOptions);
        });
      break;
    case TypesStart.ROOM:
      listRoom &&
        getUnique(listRoom, 'id').map(room => {
          options.push({
            displayOrder: room.display_order,
            dpVid: room.department_virtual_id,
            value: room.id,
            label: (room.description || '').includes(room.id)
              ? room.description
              : `${room.description}`,
          });
          setListOption(options);
        });
      break;
    case TypesStart.CLS:
      listRoom &&
        getUnique(
          listRoom.filter(tableItem => tableItem.code !== TypesStartEmum.TNB),
          'code',
        ).map(room => {
          options.push({
            value: room.code,
            label: (room.description || '').includes(room.code)
              ? room.description
              : `${room.description} - ${room.code}`,
          });
          setListOption(options);
        });
      break;
    case TypesStart.THUOCBHYT:
      listTable &&
        getUnique(
          listTable.filter(
            tableItem => tableItem.department_code === TypesStartEmum.THUOCBHYT,
          ),
          'code',
        ).map(tableItem => {
          options.push({
            value: tableItem.code,
            label: `${tableItem.name}`,
          });
          setListOption(orderBy(options, 'value'));
        });
      break;
    case TypesStart.TATTOAN:
      listTable &&
        getUnique(
          listTable.filter(
            tableItem => tableItem.department_code === TypesStartEmum.TATTOAN,
          ),
          'code',
        ).map(tableItem => {
          options.push({
            value: tableItem.code,
            label: `${tableItem.name}`,
          });
          setListOption(options);
        });
      break;
    case TypesStart.CPS:
      listTable &&
        getUnique(
          listTable.filter(tableItem => {
            return (
              tableItem.device === DeviceEmum.LCD_CPS
            );
          }),
          'code',
        ).map(tableItem => {
          options.push({
            value: tableItem.code,
            label: `${tableItem.name}`,
            display: tableItem.code,
            department_code: tableItem.department_code,
          });
          const sortOptions = orderBy(options, 'value', 'asc');
          setListOption(sortOptions);
        });
      break;
    case TypesStart.ROOM_CLS:
      setListOption(depts);
      break;
    case TypesStart.NOISOI:
      setListOption(listTable);
      break;
    default:
      break;
  }
}

export function reduceOptions(device, listRoom, tables) {
  switch (device.type) {
    case TypesStart.TNB:
    case TypesStart.THUOCBHYT:
      return tables.find(tab => tab.code === device.code);
    case TypesStart.ROOM:
    case TypesStart.CLS:
      return listRoom.find(rom => rom.code === device.id);
    case TypesStart.CPS:
      return CPSEyesList.find(rom => rom.code === device.code);
  }
}

export function reducerLabel(type, item) {
  switch (type) {
    case TypesStart.TNB:
    case TypesStart.THUOCBHYT:
      return item.name;
    case TypesStart.ROOM:
    case TypesStart.CLS:
      return `${item.description} - ${item.code}`;
    case TypesStart.CPS:
      return item.label;
    default:
      return item.code;
  }
}

export function number2Digits(number) {
  if (number < 100) {
    return `0${number}`.slice(-2);
  }
  return number;
}

export function setPatientType(patient) {
  if (isEmpty(patient)) return '';
  if (+patient.type <= 0) {
    return 'THƯỜNG';
  }
  return 'ƯU TIÊN';
}

export function setPatientNumber(patient) {
  const outData = {
    from: 0,
    to: 0,
  };
  if (isEmpty(patient)) {
    return outData;
  }
  const { from, to } = patient;
  if (to && +to < 0) {
    return {
      ...outData,
      to: 0,
    };
  }
  if (from && +from < 0) {
    return {
      ...outData,
      from: 0,
    };
  }
  return {
    from,
    to,
  };
}

export function setPatientColor(patient) {
  if (isEmpty(patient)) return NORMAL_COLOR;
  if (+patient.type <= 0) {
    return NORMAL_COLOR;
  }
  return PRIORITY_COLOR;
}

export function formatBodyEyesRequest(tables) {
  return tables.map(table => new EyeRequestModel(table));
}

export function comparePatientNumber(newPatient, oldPatient) {
  if (isEmpty(oldPatient) || isEmpty(newPatient)) return false;
  if (oldPatient.to !== newPatient.to || oldPatient.from !== newPatient.from) {
    return true;
  }
  return false;
}

export function getCurrentDate() {
  const currentDate = new Date();
  const currentYear = currentDate.getFullYear();
  const currentMonth = currentDate.getMonth();
  const currentDay = currentDate.getDate();
  return `${currentYear}-${currentMonth}-${currentDay}`;
}

export function linkAudio(url) {
  return `${AppConfig.END_POINT}/${url}`;
}

export function formatName2Digits(name, takeWhile = []) {
  if (typeof name !== 'string') return name;
  if (takeWhile.length) {
    const start = takeWhile[0] ? name.lastIndexOf(takeWhile[0]) : 0;
    const end = takeWhile[1] ? name.lastIndexOf(takeWhile[1]) : name.length;
    return number2Digits(name.slice(start + 1, end));
  }
  return number2Digits(formatCode(name));
}

export function getNameLastPatients(lastLatients) {
  if (_.isEmpty(lastLatients) && !lastLatients.length) return '-';
  const fullName = lastLatients[0] ? lastLatients[0].name : '-';
  const age = lastLatients[0] ? `/ ${lastLatients[0].age} tuổi` : '-';
  const gender = lastLatients[0]
    ? PatientHelper.setGender(lastLatients[0].gender)
    : '-';
  return { fullName, age, gender };
}

export class PatientHelper {
  static setPatientColor(patient) {
    if (isEmpty(patient)) return NORMAL_COLOR;
    if (+patient.type === 1) return PRIORITY_COLOR;
    return NORMAL_COLOR;
  }

  static setPatientType(patient) {
    if (isEmpty(patient)) return '';
    if (+patient.type === 1) return 'ƯU TIÊN';
    return 'THƯỜNG';
  }

  static formatRoomTitle(title) {
    if (title.length <= 3) return title.toUpperCase();
    return title.slice(title.length - 3, title.length).toUpperCase();
  }

  static setPatientGender(patient) {
    return patient.gender ? 'Nam' : 'Nữ';
  }

  static setGender(type) {
    if (type === null || type < 0 || type > 1) return '-';
    if (type === 1) {
      return 'Nam';
    }
    if (type === 0) {
      return 'Nữ';
    }
  }

  static renderTime(time) {
    if (!time) return time;
    return moment(new Date(time)).format('DD/MM/YYYY HH:mm');
  }
}

export function MultiRoomCallModel(table) {
  this.department_code = table.id;
  this.limit = 1;
  this.date = new Date();
}

export function formatCallNumber(tables) {
  return tables.map(table => new MultiRoomCallModel(table));
}

export function nonAccentVietnamese(str = '') {
  if (str === '') return str;
  str = str.toLowerCase();
  // str = str.replace(/\u00E0|\u00E1|\u1EA1|\u1EA3|\u00E3|\u00E2|\u1EA7|\u1EA5|\u1EAD|\u1EA9|\u1EAB|\u0103|\u1EB1|\u1EAF|\u1EB7|\u1EB3|\u1EB5/g, "a");
  // str = str.replace(/\u00E8|\u00E9|\u1EB9|\u1EBB|\u1EBD|\u00EA|\u1EC1|\u1EBF|\u1EC7|\u1EC3|\u1EC5/g, "e");
  // str = str.replace(/\u00EC|\u00ED|\u1ECB|\u1EC9|\u0129/g, "i");
  // str = str.replace(/\u00F2|\u00F3|\u1ECD|\u1ECF|\u00F5|\u00F4|\u1ED3|\u1ED1|\u1ED9|\u1ED5|\u1ED7|\u01A1|\u1EDD|\u1EDB|\u1EE3|\u1EDF|\u1EE1/g, "o");
  // str = str.replace(/\u00F9|\u00FA|\u1EE5|\u1EE7|\u0169|\u01B0|\u1EEB|\u1EE9|\u1EF1|\u1EED|\u1EEF/g, "u");
  // str = str.replace(/\u1EF3|\u00FD|\u1EF5|\u1EF7|\u1EF9/g, "y");
  // str = str.replace(/\u0111/g, "d");
  str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, 'a');
  str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, 'e');
  str = str.replace(/ì|í|ị|ỉ|ĩ/g, 'i');
  str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, 'o');
  str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, 'u');
  str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, 'y');
  str = str.replace(/đ/g, 'd');
  str = str.replace(/\u0300|\u0301|\u0303|\u0309|\u0323/g, ''); // Huyền sắc hỏi ngã nặng
  str = str.replace(/\u02C6|\u0306|\u031B/g, ''); // Â, Ê, Ă, Ơ, Ư
  return str;
}

export function searchVNEntity(multi = '', keyword = '') {
  return nonAccentVietnamese(multi).indexOf(nonAccentVietnamese(keyword));
}

const keysRooms = [
  'x quang',
  'sieu am',
  'noi soi',
  'xquang',
  'sieuam',
  'KQ.CLS',
  'P142',
];
export function DeptWithOutGroup(rooms = []) {
  if (!rooms || !rooms.length) return [];
  const filterRooms = rooms.filter(room => {
    const searchs = keysRooms.map(keySearch =>
      searchVNEntity(room.description, keySearch),
    );
    return searchs.every(searchNumber => searchNumber < 0);
  });
  return filterRooms;
}

export function DeptWithGroup(rooms = []) {
  if (!rooms || !rooms.length) return [];
  const filterRooms = rooms.filter(room => {
    const searchs = keysRooms.map(description =>
      searchVNEntity(room.description, description),
    );
    return searchs.some(searchNumber => searchNumber > 0);
  });
  return filterRooms;
}

export const INIT_REG = {
  NOISOI: {
    CODE: 'NOISOI',
    NAME: 'Nội soi',
    TITLE: 'BỆNH NHÂN ĐÃ GỌI',
  },
  SIEUAM: {
    CODE: 'SIEUAM',
    NAME: 'siêu âm',
    TITLE: 'BỆNH NHÂN CHUẨN BỊ',
  },
};

export function setRoomRender(room = {}) {
  if (!room || _.isEmpty(room) || room.description === '') return '';
  if (searchVNEntity(room.description, INIT_REG.NOISOI.NAME) >= 0) {
    return INIT_REG.NOISOI;
  }
  return INIT_REG.SIEUAM;
}

export function createPlaceWaiting(items = []) {
  if (!items.length) return [];
  const numbersSlides = items.length;
  let expandSlides = numbersSlides % 5;
  if (!expandSlides) return items;
  while (expandSlides < 5) {
    items.push({});
    expandSlides++;
  }
  return items;
}

/* eslint-disable prefer-const */
/* eslint-disable arrow-body-style */
/* eslint-disable no-plusplus */
export const PatientNameList = [
  'Trường An',
  'Vương Ðình Sang',
  'Liễu Hòa Bình',
  'Phạm Quốc Minh',
  'Đỗ Minh Thái',
  'Bùi Gia Hưng',
  'Lý Anh Tú',
  'Mã Cao Tiến',
  'Hàn Hữu Trung',
  'Nguyễn Tuấn Việt',
  'Nguyễn Anh Duy',
  'Châu Ðức Thọ',
  'Nguyễn Thuận Thành',
  'Võ Phước Sơn',
  'Lý Vĩnh Luân',
  'Lạc Nguyên Lộc',
  'Võ Tấn Trương',
  'Phí Tất Hiếu',
  'Nguyễn Minh Cảnh',
  'Dương Quang Trung',
  'Lục Ðức Khang',
  'Bành Xuân Thái',
  'Ngô Hữu Hiệp',
  'Võ Thiện Minh',
  'Huỳnh Nhật Huy',
  'Đặng Như Bảo',
  'Bùi Kim Loan',
  'Bùi Mai Ly',
  'Lê Bảo Lan',
  'Nguyễn Hồng Oanh',
  'Hoàng Bích Hải',
  'Trương Thu Huyền',
  'Lê Hồng Vân',
  'Nguyễn Cẩm Tú',
  'Ngô Bích San',
  'Ngô Ngọc Tuấn',
  'Kim Quang Triệu',
  'Đặng Viết Sơn',
  'La Tuấn Linh',
  'Nguyễn Minh Chiến',
];

export const NUMBER_MOCK_PATIENT = 654;

function CLSResult(idx) {
  this.full_name = PatientNameList[idx];
  this.patient_code = '203079830' + idx;
  this.registered_code = '203106067';
  this.result_date = '5/28/2021 1:59:12 PM';
  this.age = Math.floor(Math.random() * 60);
  this.gender = Math.floor(Math.random() * 1) ? 'Nam' : 'Nữ';
  this.isNew = !idx;
}
export class DataManagement {
  listPatient = [];

  static generatePatientList = (start, length) => {
    for (let number = start + 1; number <= length; number++) {
      this.listPatient.push({
        name: PatientNameList[number],
        number,
        age: Math.round(Math.random()) + number,
        gender: Math.round(Math.random()),
      });
    }
    return this;
  };

  static generateCLSResult = length => {
    let result = [];
    for (let i = 0; i <= length; i++) {
      if (i < 10) {
        result.push(new CLSResult(i));
      } else {
        result.push(new CLSResult(i.toString().slice(-1)));
      }
    }
    return result;
  };
}

export class DataResponse {
  static responseResultCLS = () => {
    return new Promise((resolve, reject) => {
      return resolve({
        data: {
          result: DataManagement.generateCLSResult(30),
        },
        ok: true,
      });
    });
  };
}

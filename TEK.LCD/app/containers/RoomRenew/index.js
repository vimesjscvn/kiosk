/* eslint-disable react/no-unescaped-entities */
/* eslint-disable consistent-return */
/* eslint-disable react/no-array-index-key */
/* eslint-disable indent */
/* eslint-disable react/no-unused-prop-types */
/* eslint-disable no-undef */
/* eslint-disable import/order */
/* eslint-disable no-shadow */
/* eslint-disable camelcase */
/* eslint-disable react/jsx-boolean-value */
/* eslint-disable react/jsx-curly-brace-presence */
/* eslint-disable jsx-a11y/click-events-have-key-events */
/* eslint-disable jsx-a11y/no-static-element-interactions */
/* eslint-disable no-restricted-globals */
/* eslint-disable jsx-a11y/media-has-caption */
/* eslint-disable global-require */
/* eslint-disable jsx-a11y/alt-text */
/* eslint-disable no-unused-vars */
import React, { memo, useEffect, useState, useRef } from 'react';
import * as Util from '../../utils/Function';
import * as Global from 'containers/App/selectors';
import * as appActions from 'containers/App/actions';
import * as _ from 'lodash';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer } from 'utils/injectReducer';
import { useInjectSaga } from 'utils/injectSaga';
import { AppContainer } from 'components/AppContainer';
import { Main } from 'components/Main';
import { AppConfig } from '../../public/appConfig';
import { Patient } from './Patient';
import appReducer, { key } from 'containers/App/reducer';
import DateTimeWeather from 'components/DateTimeWeather';
import appSaga from 'containers/App/saga';
import propTypes from 'prop-types';
import ReactPlayer from 'react-player';
import styled from 'styled-components';
import logo from '../../images/logo-wrap.jpg';
import LoadingIndicator from 'components/LoadingIndicator';

const PNCDContent = styled.div`
  height: 85%;
  display: flex;
`;

const WrapLogo = styled.div``;
const WrapLogoImg = styled.img`
  width: 200px;
  height: 50px;
`;
const PNCDBanner = styled.div`
  height: 15%;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
  padding: 0 20px;
`;
const PNCDTitle = styled.p`
  font-size: 2rem;
  font-weight: bold;
  color: #33478d;
  cursor: pointer;
`;
const PNCDDateTime = styled.div``;
const TextDay = styled.h1`
  color: black;
  font-size: 15px;
  font-weight: 500;
  text-align: center;
  text-transform: capitalize;
`;
const TextHour = styled.h1`
  font-size: 10px;
  font-weight: bold;
  text-align: center;
  @media (min-width: 800px) {
    font-size: 45px;
  }
  @media (min-width: 800px) and (min-height: 600px) {
    font-size: 25px;
  }
`;
const PNCDCol1 = styled.div`
  width: calc(100% / 2);
  border-right: 1px solid #000;
`;
const PNCDCol2 = styled.div`
  width: calc(100% / 2);
  border-right: 1px solid #000;
`;
const PNCDCol3 = styled.div`
  width: calc(100% / 2);
  border-right: 1px solid #000;
`;

const PNCDNumberNote = styled.div`
  text-align: center;
  font-size: 12px;
  @media (min-width: 1336px) and (min-height: 768px) {
    font-size: 12px;
  }
`;

const PNCDPatientList = styled.div`
  height: 90%;
  border-bottom: ${props => (!props.isBorder ? '1px solid #000' : 'none')};
  > div {
    height: ${props => (props.rows ? 100 / props.rows + '%' : '20%')};
    overflow: hidden;
    width: 100%;
    display: flex;
    align-items: center;
    border-bottom: 1px solid #000;
  }
`;

const PNCDWaitTitle = styled.div`
  height: 10%;
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: ${props => (props.color ? props.color : 'red')};
`;

const Content = styled.div`
  height: 100%;
  width: 100vw;
  display: flex;
`;

const PatientWrapCLS = styled.div`
  height: 50%;
  display: block;
  border-top: 1px solid #000;
`;

const PatientWrapCLSContain = styled.div`
  height: 90%;
  display: flex;
`;

const PatientList = styled.div`
  height: 100%;
  border-bottom: ${props => (!props.isBorder ? '1px solid #000' : 'none')};
  > div {
    height: ${props => (props.rows ? 100 / props.rows + '%' : '20%')};
    overflow: hidden;
    width: 100%;
    display: flex;
    align-items: center;
    border-bottom: 1px solid #000;
  }
`;

const VideoWrap = styled.div`
  height: 50%;
  padding: 2px;
  border-bottom: 1px solid #000;
`;

const PatientNumber = styled.div`
  height: ${props => (props.depType === 'NPCD' ? '45%' : '50%')};
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: ${props =>
    props.depType === 'NPCD' ? 'center' : 'space-around'};
  position: relative;
  border-top: 1px solid #000;
  border-bottom: 1px solid #000;
`;

const PatientPriority = styled.div`
  height: 45%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  position: relative;
  border-top: 1px solid #000;
  border-bottom: 1px solid #000;
`;

const PatientNumberCLS = styled.div`
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-around;
  position: relative;
  border-top: 1px solid #000;
`;

const NumberTo = styled.div`
  text-transform: uppercase;
  font-size: 15px;
  font-weight: bold;
  @media (min-width: 1336px) and (min-height: 768px) {
    font-size: 15px;
  }
`;

function renderNumberSize(number) {
  if (number >= 1000) return '10em';
  if (number >= 100) return '14em';
  if (number < 100) return '11em';
}

function renderNumberResponse(number) {
  if (number >= 1000) return '4em';
  if (number >= 100) return '7em';
  if (number < 100) return '10em';
}

const NumberNow = styled.div`
  font-size: ${props => renderNumberSize(props.number)};
  font-weight: bold;
  color: ${props => (props.color ? props.color : 'red')};
  margin: -25px;
  @media (min-width: 1336px) and (min-height: 768px) {
    font-size: ${props => renderNumberResponse(props.number)};
    margin: -25px;
  }
`;

const NumberNowPro = styled.div`
  font-size: 12em;
  font-weight: bold;
  color: red;
  margin: -10px;
`;

const NameNote = styled.div`
  font-size: 1em;
  text-transform: uppercase;
  text-align: center;
  margin: 0;
  padding: 0;
  color: ${props => (props.color ? props.color : 'red')};
  > p {
    font-size: 15px;
    font-weight: bold;
    margin: 0;
    padding: 0;
    text-transform: none;
  }
  @media (min-width: 1336px) and (min-height: 768px) {
    font-size: 20px;
    > p {
      font-size: 15px;
    }
  }
`;

const NumberNote = styled.div`
  text-align: center;
  font-size: 13px;
  @media (min-width: 1336px) and (min-height: 768px) {
    font-size: 15px;
  }
`;

const Note = styled.div`
  position: absolute;
  bottom: 10px;
  right: 30px;
`;

const RowCol1 = styled.div`
  width: 25vw;
  display: flex;
  flex-direction: column;
`;
const RowCol2 = styled.div`
  width: 25vw;
  border-right: 1px solid #000;
`;
const RowCol3 = styled.div`
  width: 50vw;
  display: flex;
  flex-direction: column;
  border-right: 1px solid #000;
`;

const PatientWaitTitle = styled.div`
  border-bottom: 1px solid black;
  height: 5%;
  display: ${props => (props.depType === 'NPCD' ? 'flex' : 'none')};
  justify-content: space-around;
  align-items: center;
  background-color: ${props => (props.color ? props.color : 'red')};
  color: white;
  font-size: 1em;
  font-weight: bold;
  text-transform: uppercase;
`;

const PatientListSmall = styled.div`
  border-right: 1px solid black;
  border-bottom: 1px solid black;
  width: 50%;
  display: flex;
  flex-direction: column;
`;

const PreparedTitle = styled.div`
  height: 10%;
  display: flex;
  justify-content: center;
  align-items: center;
  margin: 0;
  font-weight: bold;
  color: white;
  background-color: ${props => (props.color ? props.color : 'red')};
  font-size: 1.2em;
`;

const PreparedList = styled.div`
  height: 90%;
`;

const PreparedTitlePriority = styled.div`
  height: 10%;
  margin: 0;
  font-weight: bold;
  color: white;
  background: red;
  font-size: 1.2em;
  display: flex;
  justify-content: center;
  align-items: center;
  border-bottom: 1px solid #000;
`;

const PatientBox = styled.div`
  height: 50%;
  display: flex;
  flex-direction: column;
`;

const RoomTitle = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  text-align: center;
  background: #33478d;
  border: 1px solid #000;
  height: calc(95vh / 2);
`;

const WaitTitle = styled.div`
  padding: 10px 0;
  width: 100%;
  display: flex;
  background-color: ${props => (props.color ? props.color : 'red')};
`;

const WaitPreparedTitle = styled.div`
  font-weight: bold;
  color: white;
  font-size: 1.2em;
  padding-left: 10px;
  width: ${props => props.width};
`;

const WaitPreparedNumber = styled.div`
  font-weight: bold;
  color: white;
  font-size: 1.2em;
  width: ${props => props.width};
  text-align: ${props => props.center};
  border-left: 1px solid white;
`;

const PatientsWait = styled.div`
  display: block;
  flex: 1;
`;

const RoomTitleText = styled.div`
  height: 100%;
  margin: 0;
  align-items: center;
  justify-content: center;
  display: flex;
  overflow: hidden;
  position: relative;
  background: transparent;
  color: black;
  cursor: pointer;
`;

const RoomValueContain = styled.div`
  padding: 0 10px;
  > p {
    color: white;
    font-weight: bold;
  }
`;

const RoomValueTitle = styled.p`
  line-height: 1.5;
  font-size: 1.5rem;
`;

RoomRenew.propTypes = {
  currentPatients: propTypes.any,
  temperature: propTypes.number,
  listRoom: propTypes.any,
  device: propTypes.any,
  history: propTypes.any,
  system: propTypes.object,
  changeDeviceType: propTypes.func,
  getPatientInRoom: propTypes.func,
};

export function RoomRenew({
  currentPatients,
  listRoom,
  device,
  temperature,
  ...props
}) {
  useInjectReducer({ key, reducer: appReducer });
  useInjectSaga({ key, saga: appSaga });
  const [room, setRoom] = useState(null);
  const roomRef = useRef(null);
  const [currentTime, setCurrentTime] = useState(null);
  useEffect(() => {
    if (!_.isEmpty(listRoom) && listRoom.length && !_.isEmpty(device)) {
      const currentRoom = listRoom.find(
        roomItem => roomItem.code === device.code,
      );
      if (currentRoom) {
        setRoom(currentRoom);
      }
    }
  }, [listRoom, device]);

  useEffect(() => {
    if (!_.isEmpty(room)) {
      props.getPatientInRoom(room.code);
      roomRef.current = setInterval(
        () => {
          props.getPatientInRoom(room.code);
        },
        process.env.NODE_ENV !== 'development' ? AppConfig.ROOM_TIMER : 20000,
      );
    }
    return () => {
      if (roomRef.current) {
        clearInterval(roomRef.current);
      }
    };
  }, [room]);

  const redirect = () => {
    props.history.push('/');
    props.changeDeviceType(0);
  };

  const renderNumber = () => {
    if (_.isEmpty(currentPatients) || _.isEmpty(currentPatients[3])) {
      return {
        normal: 0,
        priority: 0,
      };
    }
    return {
      normal: _.get(currentPatients[3], 'normal_number'),
      normalName: _.get(currentPatients[3], 'normal_name'),
      normalAge: _.get(currentPatients[3], 'normal_age'),
      normalSex: _.get(currentPatients[3], 'normal_sex'),
      priority: _.get(currentPatients[3], 'priority_number'),
      priorityName: _.get(currentPatients[3], 'priority_name'),
      priorityAge: _.get(currentPatients[3], 'priority_age'),
      prioritySex: _.get(currentPatients[3], 'priority_sex'),
    };
  };
  useEffect(() => {
    const timer = setInterval(() => {
      setCurrentTime(Util.getCurrentTime());
    }, 1000);
    return () => {
      clearInterval(timer);
    };
  }, []);
  if (_.isEmpty(currentTime)) return <LoadingIndicator />;
  return (
    <AppContainer>
      {!_.isEmpty(room) && room.department_type === 'NPCD' ? (
        <Main>
          <PNCDBanner>
            <WrapLogo>
              <WrapLogoImg src={logo} />
            </WrapLogo>
            <PNCDTitle onClick={redirect}>
              {!_.isEmpty(room) && room.description.toUpperCase()}
            </PNCDTitle>
            <PNCDDateTime>
              <TextDay>
                {Util.dayName} Ngày {Util.day} tháng {Util.month} năm{' '}
                {Util.year}
              </TextDay>
              <TextHour>{currentTime}</TextHour>
            </PNCDDateTime>
          </PNCDBanner>
          <PNCDContent>
            <PNCDCol1>
              <PatientWaitTitle
                color="black"
                depType={!_.isEmpty(room) && room.department_type}
              >
                NGƯỜI BỆNH THƯỜNG
              </PatientWaitTitle>
              <PatientNumber depType={!_.isEmpty(room) && room.department_type}>
                <NumberTo>Đã khám đến số thứ tự</NumberTo>
                <PNCDNumberNote>
                  Người bệnh có số thứ tự thấp hơn số thứ tự{' '}
                  {renderNumber().normal} được quyền vào khám
                </PNCDNumberNote>

                <NumberNow color="black" number={renderNumber().normal}>
                  {renderNumber().normal}
                </NumberNow>
                <NameNote color="black">
                  {renderNumber().normalName}
                  <p>
                    {renderNumber().normalSex} / {renderNumber().normalAge} tuổi
                  </p>
                </NameNote>
              </PatientNumber>
              <PatientBox depType={!_.isEmpty(room) && room.department_type}>
                <PNCDWaitTitle color="black">
                  <WaitPreparedTitle width="80%">
                    NGƯỜI BỆNH CHUẨN BỊ
                  </WaitPreparedTitle>
                  <WaitPreparedNumber width="20%" center="center">
                    STT
                  </WaitPreparedNumber>
                </PNCDWaitTitle>
                {!_.isEmpty(currentPatients) &&
                _.first(currentPatients).length ? (
                  <PNCDPatientList rows="2">
                    {_.orderBy(_.first(currentPatients), 'queue_number').map(
                      (patient, idx) => (
                        <Patient key={idx} {...patient} colorType={'black'} />
                      ),
                    )}
                  </PNCDPatientList>
                ) : (
                  <PNCDPatientList />
                )}
              </PatientBox>
            </PNCDCol1>
            <PNCDCol3>
              <PatientWaitTitle
                color="#33478d"
                depType={!_.isEmpty(room) && room.department_type}
              >
                Đọc kết quả cận lâm sàng
              </PatientWaitTitle>
              <PatientPriority>
                <NumberTo>Kết quả cận lâm sàng</NumberTo>
                <NumberNow color="#33478d" number={renderNumber().normal}>
                  {!_.isEmpty(currentPatients) && !_.isEmpty(currentPatients[2])
                    ? currentPatients[2].current_number
                    : 0}
                </NumberNow>
                <NumberNote>
                  Người bệnh có số thứ tự thấp hơn số thứ tự{' '}
                  {!_.isEmpty(currentPatients) && !_.isEmpty(currentPatients[2])
                    ? currentPatients[2].current_number
                    : 0}{' '}
                  được quyền vào khám
                </NumberNote>
              </PatientPriority>
              <PatientBox depType={!_.isEmpty(room) && room.department_type}>
                <PNCDWaitTitle color="#33478d">
                  <WaitPreparedTitle width="80%">
                    NGƯỜI BỆNH CHUẨN BỊ
                  </WaitPreparedTitle>
                  <WaitPreparedNumber width="20%" center="center">
                    STT
                  </WaitPreparedNumber>
                </PNCDWaitTitle>
                {!_.isEmpty(currentPatients) &&
                !_.isEmpty(currentPatients[2]) ? (
                  <PNCDPatientList rows="2">
                    {_.orderBy(
                      currentPatients[2].in_queue_patients,
                      'queue_number',
                    ).map((patient, idx) => (
                      <Patient key={idx} {...patient} colorType={'#33478d'} />
                    ))}
                  </PNCDPatientList>
                ) : (
                  <PNCDPatientList />
                )}
              </PatientBox>
            </PNCDCol3>
          </PNCDContent>
        </Main>
      ) : (
        <Main>
          <Content>
            <RowCol1>
              <RoomTitle>
                <RoomTitleText onClick={redirect}>
                  <RoomValueContain className="scroll-left-room">
                    <RoomValueTitle>
                      {!_.isEmpty(room) && room.description.toUpperCase()}
                    </RoomValueTitle>
                  </RoomValueContain>
                </RoomTitleText>
              </RoomTitle>
              <DateTimeWeather />
            </RowCol1>
            <RowCol2>
              <PatientWaitTitle
                color="black"
                depType={!_.isEmpty(room) && room.department_type}
              >
                NGƯỜI BỆNH THƯỜNG
              </PatientWaitTitle>
              <PatientNumber depType={!_.isEmpty(room) && room.department_type}>
                <NumberTo>Đã khám tới số thứ tự</NumberTo>
                <NumberNow color="black" number={renderNumber().normal}>
                  {renderNumber().normal}
                </NumberNow>
                <NumberNote>
                  Người bệnh có số thứ tự thấp hơn số thứ tự{' '}
                  {renderNumber().normal} được quyền vào khám
                </NumberNote>
              </PatientNumber>
              <PatientBox depType={!_.isEmpty(room) && room.department_type}>
                <PreparedTitle color="black">NGƯỜI BỆNH CHUẨN BỊ</PreparedTitle>
                <PreparedList>
                  {!_.isEmpty(currentPatients) &&
                  _.first(currentPatients).length ? (
                    <PatientList rows="3">
                      {_.orderBy(_.first(currentPatients), 'queue_number').map(
                        (patient, idx) => (
                          <Patient key={idx} {...patient} colorType={'black'} />
                        ),
                      )}
                    </PatientList>
                  ) : (
                    <PatientList />
                  )}
                </PreparedList>
              </PatientBox>
            </RowCol2>
            <RowCol3>
              <ReactPlayer
                loop={true}
                playing={true}
                url={AppConfig.URL_VIDEO}
                style={{
                  width: '100%',
                  height: '100%',
                }}
                muted
                height="100%"
              />
            </RowCol3>
          </Content>
        </Main>
      )}
    </AppContainer>
  );
}

const mapStateToProps = createStructuredSelector({
  temperature: Global.selectTemperature(),
  currentPatients: Global.selectCurrentPatient(),
  fetching: Global.selectLoading(),
  listRoom: Global.selectListRoom(),
  device: Global.selectDeviceSetting(),
  system: Global.selectSystemSetting(),
  router: Global.selectRouter(),
});

export function mapDispatchToProps(dispatch) {
  return {
    changeDeviceType: () => dispatch(appActions.changeDeviceType(0)),
    getPatientInRoom: payload =>
      dispatch(appActions.getCurrentPatientInRoom(payload)),
  };
}

const withConnect = connect(
  mapStateToProps,
  mapDispatchToProps,
);

export default compose(
  withConnect,
  memo,
)(RoomRenew);

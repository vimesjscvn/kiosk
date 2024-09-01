/* eslint-disable consistent-return */
/* eslint-disable no-nested-ternary */
/* eslint-disable indent */
/* eslint-disable react/no-array-index-key */
import React, { memo, useEffect, useState, useRef } from 'react';
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
import LoadingIndicator from 'components/LoadingIndicator';
import appReducer, { key } from 'containers/App/reducer';
import appSaga from 'containers/App/saga';
import propTypes from 'prop-types';
import styled, { keyframes } from 'styled-components';
import ReactAudioPlayer from 'react-audio-player';
import * as Util from '../../utils/Function';
import { Patient } from './Patient';
import { AppConfig } from '../../public/appConfig';
import { ScrollText } from '../../components/ScrollText';
import { ROOM_CLS, PatientHelper, INIT_REG, linkAudio } from '../App/helper';

const Content = styled.div`
  height: 100%;
  width: 100%;
  text-transform: uppercase;
`;

const HeaderBaner = styled.div`
  height: 15%;
  width: 100%;
  display: flex;
  align-items: center;
  padding: 0 10px;
`;

const DateTimer = styled.div`
  width: 20%;
  display: flex;
  align-items: center;
`;

const TextDay = styled.span`
  color: black;
  font-size: 15px;
  font-weight: 500;
  text-transform: capitalize;
  margin-right: 10px;
`;

const TextHour = styled.p`
  color: black;
  font-size: 20px;
  font-weight: bold;
  margin: 0;
`;

const WrapLogoLeft = styled.div``;

const WrapLogoRight = styled.div`
  width: 20%;
  text-align: right;
`;

const WrapLogoImg = styled.img`
  resize: both;
  display: inline-block;
`;

const RoomName = styled.p`
  width: 60%;
  text-align: center;
  font-size: 3rem;
  font-weight: bolder;
  color: #34458b;
  cursor: pointer;
  margin: 0;
  text-transform: uppercase;
`;

const RoomPKCLS = styled.div`
  width: 100%;
  height: 85%;
  text-align: center;
  padding: 10px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
`;

const RowOne = styled.div`
  width: 100%;
  border: 1px solid ${props => props.color};
  height: ${props => props.height};
  border-radius: 15px;
`;

const RowTwo = styled.div`
  width: 100%;
  height: ${props => props.height};
  border: 1px solid ${props => props.color};
  border-radius: 15px;
  overflow: hidden;
`;

const BorderLine = styled.div`
  height: ${props => props.height};
  width: 100%;
  font-size: 1.5em;
  display: flex;
  align-items: center;
  border-top-left-radius: 15px;
  border-top-right-radius: 15px;
  background-color: ${props => props.color};
`;

const Title = styled.span`
  font-size: 1.5em;
  color: white;
  font-weight: bold;
  padding: 5px 0;
  width: ${props => props.width};
`;

const PatientBegExNumber = styled.div`
  height: 95%;
  width: 100%;
  display: flex;
`;

function renderNumberSize(number) {
  if (number >= 1000) return '17em';
  if (number >= 100) return '18em';
  if (number >= 10) return '19em';
  if (number < 10) return '20em';
  return '16em';
}

const NumberTitle = styled.div`
  width: 20%;
  height: 100%;
  font-size: ${props => props.fontSize};
  font-weight: bold;
  color: ${props => props.color};
  border-right: 1px solid ${props => props.color};
  display: flex;
  justify-content: center;
  align-items: center;
`;

const NumberIsCheckAnimate = keyframes`
 0% { opacity : 1 }
 50% { opacity : 0.5 ; font-size: 22.5rem}
 100% { opacity : 1 }
`;

const NumberAnimate = keyframes`
 0% { opacity : 1 }
 50% { opacity : 0.5 ; font-size: 22rem}
 100% { opacity : 1 }
`;

const NumberPK = styled.div`
  width: 80%;
  height: 100%;
  font-size: ${props => renderNumberSize(props.number)};
  font-weight: bold;
  color: ${props => props.color};
  display: flex;
  justify-content: center;
  align-items: center;
  animation-name: ${props =>
    !props.isCheck ? NumberIsCheckAnimate : NumberAnimate};
  animation-duration: ${props => (!props.isCheck ? '2s' : '2s')};
  animation-iteration-count: ${props => (!props.isCheck ? '3' : '2')};
`;

const FullNamePK = styled.div`
  width: 80%;
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  > p {
    margin: 0;
    font-size: 5em;
    font-weight: bold;
    color: ${props => props.color};
  }
  > span {
    margin: 0;
    margin-top: 10px;
    font-size: 2em;
    font-weight: bold;
    color: ${props => props.color};
  }
`;

const FullNameCLS = styled.div`
  width: 70%;
  height: 100%;
  font-size: 4.5em;
  font-weight: bold;
  text-align: left;
  padding-left: 10px;
  color: ${props => props.color};
  display: flex;
  flex-direction: column;
  justify-content: center;
  > p {
    margin: 0;
    margin-top: 10px;
    font-size: 20px;
    font-weight: bold;
    color: ${props => props.color};
  }
`;

function renderNumberSizeCLS(number) {
  if (number >= 1000) return '8em';
  if (number >= 100) return '9.5em';
  if (number >= 10) return '10.5em';
  if (number < 10) return '12em';
  return '3.5em';
}

const NumberCLS = styled.div`
  width: 30%;
  height: 100%;
  font-size: ${props => renderNumberSizeCLS(props.number)};
  font-weight: bold;
  color: ${props => props.color};
  border-right: 1px solid ${props => props.color};
  display: flex;
  justify-content: center;
  align-items: center;
`;

const TitleCLS = styled.div`
  height: ${props => props.height};
  width: 100%;
  font-size: 1.5em;
  display: flex;
  align-items: center;
  border-top-left-radius: 15px;
  border-top-right-radius: 15px;
  background-color: ${props => props.color};
`;

const PatientBegExCLS = styled.div`
  height: 75%;
  width: 100%;
  display: flex;
`;

const RowPatientList = styled.div`
  height: 75%;
`;

const PatientList = styled.div`
  height: 85%;
  > div {
    height: 25%;
    display: flex;
    align-items: flex-start;
    justify-content: space-between;
    align-items: center;
    border-top: 1px solid ${props => props.color};
    border-bottom: ${props =>
    props.length === 1 ? `1px solid ${props.color}` : ''};
  }
`;

const RowPatientWait = styled.div`
  height: 85%;
  width: 100%;
  display: flex;
  flex-wrap: wrap;
  flex: 1;
`;

const PatientPriority = styled.div`
  width: 50%;
  height: 100%;
  text-align: center;
  padding: 0 10px;
  border-left: 1px solid black;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
`;

const PatientTitle = styled.h1`
  font-size: 2em;
  height: 5%;
  color: ${props => props.color};
  margin: 0;
`;

RoomCLS.propTypes = {
  temperature: propTypes.number,
  listPatient: propTypes.array,
  listPatientsDeptVirtual: propTypes.array,
  listPatientPro: propTypes.array,
  waitings: propTypes.object,
  listRoom: propTypes.any,
  device: propTypes.any,
  history: propTypes.any,
  system: propTypes.object,
  changeDeviceType: propTypes.func,
  getLastPatient: propTypes.func,
  getLastPatientDepVid: propTypes.func,
  clearLastPatientDepVidFail: propTypes.func,
};

export function RoomCLS({
  listPatient,
  listPatientPro,
  waitings,
  listRoom,
  device,
  temperature,
  listPatientsDeptVirtual,
  ...props
}) {
  useInjectReducer({ key, reducer: appReducer });
  useInjectSaga({ key, saga: appSaga });
  const [room, setRoom] = useState(null);
  const [currentTime, setCurrentTime] = useState(null);
  const [number, setNumber] = useState(null);
  const intervalCallRoom = useRef(null);
  const intervalCallRoomDvid = useRef(null);
  const audioQueueRef = useRef([]);
  const playedAudioQueueRef = useRef([]);
  const [audioSrcPK, setAudioSrcPK] = useState('');
  const [audioSrcCLS, setAudioSrcCLS] = useState('');
  const isPlayingRef = useRef(false);

  useEffect(() => {
    const timer = setInterval(() => {
      setCurrentTime(Util.getCurrentTime());
    }, 1000);
    return () => {
      clearInterval(timer);
    };
  }, []);

  useEffect(() => {
    function loadCacheRoom() {
      const cacheRoom = JSON.parse(localStorage.getItem(ROOM_CLS));
      if (!cacheRoom || !cacheRoom.length) return;
      setRoom(_.head(cacheRoom));
    }
    loadCacheRoom();
  }, []);

  useEffect(() => {
    let normal = renderNumber().normal;
    if (normal > 0 && device.type === 4) {
      const dept = audioQueueRef.current.find(
        a => a.normal === normal,
      );

      if (dept) {
        if (dept.normal === normal) return;
        audioQueueRef.current = audioQueueRef.current.filter(
          a => a.normal !== normal,
        );
      }

      const number = renderNumber();
      if (number != null && !_.isEmpty(number.normalAudioUrl)) {
        number.normalAudioFullUrl = linkAudio(number.normalAudioUrl);
      }

      audioQueueRef.current.push(number);
      console.log(audioQueueRef);
    }
    nextAudio();
  }, [_.get(waitings, 'normal_audio_url')]);

  useEffect(() => {
    if (_.isEmpty(audioSrcCLS)) return;
    nextAudio();
  }, [audioSrcCLS]);

  const nextAudio = () => {
    if (isPlayingRef.current) return;
    setAudioSrcCLS('');
    const current = audioQueueRef.current
      ? audioQueueRef.current[0]
      : undefined;
    if (current && current.normal > 0) {
      setAudioSrcCLS(linkAudio(current.normalAudioUrl));
      audioQueueRef.current = audioQueueRef.current.filter(a => a !== current);
      isPlayingRef.current = true;
    } else {
      setAudioSrcCLS('');
      isPlayingRef.current = false;
    }
  };

  useEffect(() => {
    if (device.type === 2) {
      setAudioSrcPK(AppConfig.API_AUDIO_RING);
    }
    const timer = setInterval(() => {
      setNumber(_.get(waitings, 'normal_number'));
    }, 3000);
    return () => {
      clearInterval(timer);
      setAudioSrcPK('');
    };
  }, [_.get(waitings, 'normal_number')]);

  function callPatient(code) {
    if (code === '') return;
    props.getLastPatient(code);
  }

  function callPatientDvid(code) {
    if (code === '' || code === undefined) return;
    props.getLastPatientDepVid(code);
  }

  useEffect(() => {
    if (!_.isEmpty(device) && device.type === 2) {
      callPatient(device.code);
      if (intervalCallRoom.current) {
        clearInterval(intervalCallRoom.current);
      }
      intervalCallRoom.current = setInterval(
        callPatient.bind(callPatient, device.code),
        AppConfig.ROOM_TIMER,
      );
    }
    if (!_.isEmpty(device) && device.type === 4) {
      callPatient(device.code);
      if (intervalCallRoom.current) {
        clearInterval(intervalCallRoom.current);
      }
      intervalCallRoom.current = setInterval(
        callPatient.bind(callPatient, device.code),
        AppConfig.ROOM_TIMER,
      );
      callPatientDvid(device.dvid);
      if (intervalCallRoomDvid.current) {
        clearInterval(intervalCallRoomDvid.current);
      }
      intervalCallRoomDvid.current = setInterval(
        callPatientDvid.bind(callPatientDvid, device.dvid),
        AppConfig.ROOM_TIMER,
      );
    }
    return () => {
      if (intervalCallRoom.current) {
        clearInterval(intervalCallRoom.current);
      }
      if (intervalCallRoomDvid.current) {
        clearInterval(intervalCallRoomDvid.current);
      }
      props.clearLastPatientDepVidFail();
    };
  }, [device]);

  const redirect = () => {
    props.history.push('/');
    props.changeDeviceType(0);
    props.clearLastPatientDepVidFail();
  };
  const renderNumber = () => {
    if (_.isEmpty(waitings)) {
      return {
        normal: 0,
        priority: 0,
      };
    }
    return {
      normal: _.get(waitings, 'normal_number'),
      priority: _.get(waitings, 'priority_number'),
      normalPatients: _.get(waitings, 'normal_patients'),
      priorityPatients: _.get(waitings, 'priority_patients'),
      normalName: _.get(waitings, 'normal_name'),
      normalAge: _.get(waitings, 'normal_age'),
      normalGender: _.get(waitings, 'normal_gender'),
      normalAudioUrl: _.get(waitings, 'normal_audio_url'),
    };
  };

  const indents = [];
  const maxRow = 4;
  if (listPatientsDeptVirtual.length < maxRow) {
    const missingLength = maxRow - listPatientsDeptVirtual.length
    for (let i = 0; i <= missingLength; i++) {
      indents.push(<Patient color="#34458b" />);
    }
  }
  console.log("audioSrcCLS", audioSrcCLS);
  console.log("playedAudioQueueRef", playedAudioQueueRef.current);

  let playedAudios = playedAudioQueueRef.current.filter(
    c => c === audioSrcCLS,
  );

  let isPlayed = playedAudios.length > 0;
  console.log("isPlayed", isPlayed);

  if (_.isEmpty(currentTime)) return <LoadingIndicator />;
  return (
    <AppContainer>
      <Main>
        <Content>
          <HeaderBaner>
            <DateTimer>
              <TextDay>
                {Util.day}/{Util.month}/{Util.year}
                <TextHour>{currentTime}</TextHour>
              </TextDay>
            </DateTimer>
            <RoomName onClick={redirect}>
              {!_.isEmpty(room) && room.label}
            </RoomName>
          </HeaderBaner>
          {device.type === 2 ? (
            <RoomPKCLS>
              <RowOne color="#C62324" height="49.5%">
                <BorderLine height="5%" color="#C62324" />
                <PatientBegExNumber>
                  <NumberTitle color="#C62324" fontSize="3rem">
                    Số thứ tự
                  </NumberTitle>
                  <NumberPK
                    color="#C62324"
                    number={renderNumber().normal}
                    isCheck={number === _.get(waitings, 'normal_number')}
                  >
                    {renderNumber().normal}
                  </NumberPK>
                </PatientBegExNumber>
              </RowOne>
              <RowTwo color="#34458b" height="49.5%">
                <BorderLine height="5%" color="#34458b" />
                <PatientBegExNumber>
                  <NumberTitle color="#34458b" fontSize="2.5rem">
                    Người bệnh <br /> đang khám
                  </NumberTitle>
                  <FullNamePK color="#34458b">
                    {!_.isEmpty(renderNumber().normalName) && (
                      <p>{renderNumber().normalName}</p>
                    )}
                    {!_.isEmpty(renderNumber().normalAge) && (
                      <span>
                        {PatientHelper.setGender(renderNumber().normalGender)} /
                        {renderNumber().normalAge} tuổi
                      </span>
                    )}
                  </FullNamePK>
                </PatientBegExNumber>
              </RowTwo>
              {audioSrcPK !== '' && (
                <ReactAudioPlayer
                  src={audioSrcPK}
                  autoPlay
                  onEnded={() => setAudioSrcPK('')}
                />
              )}
            </RoomPKCLS>
          ) : (
            <RoomPKCLS>
              <RowOne color="#C62324" height="39.5%">
                <TitleCLS height="25%" color="#C62324">
                  <Title width="30%">Số thứ tự</Title>
                  <Title width="70%">NGƯỜI BỆNH ĐANG KHÁM</Title>
                </TitleCLS>
                <PatientBegExCLS>
                  <NumberCLS color="#C62324" number={renderNumber().normal}>
                    {renderNumber().normal}
                  </NumberCLS>
                  <FullNameCLS color="#C62324">
                    {!_.isEmpty(renderNumber().normalName) && (
                      <ScrollText
                        width="30"
                        stop={renderNumber().normalName.length < 35}
                      >
                        <p>{renderNumber().normalName}</p>
                      </ScrollText>
                    )}
                    {!_.isEmpty(renderNumber().normalAge) ? (
                      <p>
                        {PatientHelper.setGender(renderNumber().normalGender)} /
                        {renderNumber().normalAge} tuổi
                      </p>
                    ) : null}
                  </FullNameCLS>
                </PatientBegExCLS>
              </RowOne>
              <RowTwo color="#34458b" height="59.5%">
                <TitleCLS height="15%" color="#34458b">
                  <Title width="30%">Số thứ tự</Title>
                  <Title width="70%">NGƯỜI BỆNH ĐANG CHỜ</Title>
                </TitleCLS>
                {!_.isEmpty(listPatientsDeptVirtual) &&
                  listPatientsDeptVirtual.length ? (
                  <PatientList
                    rows="4"
                    color="#34458b"
                    length={_.orderBy(listPatientsDeptVirtual).length}
                  >
                    {_.orderBy(listPatientsDeptVirtual, 'queue_number', [
                      'asc',
                    ]).map((patient, idx) => (
                      <Patient key={idx} {...patient} color="#34458b" />
                    ))}
                    {indents.map((item, index) => (
                      <Patient color="#34458b" />
                    ))}
                  </PatientList>
                ) : (
                  <PatientList rows="4" color="#34458b">
                    <Patient color="#34458b" />
                    <Patient color="#34458b" />
                    <Patient color="#34458b" />
                    <Patient color="#34458b" />
                  </PatientList>
                )}
              </RowTwo>
              <ReactAudioPlayer
                autoPlay
                src={audioSrcCLS}
                onEnded={() => {
                  console.log('onEnded');
                  isPlayingRef.current = false;
                  playedAudioQueueRef.current.push(audioSrcCLS);
                  audioQueueRef.current = [];
                  setAudioSrcCLS('');
                }}
                onError={() => {
                  console.log('onError');
                  isPlayingRef.current = false;
                  setAudioSrcCLS('');
                }}
              />
            </RoomPKCLS>
          )}
        </Content>
      </Main>
    </AppContainer>
  );
}

const mapStateToProps = createStructuredSelector({
  temperature: Global.selectTemperature(),
  waitings: Global.selectWatingPatients(),
  listPatient: Global.selectPatients(),
  listPatientPro: Global.selectPatientsPriority(),
  listPatientsDeptVirtual: Global.selectPatientsDeptVirtual(),
  fetching: Global.selectLoading(),
  listRoom: Global.selectListRoomCLS(),
  device: Global.selectDeviceSetting(),
  system: Global.selectSystemSetting(),
  router: Global.selectRouter(),
});

export function mapDispatchToProps(dispatch) {
  return {
    changeDeviceType: () => dispatch(appActions.changeDeviceType(0)),
    getLastPatient: room => dispatch(appActions.getLastPatient(room)),
    getLastPatientDepVid: room =>
      dispatch(appActions.getLastPatientDepVid(room)),
    clearLastPatientDepVidFail: () =>
      dispatch(appActions.clearLastPatientDepVidFail()),
  };
}

const withConnect = connect(
  mapStateToProps,
  mapDispatchToProps,
);

export default compose(
  withConnect,
  memo,
)(RoomCLS);

/* eslint-disable react/no-array-index-key */
/* eslint-disable consistent-return */
/* eslint-disable default-case */
/* eslint-disable indent */
/* eslint-disable arrow-body-style */
import React, { useEffect, memo, useRef, useState } from 'react';
import * as Global from 'containers/App/selectors';
import * as appActions from 'containers/App/actions';
import * as _ from 'lodash';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer } from 'utils/injectReducer';
import { useInjectSaga } from 'utils/injectSaga';
import { Main } from 'components/Main';
import { AppContainer } from 'components/AppContainer';
import { ROOM_CLS, PatientHelper, INIT_REG } from 'containers/App/helper';
import appReducer, { key } from 'containers/App/reducer';
import appSaga from 'containers/App/saga';
import propTypes from 'prop-types';
import ReactPlayer from 'react-player';
import styled from 'styled-components';
import LoadingIndicator from 'components/LoadingIndicator';
import { BHYTItem } from './BHYTItem';
import { AppConfig } from '../../public/appConfig';
import * as Util from '../../utils/Function';
// import logoK from '../../images/logo-k.png';
// import tekvcb from '../../images/tekvcb.png';
import { ScrollText } from '../../components/ScrollText';
import { Patient } from './Patient';
import './BHYTPage.css';

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
  font-size: 2rem;
  font-weight: bolder;
  color: #34458b;
  cursor: pointer;
  margin: 0;
  text-transform: uppercase;
`;

const RowPatient = styled.div`
  height: 85%;
  width: 100%;
  display: flex;
  flex-wrap: wrap;
  flex: 1;
`;

const Patients = styled.div`
  width: 100%;
  height: 100%;
  text-align: center;
  padding: 10px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
`;

const PatientBegEx = styled.div`
  width: 100%;
  height: 38%;
  border: 1px solid ${props => props.color};
  border-radius: 15px;
`;

const PatientTitle = styled.div`
  height: ${props => props.height};
  width: 100%;
  font-size: 1em;
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

const PatientInfor = styled.div`
  height: 75%;
  width: 100%;
  display: flex;
`;

function renderNumberSize(number) {
  if (number >= 1000) return '4em';
  if (number >= 100) return '5.5em';
  if (number >= 10) return '6.5em';
  if (number < 10) return '8em';
  return '3.5em';
}

const Number = styled.div`
  width: 30%;
  height: 100%;
  font-size: ${props => renderNumberSize(props.number)};
  font-weight: bold;
  color: ${props => props.color};
  border-right: 1px solid ${props => props.color};
  display: flex;
  justify-content: center;
  align-items: center;
`;

const FullName = styled.div`
  width: 70%;
  height: 100%;
  font-size: 2.5em;
  font-weight: bold;
  text-align: left;
  padding-left: 10px;
  color: ${props => props.color};
  display: flex;
  flex-direction: column;
  justify-content: center;
  > p {
    margin: 0;
    font-size: 20px;
    font-weight: bold;
    color: ${props => props.color};
  }
`;

const PatientWait = styled.div`
  width: 100%;
  height: 60%;
  border: 1px solid ${props => props.color};
  border-radius: 15px;
  overflow: hidden;
`;

const PatientList = styled.div`
  height: 85%;
  > div {
    height: 50%;
    display: flex;
    align-items: flex-start;
    justify-content: space-between;
    align-items: center;
    border-top: 1px solid ${props => props.color};
    border-bottom: ${props =>
      props.length === 1 ? `1px solid ${props.color}` : ''};
  }
`;

BHYTPage.propTypes = {
  tableBHYT: propTypes.any,
  bhyt: propTypes.any,
  device: propTypes.any,
  listTable: propTypes.any,
  system: propTypes.object,
  history: propTypes.any,
  changeDeviceType: propTypes.func,
  getBhyt: propTypes.func,
  setTableBHYT: propTypes.func,
  getTableBHYT: propTypes.func,
};

export function BHYTPage({
  tableBHYT,
  bhyt,
  device,
  listTable,
  system,
  ...props
}) {
  useInjectReducer({ key, reducer: appReducer });
  useInjectSaga({ key, saga: appSaga });
  const tableBhytRef = useRef(null);
  const [currentTime, setCurrentTime] = useState(null);
  const intervalCallRoom = useRef(null);

  useEffect(() => {
    const timer = setInterval(() => {
      setCurrentTime(Util.getCurrentTime());
    }, 1000);
    return () => {
      clearInterval(timer);
    };
  }, []);

  useEffect(() => {
    return () => {
      clearInterval(tableBhytRef.current);
    };
  }, []);

  useEffect(() => {
    function getBHYTInfo(tabBHYT) {
      if (_.isEmpty(tabBHYT)) return;
      props.getBhyt(tabBHYT);
    }
    getBHYTInfo(tableBHYT);
  }, [tableBHYT]);

  useEffect(() => {
    if (!_.isEmpty(listTable) && listTable.length && !_.isEmpty(device)) {
      const currentTable = listTable.find(
        context => context.code === device.code,
      );
      if (currentTable) {
        props.getTableBHYT(currentTable.id);
        tableBhytRef.current = setInterval(() => {
          props.getTableBHYT(currentTable.id);
        }, 5000);
      }
    }
  }, [listTable, device]);

  const redirect = () => {
    props.history.push('/');
    props.changeDeviceType(0);
  };

  const renderNumber = (type = '') => {
    if (_.isEmpty(bhyt)) return;
    switch (type) {
      case 'NUMBER':
        return bhyt.current_number;
      case 'QUEUE_PATIENT':
        return bhyt.in_queue_patients;
      case 'LAST_PATIENT':
        return bhyt.last_queue_patients;
      case 'NAME':
        return bhyt.current_name;
      case 'AGE':
        return bhyt.current_age;
      case 'GENDER':
        return bhyt.current_gender;
    }
  };
  const renderBG = tab => {
    if (_.isEmpty(tab)) return '';
    return tab.type ? 'red' : '#03c2fc';
  };

  const renderTypeWaiting = tab => {
    if (_.isEmpty(tab)) return '';
    return tab.type ? 'NGƯỜI BỆNH ƯU TIÊN' : 'NGƯỜI BỆNH THƯỜNG';
  };
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
              <WrapLogoLeft>
                {/* <WrapLogoImg width={85} src={logoK} /> */}
              </WrapLogoLeft>
            </DateTimer>
            <RoomName onClick={redirect}>
              BÀN PHÁT THUỐC{' '}
              {_.isEmpty(tableBHYT) ? '' : _.get(tableBHYT, 'code')}
            </RoomName>
            <WrapLogoRight>
              {/* <WrapLogoImg width={240} src={tekvcb} /> */}
            </WrapLogoRight>
          </HeaderBaner>
          <RowPatient>
            <Patients>
              <PatientBegEx color="#C62324">
                <PatientTitle height="25%" color="#C62324">
                  <Title width="30%">Số thứ tự</Title>
                  <Title width="70%">Người bệnh vào lấy thuốc</Title>
                </PatientTitle>
                <PatientInfor>
                  <Number color="#C62324" number={renderNumber('NUMBER')}>
                    {renderNumber('NUMBER')}
                  </Number>
                  <FullName color="#C62324">
                    {!_.isEmpty(renderNumber('NAME')) ? (
                      <ScrollText
                        width="30"
                        stop={renderNumber('NAME').length < 35}
                      >
                        <p>{renderNumber('NAME')}</p>
                      </ScrollText>
                    ) : null}
                    {!_.isEmpty(renderNumber('NAME')) &&
                    !_.isEmpty(renderNumber('AGE')) ? (
                      <p>
                        {PatientHelper.setGender(renderNumber('GENDER'))}/{' '}
                        {renderNumber('AGE')} tuổi
                      </p>
                    ) : null}
                  </FullName>
                </PatientInfor>
              </PatientBegEx>
              <PatientWait color="#34458b">
                <PatientTitle height="15%" color="#34458b">
                  <Title width="30%">Số thứ tự</Title>
                  <Title width="70%">người bệnh chuẩn bị lấy thuốc</Title>
                </PatientTitle>
                {!_.isEmpty(renderNumber('QUEUE_PATIENT')) &&
                renderNumber('QUEUE_PATIENT').length ? (
                  <PatientList
                    rows="2"
                    color="#34458b"
                    length={_.orderBy(renderNumber('QUEUE_PATIENT')).length}
                  >
                    {_.orderBy(renderNumber('QUEUE_PATIENT'), 'queue_number', [
                      'asc',
                    ]).map((patient, idx) => (
                      <Patient key={idx} {...patient} color="#34458b" />
                    ))}
                  </PatientList>
                ) : (
                  <PatientList rows="2" color="#34458b">
                    <Patient color="#34458b" />
                    <Patient color="#34458b" />
                  </PatientList>
                )}
              </PatientWait>
            </Patients>
          </RowPatient>
        </Content>
      </Main>
    </AppContainer>
  );
}

const mapStateToProps = createStructuredSelector({
  listTable: Global.selectListTable(),
  device: Global.selectDeviceSetting(),
  system: Global.selectSystemSetting(),
  bhyt: Global.selectBhyt(),
  tableBHYT: Global.selectTableBHYT(),
});

export function mapDispatchToProps(dispatch) {
  return {
    changeDeviceType: () => dispatch(appActions.changeDeviceType(0)),
    getBhyt: payload => dispatch(appActions.getBHYT(payload)),
    setTableBHYT: payload => dispatch(appActions.setTableBHYT(payload)),
    getTableBHYT: id => dispatch(appActions.getTableBHYT(id)),
  };
}

const withConnect = connect(
  mapStateToProps,
  mapDispatchToProps,
);

export default compose(
  withConnect,
  memo,
)(BHYTPage);

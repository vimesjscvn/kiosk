/* eslint-disable prettier/prettier */
/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
/* eslint-disable indent */
/* eslint-disable react/react-in-jsx-scope */
/* eslint-disable prettier/prettier */
import React, { memo, useState, useEffect } from 'react';
import * as appActions from 'containers/App/actions';
import styled from 'styled-components';
import { day, month, year, dayName, getCurrentTime } from 'utils/Function';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { DEFAULT_COLOR } from '../../containers/App/helper';
import LoadingIndicator from '../LoadingIndicator';

export const AppHeaderDate = styled.div`
  width: 25%;
  height: auto;
  border-right: 10px solid ${DEFAULT_COLOR};
  display: inline-block;
  cursor: pointer;
`;
export const SpanDateTime = styled.span`
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;
  height: 100%;
  color: ${DEFAULT_COLOR};
`;
export const Time = styled.span`
  text-align: center;
  display: block;
  font-size: 5rem;
  font-weight: bold;
  @media (max-width: 1770px) {
    font-size: 3.4rem;
  }
`;
export const Date = styled.span`
  text-align: center;
  display: block;
  font-size: 2.5rem;
  text-transform: capitalize;
  @media (max-width: 1770px) {
    font-size: 1.6rem;
  }
`;
function DateTime({ time, ...props }) {
  const [currentTime, setCurrentTime] = useState('');
  useEffect(() => {
    const timer = setInterval(() => {
      setCurrentTime(getCurrentTime());
    }, 1000);
    return () => {
      clearInterval(timer);
    };
  }, []);

  const redirect = () => {
    props.history.push('/');
    props.changeDeviceType(0);
  };

  return (
    <AppHeaderDate onClick={redirect}>
      <SpanDateTime>
        {currentTime ? <Time>{currentTime}</Time> : <LoadingIndicator />}
        <Date>
          {dayName}, {day}/{month}/{year}
        </Date>
      </SpanDateTime>
    </AppHeaderDate>
  );
}

const mapDispatchToProps = dispatch => ({
  changeDeviceType: () => dispatch(appActions.changeDeviceType(0)),
});

const withConnect = connect(
  null,
  mapDispatchToProps,
);

export default compose(
  withConnect,
  memo,
)(DateTime);

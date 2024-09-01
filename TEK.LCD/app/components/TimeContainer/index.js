/* eslint-disable indent */
/* eslint-disable no-unneeded-ternary */
/* eslint-disable import/order */
/* eslint-disable no-unused-vars */
/* eslint-disable react/prop-types */
import React from 'react';
import styled from 'styled-components';
import { day, month, year, dayName } from 'utils/Function';
import { DEFAULT_COLOR } from '../../containers/App/helper';

const TimeWrapper = styled.div`
  width: 100%;
  height: 30%;
  border-bottom: 3px solid ${DEFAULT_COLOR};
  padding: 10px;
  > * {
    margin: 0;
    padding: 0;
    text-align: center;
  }
  > h3 {
    font-size: 6rem;
    text-transform: uppercase;
  }
  > :nth-child(2) {
    font-size: 3rem;
    padding-bottom: 20px;
    text-transform: capitalize;
  }
  > :nth-child(3) {
    font-size: 1.5rem;
  }
`;

export default function TimeContainer({ time }) {
  return (
    <TimeWrapper>
      <h3>{time}</h3>
      <p>{dayName}</p>
      <p>
        Ngày {day} tháng {month} năm {year}
      </p>
    </TimeWrapper>
  );
}

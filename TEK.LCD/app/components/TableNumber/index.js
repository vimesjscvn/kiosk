/* eslint-disable consistent-return */
/* eslint-disable import/order */
/* eslint-disable import/no-duplicates */
/* eslint-disable react/prop-types */
import React from 'react';
import styled from 'styled-components';
import { get } from 'lodash';
import { number2Digits } from 'containers/App/helper';
import { usePrevious } from '../../hooks/usePrevious';
import { TextGlow } from 'containers/App/helper';
import { DEFAULT_COLOR } from '../../containers/App/helper';

const PatientNumber = styled.span`
  font-weight: bold;
  font-size: 4rem;
  animation: ${TextGlow} 0.5s infinite alternate;
  animation-play-state: ${props => {
    const oldNumber = get(props, 'oldNumber');
    const newNumber = get(props, 'newNumber');
    if (oldNumber && newNumber) {
      return oldNumber === newNumber ? 'paused' : 'running';
    }
    return 'paused';
  }};
  @media (max-width: 1400px) {
    font-size: ${props => (props.numberTable <= 2 ? '6rem' : '45px')};
  }
`;

const PatientArrrow = styled.i`
  font-size: 3rem;
  color: ${props => (props.type ? '#de1111' : DEFAULT_COLOR)};
  margin: 0 1rem;
  @media (max-width: 1400px) {
    font-size: ${props => (props.numberTable <= 2 ? '4.5rem' : '25px')};
  }
`;

export function TableNumber({ number, type, numberTable }) {
  const numberRef = usePrevious(number);
  const from = number - 5 < 0 ? 0 : number - 5;
  return (
    <PatientNumber
      oldNumber={numberRef}
      newNumber={number}
      numberTable={numberTable}
    >
      {number2Digits(from)}
      <PatientArrrow
        type={type}
        numberTable={numberTable}
        className="fas fa-arrow-right"
      />
      {number2Digits(number)}
    </PatientNumber>
  );
}

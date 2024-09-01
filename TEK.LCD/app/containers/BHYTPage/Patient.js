/* eslint-disable react/jsx-no-duplicate-props */
/* eslint-disable camelcase */
/* eslint-disable react/prop-types */
import React from 'react';
import styled from 'styled-components';
import { isEmpty } from 'lodash';
import { PatientHelper } from '../App/helper';
import { ScrollText } from '../../components/ScrollText';

const PatientItem = styled.div`
  border-bottom: 1px solid ${props => props.color};
`;

function renderNumberSize(number) {
  if (number >= 1000) return '4em';
  if (number >= 100) return '5.5em';
  if (number >= 10) return '6.5em';
  if (number < 10) return '8em';
  return '3.5em';
}

function renderBorder(color, number) {
  if (!isEmpty(number) || number >= 0) {
    return `1px solid ${color}`;
  }
  return null;
}
const Number = styled.div`
  width: 30%;
  height: 100%;
  font-size: ${props => renderNumberSize(props.number)};
  font-weight: bold;
  color: ${props => props.color};
  border-right: ${props => renderBorder(props.color, props.number)};
  display: flex;
  align-items: center;
  justify-content: center;
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
    margin-top: 10px;
  }
  > span {
    margin: 0;
    font-size: 20px;
    font-weight: bold;
    color: ${props => props.color};
  }
`;

const ScrollName = styled.p`
  font-weight: bold;
  text-transform: uppercase;
  margin: 0;
  color: ${props => props.type};
`;

export function Patient({ age, name, queue_number, color, ...props }) {
  return (
    <PatientItem>
      <Number color={color} number={!isEmpty(queue_number) ? queue_number : 0}>
        {queue_number !== undefined ? queue_number : ''}
      </Number>
      <FullName color={color}>
        <ScrollText width="30" stop={!isEmpty(name) && name.length < 35}>
          <p>{!isEmpty(name) ? name : ''}</p>
        </ScrollText>
        <span>
          {!isEmpty(props) && !isEmpty(age)
            ? PatientHelper.setPatientGender(props) + `/ ${age} tuổi`
            : ''}
        </span>
      </FullName>
    </PatientItem>
  );
}

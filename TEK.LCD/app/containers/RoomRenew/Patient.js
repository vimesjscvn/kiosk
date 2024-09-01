/* eslint-disable camelcase */
/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
import React from 'react';
import styled from 'styled-components';
import { isEmpty } from 'lodash';
import { PatientHelper } from '../App/helper';
import { ScrollText } from '../../components/ScrollText';

const PatientItem = styled.div`
  margin: 0;
  @media (min-width: 800px) {
    display: block;
  }
`;

function renderName(number) {
  if (number >= 1000) return '68%';
  if (number >= 100) return '75%';
  if (number < 100) return '80%';
  return '80%';
}

function renderItem(number) {
  if (number >= 1000) return '32%';
  if (number >= 100) return '25%';
  if (number < 100) return '20%';
  return '20%';
}

const PatientName = styled.div`
  width: ${props => renderName(props.number)};
  padding-left: 10px;
`;

const PatientInfo = styled.div`
  width: ${props => renderItem(props.number)};
  text-align: center;
  border-left: 1px solid ${props => props.type};
`;

function renderNumberSize(number) {
  if (number >= 1000) return '2em';
  if (number >= 100) return '2.3em';
  if (number >= 10) return '3.8em';
  return '3.8em';
}

const PatientNumber = styled.div`
  font-weight: bold;
  margin: 0;
  color: ${props => props.type};
  font-size: ${props => renderNumberSize(props.number)};
`;

const Gender = styled.div`
  font-size: 15px;
  padding-top: 5px;
  color: ${props => props.type};
`;

const Name = styled.p`
  font-weight: bold;
  text-transform: uppercase;
  margin: 0;
  font-size: 1.5em;
  color: ${props => props.type};
`;

export function Patient({ age, name, queue_number, colorType, ...props }) {
  if (isEmpty(props)) return <React.Fragment />;
  return (
    <PatientItem>
      <PatientName number={queue_number}>
        {name.length > 15 ? (
          <ScrollText width={name.length}>
            <Name type={colorType}>{name}</Name>
          </ScrollText>
        ) : (
          <Name type={colorType}>{name}</Name>
        )}
        <Gender type={colorType}>
          {PatientHelper.setPatientGender(props)} / {age} tuổi
        </Gender>
      </PatientName>
      <PatientInfo type={colorType} number={queue_number}>
        <PatientNumber type={colorType} number={queue_number}>
          {queue_number}
        </PatientNumber>
      </PatientInfo>
    </PatientItem>
  );
}

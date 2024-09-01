/* eslint-disable react/prop-types */
import React from 'react';
import * as _ from 'lodash';
import styled from 'styled-components';
import { PatientHelper } from '../App/helper';

const WrapItem = styled.div`
  width: 100%;
  display: flex;
  align-items: center;
  height: calc(100% / 3);
  border-bottom: 1px solid black;
`;

const NameItem = styled.div`
  width: 70%;
  margin-left: 5px;
`;

function renderNumberSize(number) {
  if (number >= 1000) return '2.4em';
  if (number >= 100) return '3em';
  if (number >= 10) return '4em';
  return '4em';
}

const NumberPare = styled.div`
  width: 30%;
  font-weight: bold;
  font-size: ${props => renderNumberSize(props.number)};
  text-align: center;
  border-left: 1px solid black;
`;

const InfoPatient = styled.div`
  color: black;
  font-size: 14px;
  font-weight: bold;
`;

const NameNotScroll = styled.div`
  font-size: 1.8em;
  border: none;
  font-weight: bold;
  color: black;
  background: white;
  margin: 0;
`;

export function BHYTItem({ patient }) {
  if (_.isEmpty(patient)) return <></>;
  return (
    <WrapItem>
      <NameItem>
        <div className={`${patient.name.length >= 15 ? 'scroll-left' : ''}`}>
          <NameNotScroll>{patient.name}</NameNotScroll>
        </div>
        <InfoPatient>
          {PatientHelper.setPatientGender(patient)} / {patient.age} tuổi
        </InfoPatient>
      </NameItem>
      <NumberPare number={patient.queue_number}>
        {patient.queue_number}
      </NumberPare>
    </WrapItem>
  );
}

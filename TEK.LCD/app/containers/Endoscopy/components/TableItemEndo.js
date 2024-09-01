/* eslint-disable import/no-cycle */
/* eslint-disable consistent-return */
/* eslint-disable no-useless-return */
/* eslint-disable import/order */
/* eslint-disable no-unused-vars */
/* eslint-disable indent */
/* eslint-disable no-nested-ternary */
/* eslint-disable prettier/prettier */
/* eslint-disable arrow-body-style */
/* eslint-disable camelcase */
/* eslint-disable react/prop-types */
import * as _ from 'lodash';
import React from 'react';
import styled from 'styled-components';
import {
  DEFAULT_COLOR,
  formatName2Digits,
  getNameLastPatients,
} from '../../App/helper';
import './style.css';

function renderNumberSize(number) {
  if (number >= 1000) return '5em';
  if (number >= 100) return '4.5em';
  if (number >= 10) return '5em';
  return '5em';
}

const PatientNumber = styled.span`
  font-weight: bold;
  font-size: 4rem;
  @media (max-width: 1400px) {
    font-size: 5rem;
    font-weight: 900;
  }
`;

const RoomNumber = styled.span`
  font-weight: bold;
  font-size: 2rem;
  color: ${DEFAULT_COLOR};
  @media (max-width: 1400px) {
    font-size: 2.5rem;
    font-weight: 900;
  }
`;

const RoomName = styled.span`
  font-weight: bold;
  font-size: 2rem;
  color: ${DEFAULT_COLOR};
  @media (max-width: 1400px) {
    font-size: 1.8rem;
    font-weight: 900;
  }
`;

const GenderAge = styled.p`
  font-weight: bold;
  font-size: 2rem;
  color: ${DEFAULT_COLOR};
  margin: 0;
  @media (max-width: 1400px) {
    margin: 0;
    font-size: 1rem;
    font-weight: 500;
  }
`;

const TableBodyRow = styled.div`
  width: 100%;
  display: flex;
  height: ${props => {
    return props.number > 5 ? '100%' : `-moz-calc(100%/${props.number})`;
  }};
  height: ${props => {
    return props.number > 5 ? '100%' : `-webkit-calc(100%/${props.number})`;
  }};
  height: ${props => {
    return props.number > 5 ? '100%' : `calc(100%/${props.number})`;
  }};

  border-left: 4px solid ${DEFAULT_COLOR};
  border-right: 4px solid ${DEFAULT_COLOR};
  text-align: center;
`;

const BoxNumberRoom = styled.div`
  width: 15%;
  border-right: 4px solid ${DEFAULT_COLOR};
  border-bottom: 4px solid ${DEFAULT_COLOR};
  display: flex;
  justify-content: space-around;
  align-items: center;
`;

const BoxNameRoom = styled.div`
  width: 30%;
  border-right: 4px solid ${DEFAULT_COLOR};
  border-bottom: 4px solid ${DEFAULT_COLOR};
  display: flex;
  justify-content: space-around;
  align-items: center;
`;

const BoxNamePatient = styled.div`
  width: 35%;
  border-right: 4px solid ${DEFAULT_COLOR};
  border-bottom: 4px solid ${DEFAULT_COLOR};
  display: flex;
  justify-content: space-around;
  align-items: center;
`;

const BoxNamePatientChild = styled.div``;

const BoxNumberPatient = styled.div`
  width: 20%;
  color: #de1111;
  border-bottom: 4px solid ${DEFAULT_COLOR};
  display: flex;
  align-items: center;
  justify-content: center;
`;

export function TableItemEndo({ table, number }) {
  if (_.isEmpty(table)) {
    return <TableBodyRow />;
  }

  return (
    <TableBodyRow number={number}>
      <BoxNumberRoom>
        <RoomNumber>P{_.get(table, 'display_order')}</RoomNumber>
      </BoxNumberRoom>
      <BoxNameRoom>
        <RoomName>
          {_.get(table, 'department_name_change')
            ? _.get(table, 'department_name_change')
            : _.get(table, 'department_name')}
        </RoomName>
      </BoxNameRoom>
      <BoxNamePatient>
        <BoxNamePatientChild>
          <RoomName>
            {getNameLastPatients(_.get(table, 'last_patients')).fullName}
          </RoomName>
          <GenderAge>
            {getNameLastPatients(_.get(table, 'last_patients')).gender}
            {getNameLastPatients(_.get(table, 'last_patients')).age}
          </GenderAge>
        </BoxNamePatientChild>
      </BoxNamePatient>
      <BoxNumberPatient className={table.isChangePriority && 'blink_me'}>
        <PatientNumber>
          {formatName2Digits(getBusinessNumber(table))}
        </PatientNumber>
      </BoxNumberPatient>
    </TableBodyRow>
  );
}

const businessRooms = [
  'DIENTIM_201',
  'DIENTIM_202',
  'CNHH_202',
  'NOISOI_255_MIENG',
  'NOISOI_255_MUI',
  'NOISOI_254_PQ',
  'NOISOI_254_BQ',
  'NOISOI_254_TQ',
  'NOISOI_251_DDGM',
  'NOISOI_260',
];
function getBusinessNumber(queue) {
  if (
    _.get(queue, 'normal_number') === 0 &&
    businessRooms.includes(_.get(queue, 'deparment_code'))
  ) {
    return 1;
  }
  return _.get(queue, 'normal_number');
}

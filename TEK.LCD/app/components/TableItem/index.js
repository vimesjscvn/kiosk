/* eslint-disable arrow-body-style */
/* eslint-disable camelcase */
/* eslint-disable react/prop-types */
import React from 'react';
import * as _ from 'lodash';
import styled from 'styled-components';
import { TableNumber } from '../TableNumber';
import { DEFAULT_COLOR } from '../../containers/App/helper';

const TableBodyRow = styled.tr`
  width: 100%;
  height: ${props => (props.numberColumn === 2 ? '30vh' : '21vh')};
  text-align: center;
  padding: 0 1rem;
  > td {
    vertical-align: middle;
  }
`;

const TableBodyOrder = styled.td`
  border-right: ${props =>
    props.number <= 3 || props.numberColumn === 2
      ? `4px solid ${DEFAULT_COLOR}`
      : 'none'};
`;

const TableBodyNormal = styled.td`
  color: ${DEFAULT_COLOR};
  border-right: 4px solid ${DEFAULT_COLOR};
`;

const TableBodyPriority = styled.td`
  color: #de1111;
`;

const Cicrle = styled.span`
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  font-weight: bold;
  font-size: ${props => (props.number <= 2 ? `4rem` : '2.1rem')};
  line-height: 75px;
  height: ${props => (props.number <= 2 ? `130px` : '83px')};
  width: ${props => (props.number <= 2 ? `130px` : '83px')};
  color: ${DEFAULT_COLOR};
  border: 4px solid ${DEFAULT_COLOR};
  border-radius: 50%;
  margin: auto;
  @media (max-width: 1300px) {
    font-size: ${props => (props.number <= 3 ? `3.5rem` : '1.8rem')};
  }
  @media (min-width: 1250px) and (max-width: 1400px) {
    width: ${props => (props.number <= 2 ? `120px` : '75px')};
    height: ${props => (props.number <= 2 ? `120px` : '75px')};
    line-height: ${props => (props.number <= 2 ? `100px` : '60px')};
    font-size: ${props => (props.number <= 2 ? `5rem` : '3rem')};
    font-weight: 700;
  }
`;

export function TableItem({ table, number, numberColumn }) {
  if (_.isEmpty(table) || !table) {
    return <TableBodyRow />;
  }
  const formatTableCode = () => {
    return _.get(table, 'department_name')
      .slice(-2)
      .trim('');
  };

  return (
    <TableBodyRow numberColumn={numberColumn}>
      <TableBodyOrder number={number} numberColumn={numberColumn}>
        <Cicrle number={number}>{formatTableCode()}</Cicrle>
      </TableBodyOrder>
      <TableBodyNormal>
        <TableNumber
          number={_.get(table, 'normal_number')}
          type={0}
          numberTable={number}
        />
      </TableBodyNormal>
      <TableBodyPriority number={number}>
        <TableNumber
          number={_.get(table, 'priority_number')}
          type={1}
          numberTable={number}
        />
      </TableBodyPriority>
    </TableBodyRow>
  );
}

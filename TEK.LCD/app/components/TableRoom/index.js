/* eslint-disable no-underscore-dangle */
/* eslint-disable react/no-array-index-key */
/* eslint-disable no-shadow */
/* eslint-disable react/prop-types */
/* eslint-disable prettier/prettier */
// eslint-disable-next-line prettier/prettier
/* eslint-disable indent */
/* eslint-disable prettier/prettier */
import React from 'react';
import styled from 'styled-components';
import { DEFAULT_COLOR } from '../../containers/App/helper';
import { TableItem } from '../TableItem';

export const TableColumns = [
  { _id: 1, label: 'Bàn Khám' },
  { _id: 2, label: 'Thường' },
  { _id: 3, label: 'Ưu tiên ' },
];

export const Table = styled.table`
  width: 100%;
  height: 100%;
  table-layout: fixed;
`;

export const TableHead = styled.thead`
  width: 100%;
`;

export const TableHeading = styled.th`
  height: 100px;
`

export const TableHeadRow = styled.tr`
    width: 100%;
    min-height: 15%;
    font-size: 2rem;
    line-height: 40px;
    font-weight: bold;
    letter-spacing: -0.03em;
    background: #E3F6FF;
    color: ${DEFAULT_COLOR};
    text-align: center;
    border-bottom: 10px solid ${DEFAULT_COLOR};
    > th:first-child {
        width: 26%;
    }
    > th:nth-child(2) {
        color: ${DEFAULT_COLOR};
        width: 37%;
    }
    > th:last-child {
        color: #DE1111;
        width: 37%;
    }
    @media (max-width: 1361px) {
        font-size: 2rem;
        padding: 0 15px;
        > span:nth-child(2) {
    }
    @media (min-width: 1250px) {
      font-size: 1.8rem;
    }
  }
`

export const TableBody = styled.tbody`
  width: 100%;
  > tr {
    padding: 0 1rem;
    border-bottom: 4px solid ${DEFAULT_COLOR};
  }
  > tr:last-child {
    border-bottom: none;
  }
`;

export function TableRoom({ tables, number, numberColumn }) {
    return(
        <Table>
          <TableHead>
            <TableHeadRow>
              { TableColumns.map(col => (<TableHeading key={col._id}>{ col.label }</TableHeading>)) }
            </TableHeadRow>
          </TableHead>
        <TableBody>
          { tables.length && tables.map((table, idx) => (
            <TableItem table={table} key={idx} number={number} numberColumn={numberColumn}/>
          ))}
        </TableBody>
        </Table>
    )
}
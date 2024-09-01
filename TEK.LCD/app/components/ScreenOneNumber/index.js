/* eslint-disable prettier/prettier */
/* eslint-disable react/prop-types */
/* eslint-disable prettier/prettier */
import React from 'react';
import styled from 'styled-components';
import { TableRoom } from '../TableRoom';

export const ScreenWrapper = styled.div`
  width: 100%;
  height: 100%;
  display: inline-block;

`;

export function ScreenOneNumber({ tables, number }) {
  return (
    <ScreenWrapper>
      <TableRoom tables={tables} number={number}/>
    </ScreenWrapper>
  );
}

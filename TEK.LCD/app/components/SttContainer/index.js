/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
import React from 'react';
import styled from 'styled-components';
import { TableRoom } from '../TableRoom';
import { DEFAULT_COLOR } from '../../containers/App/helper';

export const STTWrapper = styled.div`
  width: 50%;
  height: 100%;
  display: inline-block;
  > div:not(:last-child) {
    border-bottom: 4px solid ${DEFAULT_COLOR};
  }
`;

export function STTContainer({ tables, number }) {
  return (
    <STTWrapper>
      <TableRoom tables={tables} numberColumn={number} />
    </STTWrapper>
  );
}

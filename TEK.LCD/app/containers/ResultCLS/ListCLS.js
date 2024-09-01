/* eslint-disable react/no-array-index-key */
/* eslint-disable react/prop-types */
import React from 'react';
import styled from 'styled-components';
import { ItemCLS } from './ItemClS';

const CLSCol = styled.div`
  width: 100%;
  display: flex;
  flex-wrap: wrap;
`;

export function ListCLS({ list }) {
  if (!list || !list.length) return <CLSCol />;
  return (
    <CLSCol>
      {list.map((item, id) => (
        <ItemCLS key={id} {...item} />
      ))}
    </CLSCol>
  );
}

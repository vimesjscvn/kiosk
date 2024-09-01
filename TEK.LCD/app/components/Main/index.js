/* eslint-disable arrow-body-style */
/* eslint-disable react/react-in-jsx-scope */
/* eslint-disable prettier/prettier */
import React from 'react';
import styled from 'styled-components';

export const MainWrapper = styled.main`
  width: 100%;
  height:  100%;
  overflow: hidden;
  display: ${props => {
    return props.style ? props.style : 'block';
  }}
`;

export function Main(props) {
  return <MainWrapper {...props} />
}

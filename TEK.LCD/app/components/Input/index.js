/* eslint-disable arrow-body-style */
/* eslint-disable no-unused-vars */
import React from 'react';
import styled from 'styled-components';

const InputWrapper = styled.input.attrs(props => {
  return { ...props };
})`
  align-items: center;
  background-color: hsl(0, 0%, 100%);
  border-color: hsl(0, 0%, 80%);
  border-radius: 4px;
  border-style: solid;
  border-width: 1px;
  cursor: default;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  min-height: 38px;
  outline: 0 !important;
  position: relative;
  transition: all 100ms;
  box-sizing: border-box;
  width: 60%;
  padding: 0 10px;
`;

export function Input(props) {
  return <InputWrapper {...props} />;
}

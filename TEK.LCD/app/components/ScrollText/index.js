/* eslint-disable indent */
/* eslint-disable consistent-return */
/* eslint-disable react/prop-types */
import React from 'react';
import styled, { keyframes, css } from 'styled-components';

const SlideLeft = keyframes`
  0% {
    transform: translateX(-100%);
  }
  100% {
    transform: translateX(0%);
  }
`;

function setWidth(width = 0) {
  if (!width) return '200%';
  if (width >= 30) return '400%';
  if (width >= 20) return '300%';
}

const ScrollContainer = styled.div`
  overflow: hidden;
  width: 100%;
  background: white;
  position: relative;
  & > p {
    width: ${props => (props.width ? setWidth(props.width) : '200%')};
    height: 100%;
    margin: 0;
    font-size: 1.1em;
    animation: ${props =>
      props.stop
        ? 'none'
        : css`
            ${SlideLeft} 10s linear infinite reverse
          `};
    animation-delay: 3s;
  }
`;

export function ScrollText({ width, children, stop = false }) {
  return (
    <ScrollContainer width={width} stop={stop}>
      {children}
    </ScrollContainer>
  );
}

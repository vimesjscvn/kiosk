/* eslint-disable no-unused-vars */
/* eslint-disable react/react-in-jsx-scope */
import React from 'react';
import styled from 'styled-components';
import newLogo from '../../../images/new_logo.png';

const PartnerWrapper = styled.div`
  width: 100%;
  height: 20%;
  text-align: center;
  padding: 10px 5%;
  > * {
    margin: 0;
    padding: 0;
  }
  > h4 {
    font-size: 1.4rem;
    padding-bottom: 20px;
  }
  > div {
    width: 90%;
    margin: auto;
  }
  > div > img {
    width: 100%;
  }
`;

export function Partner(props) {
  return (
    <PartnerWrapper>
      <h4>Đối tác triển khai</h4>
      <div>
        <img src={newLogo} alt="" />
      </div>
    </PartnerWrapper>
  );
}

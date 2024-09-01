/* eslint-disable import/no-unresolved */
/* eslint-disable no-unused-vars */
/* eslint-disable indent */
/* eslint-disable no-console */
/* eslint-disable react/prop-types */
import React from 'react';
import styled, { keyframes } from 'styled-components';
import DoctorAvatar from '../../../images/doctor.png';
import { DEFAULT_COLOR } from '../../containers/App/helper';

const slideLeft = keyframes`
  0% { left: 0;}
  50%{ left : 100%;}
  100%{ left: 0;}
`;

const MainTitleWrapper = styled.div`
  width: 100%;
  height: 50%;
  background: red;
  border-bottom: 3px solid ${DEFAULT_COLOR};
`;

const Title = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  padding: 15px 10px;
  width: 100%;
  height: 60%;
  cursor: pointer;
  > * {
    margin: 0;
    padding: 0;
    color: #fff;
    text-align: center;
    text-transform: uppercase;
    font-weight: 600;
  }
  > h1 {
    font-size: 1.5rem;
  }
  > h2 {
    font-size: 4rem;
  }
  > h3 {
    animation: ${slideLeft} 2s ease-in-out infinite alternate;
    font-size: 1.8rem;
  }
`;

const Doctors = styled.div`
  width: 100%;
  height: 40%;
  background: #fff;
  > div:first-child:before {
    content: '';
    width: calc(100% - 20px);
    height: 3px;
    position: absolute;
    background: #b3b6b6;
    bottom: 0;
    left: 50%;
    transform: translateX(-50%);
  }
`;

const Doctor = styled.div`
  display: flex;
  padding: 10px;
  height: 50%;
  position: relative;
  padding-bottom: 10px;
`;

const DoctorImageWrapper = styled.div`
  width: 20%;
`;

const DoctorImage = styled.img`
  width: 100%;
`;

const DoctorText = styled.div`
  width: 80%;
  padding: 0 10px;
`;

const DoctorTitle = styled.p`
  font-weight: 600;
`;

const DoctorName = styled.p`
  text-tranform: uppercase;
`;

export default function MainTitle(props) {
  return (
    <MainTitleWrapper>
      <Title {...props}>
        <h1>phòng khám</h1>
        <h2>{props.code}</h2>
        <h3>{props.description}</h3>
      </Title>
      <Doctors hidden>
        <Doctor>
          <DoctorImageWrapper>
            <DoctorImage src={DoctorAvatar} />
          </DoctorImageWrapper>
          <DoctorText>
            <DoctorTitle>BS.CKI</DoctorTitle>
            <DoctorName>NGUYỄN MINH THANH</DoctorName>
          </DoctorText>
        </Doctor>
        <Doctor>
          <DoctorImageWrapper>
            <DoctorImage src={DoctorAvatar} />
          </DoctorImageWrapper>
          <DoctorText>
            <DoctorTitle>BS.CKI</DoctorTitle>
            <DoctorName>NGUYỄN MINH THANH</DoctorName>
          </DoctorText>
        </Doctor>
      </Doctors>
    </MainTitleWrapper>
  );
}

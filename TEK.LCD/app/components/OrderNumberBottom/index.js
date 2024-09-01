/* eslint-disable no-unused-vars */
/* eslint-disable arrow-body-style */
/* eslint-disable react/no-array-index-key */
/* eslint-disable camelcase */
/* eslint-disable react/prop-types */
import React from 'react';
import styled from 'styled-components';
import { isEmpty } from 'lodash';
import { DEFAULT_COLOR } from '../../containers/App/helper';

const OrderNumber = styled.div`
  width: 50%;
  height: 50%;
  > * > * {
    margin: 0;
    padding: 0;
  }
`;

const OrderTitle = styled.div`
  background: #e3f6ff;
  width: 100%;
  height: 20%;
  display: flex;
  border-top: 10px solid ${DEFAULT_COLOR};
`;

const OrderTitleText = styled.p`
  font-size: 1.5rem;
  margin: auto;
  font-weight: 600;
  color: ${props => (props.type ? '#DC2424' : `${DEFAULT_COLOR}`)};
`;

const OrderContain = styled.div`
  width: 100%;
  height: 90%;
  background: #fff;
  display: flex;
  justify-content: space-around;
  flex-direction: column;
  > * {
    color: ${DEFAULT_COLOR};
    text-align: left;
  }
`;

const OrderList = styled.ul`
  width: 100%;
  height: 100%;
  overflow-y: ${({ patients }) => {
    return !isEmpty(patients) && patients.length > 3 ? 'scroll' : '';
  }};
  list-style-type: none;
  > li:not(last-child) {
    border-bottom: 3px solid ${DEFAULT_COLOR};
  }
`;

const OrderItemSTT = styled.div`
  width: 20%;
  padding: 0 10px;
  color: #083f5c;
`;

const OrdrerItem = styled.li`
  display: flex;
  align-items: flex-start;
  width: 100%;
  padding-top: 10px;
  padding-bottom: 5px;
  min-height: 30%;
`;

const OderItemNote = styled.span`
  display: block;
  text-align: center;
  width: 40%;
  @media (max-width: 1300px) {
    display: none;
  }
`;

const OderItemNumber = styled.span`
  width: 4rem;
  height: 4rem;
  border-radius: 50%;
  border: 1px solid #707070;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 2.6rem;
  font-weight: 600;
  color: ${props => (props.type ? '#DC2424' : `${DEFAULT_COLOR}`)};
`;

const OrderItemText = styled.div`
  flex: 1;
  padding: 0 20px;
  > p {
    font-weight: 500;
    margin: 0;
    padding: 0;
    text-align: left;
    color: ${props => (props.type ? '#DC2424' : `${DEFAULT_COLOR}`)};
  }
  > p:first-child {
    font-size: 2.5rem;
    text-transform: uppercase;
    @media (max-width: 1300px) {
      font-size: 1.6rem;
    }
  }
`;

export function OrderNumberBottom({ patients, ...props }) {
  const render = () => {
    if (isEmpty(patients) || !patients.length) {
      return <OrderList patient={patients} />;
    }
    return patients.map((patient, index) => {
      return (
        <OrdrerItem key={index}>
          <OrderItemSTT>
            <OderItemNumber {...props}>{patient.queue_number}</OderItemNumber>
          </OrderItemSTT>
          <OrderItemText {...props}>
            <p>{!isEmpty(patient.name) ? patient.name : '-'}</p>
            <p>
              {patient.gender ? 'Nam' : 'Nữ'} / {patient.age} Tuổi
            </p>
          </OrderItemText>
        </OrdrerItem>
      );
    });
  };

  return (
    <OrderNumber>
      <OrderTitle>
        <OrderTitleText {...props}>BỆNH NHÂN CHUẨN BỊ</OrderTitleText>
      </OrderTitle>
      <OrderContain>
        <OrderList>{render()}</OrderList>
      </OrderContain>
    </OrderNumber>
  );
}

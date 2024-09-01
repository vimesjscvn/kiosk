/* eslint-disable prefer-template */
/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
import { isEmpty } from 'lodash';
import React from 'react';
import styled from 'styled-components';
import { DEFAULT_COLOR } from '../../containers/App/helper';

const OrderWrapper = styled.div`
  width: 50%;
  height: 50%;
  text-align: center;
  > * > * {
    margin: 0;
    padding: 0;
  }
`;

export const OrderTitle = styled.div`
  background: ${props => (props.type ? '#DC2424' : `${DEFAULT_COLOR}`)};
  width: 100%;
  display: flex;
  text-transform: uppercase;
`;

export const OrderTitleText = styled.h3`
  color: #fff;
  margin: auto;
  padding: 30px 0;
`;

const OrderContain = styled.div`
  width: 100%;
  height: 100%;
  background: #fff;
  > * {
    color: #083f5c;
  }
`;

const OrderText = styled.p`
  font-size: 1.5rem;
  text-transform: uppercase;
  font-weight: 600;
  background: #e3f6ff;
  padding: 10px;
  height: 15%;
  color: ${props => (props.type ? '#DC2424' : `${DEFAULT_COLOR}`)};
`;

const OrderTextContain = styled.div`
  width: 100%;
  height: 85%;
  position: relative;
  display: flex;
`;

const OrderNumberCall = styled.h4`
  font-size: 9.5rem;
  margin: auto;
  color: ${props => (props.type ? '#DC2424' : `${DEFAULT_COLOR}`)};
`;

const OrderPatient = styled.div`
  width: 100%;
  position: absolute;
  left: 0;
  bottom: 0;
  padding: 15px 0 5px;
  > * {
    margin: 0;
    padding: 0;
  }
`;

const OrderNote = styled.h5`
  font-size: 1.4rem;
  padding-top: 15px;
  width: 100%;
  color: ${props => (props.type ? '#DC2424' : `${DEFAULT_COLOR}`)};
`;

const OrderNoteSpan = styled.span`
  font-size: 1.2rem;
  font-weight: 700;
  color: ${props => (props.type ? '#DC2424' : `${DEFAULT_COLOR}`)};
`;

export function OrderNumber(props) {
  const { number, type, name, age, gender } = props;
  const stringAge = age ? String(age) : '';
  const patientType = type ? 'ƯU TIÊN' : 'THƯỜNG';
  return (
    <OrderWrapper>
      <OrderContain>
        <OrderText {...props}>Bệnh nhân {patientType}</OrderText>
        <OrderTextContain>
          <OrderNumberCall {...props}>{number}</OrderNumberCall>
          <OrderPatient>
            <OrderNote {...props}>{!isEmpty(name) ? name : '-'}</OrderNote>
            <OrderNoteSpan {...props}>
              {!isEmpty(stringAge) ? stringAge + ' Tuổi' : '-'} /{' '}
              {!isEmpty(gender) ? gender : '-'}
            </OrderNoteSpan>
          </OrderPatient>
        </OrderTextContain>
      </OrderContain>
    </OrderWrapper>
  );
}

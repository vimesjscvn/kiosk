/* eslint-disable no-unneeded-ternary */
/* eslint-disable import/order */
/* eslint-disable consistent-return */
/* eslint-disable react/prop-types */
/* eslint-disable camelcase */
import React from 'react';
import { isEmpty } from 'lodash';
import { PatientHelper } from '../App/helper';
import { ScrollText } from '../../components/ScrollText';
import styled, { keyframes } from 'styled-components';

const BadgeLight = keyframes`
  0% { opacity: 1; }
	50% { opacity: .1; }
	100% { opacity: 1; }
`;

const CLSItem = styled.div`
  padding: 7px 10px;
  display: flex;
  width: 33.33%;
  border-bottom: 2px solid #000;
  border-right: 2px solid #000;
  height: calc((100vh - 180px) / 7);
  @media (min-width: 800px) {
    padding: 10px;
    justify-content: center;
  }
  @media (min-width: 1300px) {
    padding: 10px;
    justify-content: center;
  }
`;

const ItemWrap = styled.div`
  width: ${props => (props.isNew ? '87%' : '100%')};
`;

const ItemBadge = styled.div`
  width: 13%;
  transform: translate(10px, -10px);
`;

const Badge = styled.span`
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100%;
  color: #fff;
  background: red;
  height: 30px;
  font-weight: 600;
  font-size: 18px;
  position: relative;
  overflow: hidden;
  animation: ${BadgeLight} linear 1s infinite;
`;

const ItemCLSName = styled.p`
  text-transform: uppercase;
  font-weight: bold;
  font-size: 18px;
  margin: 0;
  color: ${props => (props.color ? props.color : '#000')};
  @media (min-width: 800px) {
    font-size: 1.1rem;
  }
  @media (min-width: 1360px) {
    font-size: 1.6rem;
  }
`;

const ItemDetail = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;
`;

const DetailService = styled.p`
  font-size: 12px;
  padding-top: 5px;
  margin: 0;
  display: flex;
  align-items: flex-start;
  justify-content: space-between;
  color: ${({ color }) => (color ? color : '#000')};
  text-align: ${({ align }) => (align ? align : 'inherit')};
  @media (min-width: 800px) {
    font-size: 12px;
  }
  @media (min-width: 1360px) {
    font-size: 18px;
  }
  @media (min-width: 1700px) {
    font-size: 1.5rem;
  }
  @media (min-width: 800px) and (max-height: 800px) {
    flex-direction: row;
  }
`;

const ServiceTitle = styled.span`
  display: block;
  margin-right: 5px;
  color: inherit;
  @media (min-width: 800px) {
    margin: 0;
  }
`;

const ServiceText = styled.span`
  display: block;
  color: inherit;
`;

export function ItemCLS(props) {
  if (isEmpty(props)) return <CLSItem />;
  return (
    <CLSItem {...props}>
      <ItemWrap isNew={props.isNew}>
        {props.full_name.length > 25 ? (
          <ScrollText>
            <ItemCLSName>{props.full_name || ''}</ItemCLSName>
          </ScrollText>
        ) : (
          <ItemCLSName>{props.full_name || ''}</ItemCLSName>
        )}
        <ItemDetail>
          <DetailService>
            <ServiceTitle>{props.gender || ''} / </ServiceTitle>{' '}
            <ServiceText>{props.age || 0} Tuổi</ServiceText>
          </DetailService>
        </ItemDetail>
      </ItemWrap>
      {props.isNew && (
        <ItemBadge>
          <Badge>Mới</Badge>
        </ItemBadge>
      )}
    </CLSItem>
  );
}

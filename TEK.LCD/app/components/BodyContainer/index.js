/* eslint-disable prettier/prettier */
import styled from 'styled-components';
import { DEFAULT_COLOR } from '../../containers/App/helper';
export const BodyContainer = styled.div`
  width: 100%;
  height: 80%;
  display: block;
  margin: 0;
  > div:first-child {
    border-right: ${props => props.loading > 3 ? `10px solid ${DEFAULT_COLOR}` : 'none'}
  }
`;

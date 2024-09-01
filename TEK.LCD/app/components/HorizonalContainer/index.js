import styled from 'styled-components';
import { DEFAULT_COLOR } from '../../containers/App/helper';

export const HorizontalContainer = styled.div`
  width: 100%;
  height: 80%;
  display: flex;
  flex-wrap: wrap;
  > div:nth-child(2n + 1) {
    border-right: 10px solid ${DEFAULT_COLOR};
  }
`;

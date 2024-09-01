/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
/* eslint-disable react/react-in-jsx-scope */
import React, { memo } from 'react';
import styled from 'styled-components';
import * as Global from 'containers/App/selectors';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer } from 'utils/injectReducer';
import { isEmpty } from 'lodash';
import appReducer, { key } from 'containers/App/reducer';
import { DEFAULT_COLOR } from '../../containers/App/helper';
import { AppConfig } from '../../public/appConfig';

export const FooterWrapper = styled.footer`
  width: 100%;
  height: 5%;
  overflow: hidden;
  display: flex;
  align-items: center;
  justify-content: center;
  > div {
    font-size: 10px;
    line-height: 1.3;
    color: ${DEFAULT_COLOR};
    font-weight: bold;
    @media (min-width: 800px) {
      font-size: 0.7rem;
    }
    @media (min-width: 1360px) {
      font-size: 0.8rem;
    }
  }
`;

function FooterContain({ setting }) {
  useInjectReducer({ key, reducer: appReducer });

  const validateSetting = () => {
    if (
      isEmpty(setting) ||
      isEmpty(setting.value.options_footer[0]) ||
      isEmpty(setting.value.options_footer[0].value)
    ) {
      return AppConfig.APP_FOOTER_SLOGAN;
    }
    return setting.value.options_footer[0].value;
  };

  return (
    <FooterWrapper>
      <div>{validateSetting()}</div>
    </FooterWrapper>
  );
}

const mapStateToProps = createStructuredSelector({
  setting: Global.selectSystemSetting(),
});

const withConnect = connect(
  mapStateToProps,
  null,
);

export const FooterContainer = compose(
  withConnect,
  memo,
)(FooterContain);

/* eslint-disable import/order */
/* eslint-disable no-unused-vars */
/* eslint-disable jsx-a11y/alt-text */
import React, { memo } from 'react';
import * as Global from 'containers/App/selectors';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import propTypes from 'prop-types';
import styled from 'styled-components';
import logo from '../../images/logo-wrap.jpg';

const LogoWrapper = styled.div`
  padding: 8px 0px;
  border: 1px solid black;
`;

const LogoContain = styled.div`
  font-weight: bold;
  margin-top: 5px;
  text-align: center;
`;

WrapLogo.propTypes = {
  system: propTypes.any,
  styleWrapper: propTypes.any,
  styleImg: propTypes.any,
  styleContain: propTypes.any,
};

export function WrapLogo({ system, ...props }) {
  return (
    <LogoWrapper style={{ ...props.styleWrapper }}>
      <LogoContain style={{ ...props.styleContain }}>
        <img src={logo} className="logo" style={{ ...props.styleImg }} />
      </LogoContain>
    </LogoWrapper>
  );
}

const mapStateToProps = createStructuredSelector({
  system: Global.selectSystemSetting(),
});

const withConnect = connect(
  mapStateToProps,
  null,
);

export default compose(
  withConnect,
  memo,
)(WrapLogo);

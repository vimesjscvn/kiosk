/* eslint-disable consistent-return */
/* eslint-disable no-console */
/* eslint-disable prettier/prettier */
/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
/* eslint-disable indent */
/* eslint-disable react/react-in-jsx-scope */
/* eslint-disable prettier/prettier */
import React, { memo } from 'react';
import styled from 'styled-components';
import * as Global from 'containers/App/selectors';
import { connect } from 'react-redux';
import { isEmpty } from 'lodash';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import logo from '../../images/logo-wrap.jpg';

const HeaderLogoWrapper = styled.div`
  width: 25%;
  height: auto;
  display: flex;
`;
const ImgWrapper = styled.p`
  margin: auto;
`;

const Img = styled.img`
  width: 100%;
`;

function HeaderLogo({ system }) {
  if (isEmpty(system)) return;
  return (
    <HeaderLogoWrapper>
      <ImgWrapper>
        <Img src={logo} />
      </ImgWrapper>
    </HeaderLogoWrapper>
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
)(HeaderLogo);

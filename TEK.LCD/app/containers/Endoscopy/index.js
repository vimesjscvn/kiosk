/* eslint-disable camelcase */
/* eslint-disable array-callback-return */
/* eslint-disable func-names */
/* eslint-disable no-unused-vars */
/* eslint-disable react/jsx-curly-brace-presence */
/* eslint-disable no-unused-expressions */
/* eslint-disable no-plusplus */
/* eslint-disable no-empty */
/* eslint-disable no-return-assign */
/* eslint-disable consistent-return */
/* eslint-disable arrow-body-style */
/* eslint-disable react/no-array-index-key */
/* eslint-disable no-multi-assign */
/* eslint-disable no-param-reassign */
/* eslint-disable prettier/prettier */
/* eslint-disable no-console */
/* eslint-disable import/order */
/* eslint-disable react/no-unused-prop-types */
/* eslint-disable prettier/prettier */
/* eslint-disable react/prop-types */
/* eslint-disable prettier/prettier */
/* eslint-disable no-undef */
/* eslint-disable prettier/prettier */
/* eslint-disable indent */
import React, { useEffect, memo, useRef, useState, useMemo } from 'react';
import * as Global from 'containers/App/selectors';
import * as appActions from 'containers/App/actions';
import * as _ from 'lodash';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { formatCallNumber, ROOM_ENDSCOPY, GROUP_KEY } from '../App/helper';
import { createStructuredSelector } from 'reselect';
import { AppContainer } from 'components/AppContainer';
import { AppHeader } from 'components/AppHeader';
import { Main } from 'components/Main';
import { BodyContainer } from 'components/BodyContainer';
import { AppConfig } from '../../public/appConfig';
import { EndoTable } from './components/EndoTable';
import HeaderLogo from 'components/AppHeaderLogo';
import AppHeaderTitle from 'components/AppHeaderTitle';
import DateTime from 'components/DateTime';
import propTypes from 'prop-types';
import styled from 'styled-components';

export const STTWrapper = styled.div`
  width: 100%;
  height: 100%;
  display: inline-block;
  border-right: none !important;
  text-transform: uppercase;
`;

export function EndoContainer({ tables }) {
  return (
    <STTWrapper>
      <EndoTable tables={tables} />
    </STTWrapper>
  );
}

Endoscopy.propTypes = {
  system: propTypes.object,
  listRoomEndoscopy: propTypes.array,
  endoscopyList: propTypes.array,
  getNumberRoomEndoscopy: propTypes.func,
  clearEndoscopyList: propTypes.func,
};

export function Endoscopy({
  system,
  endoscopyList = [],
  listRoomEndoscopy,
  ...props
}) {
  const orderedEndoscopyList = useMemo(
    () => _.orderBy(endoscopyList, 'display_order'),
    [endoscopyList],
  );

  const timerRef = useRef();
  const [group, setGroup] = useState({});

  useEffect(() => {
    function callNumber(tabs) {
      if (!tabs.length) return;
      props.getNumberRoomEndoscopy(
        formatCallNumber(
          tabs.map(tab => ({
            ...tab,
            date: new Date(),
          })),
        ),
      );
    }

    function intervalCallNumber(tabs) {
      callNumber(tabs);
      if (timerRef.current) {
        clearInterval(timerRef.current);
      }
      timerRef.current = setInterval(
        callNumber.bind(callNumber, tabs),
        AppConfig.TNB_TIMER,
      );
    }

    function reduceCall() {
      const cacheRoom = JSON.parse(localStorage.getItem(ROOM_ENDSCOPY));
      const cacheGroup = JSON.parse(localStorage.getItem(GROUP_KEY));
      if (cacheGroup) {
        setGroup(cacheGroup);
      }
      if (cacheRoom && cacheRoom.length) {
        intervalCallNumber(cacheRoom);
      }
    }

    reduceCall();
    return () => {
      if (timerRef.current) {
        clearInterval(timerRef.current);
      }
      props.clearEndoscopyList();
    };
  }, []);

  return (
    <AppContainer>
      <Main>
        <AppHeader>
          <DateTime {...props} />
          <AppHeaderTitle
            title={_.isEmpty(group) ? '' : _.get(group, 'description')}
            isRoom={false}
          />

          <HeaderLogo />
        </AppHeader>
        <BodyContainer col={endoscopyList.length}>
          <EndoContainer tables={orderedEndoscopyList} />
        </BodyContainer>
      </Main>
    </AppContainer>
  );
}

const mapStateToProps = createStructuredSelector({
  system: Global.selectSystemSetting(),
  listRoomEndoscopy: Global.selectListRoomEndoscopy(),
  endoscopyList: Global.selectEndoscopy(),
});

const mapDispatchToProps = dispatch => ({
  getNumberRoomEndoscopy: depts =>
    dispatch(appActions.getNumberRoomEndoscopy(depts)),
  clearEndoscopyList: () => dispatch(appActions.clearEndoscopyList()),
});

const withConnect = connect(
  mapStateToProps,
  mapDispatchToProps,
);
export default compose(
  withConnect,
  memo,
)(Endoscopy);

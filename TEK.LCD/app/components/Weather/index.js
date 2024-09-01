/* eslint-disable no-bitwise */
/* eslint-disable react/prop-types */
/* eslint-disable no-undef */
/* eslint-disable no-unused-vars */
import React from 'react';
import * as Global from 'containers/App/selectors';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import propTypes from 'prop-types';
import logoWeather from 'images/LOGO4.png';

Weather.propTypes = {
  temperature: propTypes.any,
};

function Weather({ temperature }) {
  return (
    <div className="wrapWeather">
      <img src={logoWeather} className="weatherIcon" alt="weather" />
      {/* <h1 className="text degree">{temperature | '21'} ºC</h1> */}
    </div>
  );
}

const mapStateToProps = createStructuredSelector({
  temperature: Global.selectTemperature(),
});

const withConnect = connect(
  mapStateToProps,
  null,
);

export default compose(withConnect)(Weather);

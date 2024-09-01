/* eslint-disable jsx-a11y/alt-text */
/* eslint-disable import/order */
import React, { useState, useEffect, memo } from 'react';
import * as Util from '../../utils/Function';
import * as Global from 'containers/App/selectors';
import { createStructuredSelector } from 'reselect';
import { isEmpty } from 'lodash';
import { connect } from 'react-redux';
import { compose } from 'redux';
import LoadingIndicator from '../LoadingIndicator';
// import WeatherIcon from '../../images/LOGO4.png';
import propTypes from 'prop-types';
import styled from 'styled-components';
import logo from '../../images/logo-wrap.jpg';

const Wrapper = styled.div`
  height: 50%;
  border: 1px solid black;
  background: rgb(0, 38, 255);
  display: flex;
  justify-content: center;
  flex-direction: column;
  align-items: center;
  background: white;
  justify-content: space-evenly;
`;

const TextDay = styled.h1`
  color: black;
  font-size: 20px;
  font-weight: 500;
  text-align: center;
  text-transform: capitalize;
`;

const TextHour = styled.h1`
  font-size: 30px;
  font-weight: bold;
  margin: 0 auto;
  @media (min-width: 800px) {
    font-size: 45px;
  }
  @media (min-width: 800px) and (min-height: 600px) {
    font-size: 25px;
  }
`;

const TextDate = styled.h2`
  color: black;
  font-size: 20px;
  font-weight: 500;
  text-align: center;
  @media (max-width: 1400px) {
    font-size: 16px;
  }
`;

const WeatherWrapper = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;
`;

const WeatherImg = styled.img`
  height: 50px;
  width: 50px;
  margin-right: 20px;
  @media (min-width: 800px) {
    height: 80px;
    width: 80px;
  }
  @media (min-width: 800px) and (min-height: 600px) {
    height: 40px;
    width: 40px;
  }
`;

const WeatherNumber = styled.h4`
  font-size: 1.5em;
  font-weight: bold;
`;

const WrapLogo = styled.div``;

const WrapLogoImg = styled.img`
  resize: both;
  display: inline-block;
  width: 100%;
`;

DateTimeWeather.propTypes = {
  temp: propTypes.number,
};

function DateTimeWeather({ temp }) {
  const [currentTime, setCurrentTime] = useState(null);

  useEffect(() => {
    const timer = setInterval(() => {
      setCurrentTime(Util.getCurrentTime());
    }, 1000);
    return () => {
      clearInterval(timer);
    };
  }, []);

  if (isEmpty(currentTime) || !temp) return <LoadingIndicator />;

  return (
    <Wrapper>
      <TextDay>{Util.dayName}</TextDay>
      <TextHour>{currentTime}</TextHour>
      <TextDate>
        Ngày {Util.day} tháng {Util.month} năm {Util.year}
      </TextDate>
      <WeatherWrapper>
        {/* <WeatherImg src={WeatherIcon} /> */}
        {/* <WeatherNumber>{temp} ºC</WeatherNumber> */}
      </WeatherWrapper>
      <WrapLogo>
        <WrapLogoImg src={logo} />
      </WrapLogo>
    </Wrapper>
  );
}

const mapStateToProps = createStructuredSelector({
  temp: Global.selectTemperature(),
});

const withConnect = connect(
  mapStateToProps,
  null,
);

export default compose(
  withConnect,
  memo,
)(DateTimeWeather);

/* eslint-disable no-unused-vars */
import React from 'react';
import ReactPlayer from 'react-player';
import propTypes from 'prop-types';
import { AppConfig } from 'public/appConfig';

MediaPlayer.propTypes = {
  style: propTypes.object,
};

export default function MediaPlayer({ style }) {
  return (
    <ReactPlayer
      loop
      playing
      url={AppConfig.URL_VIDEO}
      style={{ flex: 1, height: '100%' }}
      height="100%"
      width="100%"
      muted
    />
  );
}

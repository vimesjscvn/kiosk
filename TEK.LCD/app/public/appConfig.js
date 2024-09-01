// Load environment variables from .env file
require('dotenv').config();

const baseConfig = {
  CLIENT_KEY: process.env.CLIENT_KEY,
  CLIENT_LOCATION: process.env.CLIENT_LOCATION,
  SETTING_TIMER: process.env.SETTING_TIMER,
  ROOM_TIMER: process.env.ROOM_TIMER,
  TNB_TIMER: process.env.TNB_TIMER,
  CLS_TIMER: process.env.CLS_TIMER,
  CLS_ROW: process.env.CLS_ROW,
  APP_LOGO: process.env.APP_LOGO,
  APP_FOOTER_SLOGAN: process.env.APP_FOOTER_SLOGAN,
  END_POINT: process.env.END_POINT,
  END_POINT_DEPT: process.env.END_POINT_DEPT,
  API_AUDIO_RING: process.env.API_AUDIO_RING,
  URL_VIDEO: process.env.URL_VIDEO,
  API_TEMP_URL: process.env.API_TEMP_URL,
  SUB_URL_API_TEMP: process.env.SUB_URL_API_TEMP,
  API_TEMP_KEY: process.env.API_TEMP_KEY,
  LOCATION: process.env.LOCATION,
  SLIDER_CONFIG: {
    dots: false,
    infinite: true,
    autoplay: true,
    autoplaySpeed: 20000,
    speed: 2000,
    slidesToShow: 1,
    slidesToScroll: 1,
    adaptiveHeight: true,
    arrows: false,
    draggable: false,
  },
};

export const AppConfig = baseConfig;

/* eslint-disable no-plusplus */
/* eslint-disable no-restricted-globals */
/* eslint-disable consistent-return */
/* eslint-disable prettier/prettier */
/* eslint-disable arrow-body-style */
/* eslint-disable no-console */
/* eslint-disable no-redeclare */
/* eslint-disable block-scoped-var */
/* eslint-disable one-var */
/* eslint-disable no-bitwise */
/* eslint-disable vars-on-top */
/* eslint-disable prefer-promise-reject-errors */
/* eslint-disable spaced-comment */
/* eslint-disable func-names */
/* eslint-disable no-var */
/* eslint-disable prefer-template */
import * as _ from 'lodash';
import Axios from 'axios';
import moment from 'moment';
import { TYPE_START_KEY } from '../containers/App/helper';
import { AppConfig } from '../public/appConfig';
export const day = moment().format('DD');
export const month = moment().format('MM');
export const year = moment().format('YYYY');

export const getCurrentTime = () => {
  let hour = new Date().getHours();
  let minutes = new Date().getMinutes();
  let seconds = new Date().getSeconds();

  if (minutes < 10) {
    minutes = '0' + minutes;
  }

  if (seconds < 10) {
    seconds = '0' + seconds;
  }

  // if (hour > 12) {
  //   hour = hour;
  // }

  if (hour === 24) {
    hour = '0' + 0;
  }

  return hour + ':' + minutes;
};

export const formDateTime = () => {
  return moment(new Date()).format('YYYY-MM-DD');
};

const days = [
  'Chủ Nhật',
  'Thứ hai',
  'Thứ ba',
  'Thứ tư',
  'Thứ năm',
  'Thứ sáu',
  'Thứ bảy',
];
export const d = new Date();
export const dayName = days[d.getDay()];
export const getOld = date => {
  const ageDifMs = Date.now() - date.getTime();
  const ageDate = new Date(ageDifMs); // miliseconds from epoch
  return Math.abs(ageDate.getUTCFullYear() - 1970);
};

export const degree = async () =>
  Axios.get(
    'http://dataservice.accuweather.com/forecasts/v1/daily/1day/353981?apikey=9K4Ldjvg3ogDq9vRb8EFfA8AM8E4WsqQ%20&language=vi',
  ).then(res => {
    const tempAvg =
      (res.data.DailyForecasts[0].Temperature.Maximum.Value +
        res.data.DailyForecasts[0].Temperature.Minimum.Value) /
      2;
    return Math.round(((tempAvg - 32) * 5) / 9);
  });

export const callTemperature = async () => {
  return Axios.get(
    'http://dataservice.accuweather.com/forecasts/v1/daily/1day/353981?apikey=9K4Ldjvg3ogDq9vRb8EFfA8AM8E4WsqQ%20&language=vi',
  )
    .then(res => {
      const tempAvg =
        (res.data.DailyForecasts[0].Temperature.Maximum.Value +
          res.data.DailyForecasts[0].Temperature.Minimum.Value) /
        2;
      return {
        ...res,
        data: Math.round(((tempAvg - 32) * 5) / 9),
        ok: true,
      };
    })
    .catch(ReponseError);
};

function ReponseError(error) {
  return {
    data: {},
    error,
    ok: false,
  };
}

function ReponseSuccess(data) {
  return {
    data,
    ok: true,
  };
}

export function getLocalStorageSetting() {
  const typeStart = JSON.parse(localStorage.getItem(TYPE_START_KEY));
  if (!typeStart) {
    return ReponseError();
  }
  return ReponseSuccess(typeStart);
}

export function getLocalIP() {
  return new Promise(function(resolve, reject) {
    var RTCPeerConnection =
      /*window.RTCPeerConnection ||*/ window.webkitRTCPeerConnection ||
      window.mozRTCPeerConnection;

    if (!RTCPeerConnection) {
      reject({
        message: 'Your browser does not support this API',
        ok: false,
      });
    }

    var rtc = new RTCPeerConnection({ iceServers: [] });
    var addrs = {};
    addrs['0.0.0.0'] = false;

    function grepSDP(sdp) {
      // var hosts = [];
      var finalIP = '';
      sdp.split('\r\n').forEach(function(line) {
        // c.f. http://tools.ietf.org/html/rfc4566#page-39
        if (~line.indexOf('a=candidate')) {
          // http://tools.ietf.org/html/rfc4566#section-5.13
          var parts = line.split(' '), // http://tools.ietf.org/html/rfc5245#section-15.1
            addr = parts[4],
            type = parts[7];
          if (type === 'host') {
            finalIP = addr;
          }
        } else if (~line.indexOf('c=')) {
          // http://tools.ietf.org/html/rfc4566#section-5.7
          var parts = line.split(' '),
            addr = parts[2];
          finalIP = addr;
        }
      });
      return finalIP;
    }

    if (1 || window.mozRTCPeerConnection) {
      // FF [and now Chrome!] needs a channel/stream to proceed
      rtc.createDataChannel('', { reliable: false });
    }

    rtc.onicecandidate = function(evt) {
      // convert the candidate to SDP so we can run it through our general parser
      // see https://twitter.com/lancestout/status/525796175425720320 for details
      if (evt.candidate) {
        var addr = grepSDP('a=' + evt.candidate.candidate);
        resolve({
          data: addr,
          ok: true,
        });
      }
    };
    rtc.createOffer(
      function(offerDesc) {
        rtc.setLocalDescription(offerDesc);
      },
      function(e) {
        console.warn('offer failed', e);
      },
    );
  });
}

export function breakdownArray(list, numerBreak = AppConfig.CLS_ROW) {
  if (!list || !list.length) return list;
  return _.chunk(list, numerBreak);
}

export function createPlaceHolderList(list) {
  if (!_.isEmpty(list) && list.length >= AppConfig.CLS_ROW) return list;
  const placeholders = [];
  for (let i = 0; i < AppConfig.CLS_ROW; i++) {
    const currentItem = list[i];
    if (_.isEmpty(currentItem)) {
      placeholders.push({});
    } else {
      placeholders.push(currentItem);
    }
  }
  return placeholders;
}

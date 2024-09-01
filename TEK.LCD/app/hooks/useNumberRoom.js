/* eslint-disable no-unused-vars */
/* eslint-disable no-console */
import { useEffect, useState } from 'react';
import HtttpRequest from '../utils/api';

export function useNumberRoom(code) {
  const http = new HtttpRequest();
  const [loading, setLoading] = useState(false);
  const [resData, setResData] = useState([]);

  useEffect(() => {
    function callNumberPatientInRoom(room) {
      setLoading(true);
      http
        .multiCastGetPatientInRoom(room)
        .then(res => res)
        .then(response => {
          setResData(
            response.map(({ data }) => ({
              result: data.result,
              message: data.message,
            })),
          );
          setLoading(false);
        })
        .catch(error => {
          setLoading(false);
        });
    }
    if (code !== '') {
      callNumberPatientInRoom(code);
    }
  }, [code]);
  return [loading, resData];
}

/* eslint-disable no-shadow */
/* eslint-disable no-unused-vars */
/* eslint-disable no-console */
import { useEffect, useState } from 'react';
import { isEmpty } from 'lodash';
import HtttpRequest from '../utils/api';

export function useNumberBHYT(body) {
  const http = new HtttpRequest();
  const [loading, setLoading] = useState(false);
  const [resData, setResData] = useState([]);

  useEffect(() => {
    function callNumberBHYT({ code, limit }) {
      setLoading(true);
      http
        .multiCastGetBHYT({ code, limit })
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
    if (!isEmpty(body)) {
      callNumberBHYT(body);
    }
  }, [body]);
  return [loading, resData];
}

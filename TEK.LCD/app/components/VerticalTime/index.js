/* eslint-disable react/prop-types */
import React from 'react';
import { day, month, year, dayName } from 'utils/Function';

export default function VerticalTime({ time }) {
  return (
    <>
      <h1 className="text">{dayName}</h1>
      <h1 className="text hour">{time}</h1>
      <h1 className="text">
        Ngày {day} tháng {month} năm {year}
      </h1>
    </>
  );
}

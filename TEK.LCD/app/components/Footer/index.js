/* eslint-disable react/prop-types */
import React from 'react';
import './style.css';

export default function Footer(props) {
  const { footer } = props;
  return (
    <div className="scroll-left-footer">
      <p>{footer}.</p>
    </div>
  );
}

/* eslint-disable react/button-has-type */
import React from 'react';
import Popup from 'reactjs-popup';
import './ModalCls.css';

export const ModalCLS = (open, onClose) => (
  <Popup closeOnDocumentClick open={open} onClose={onClose}>
    <div className="modal">
      <button className="close">&times;</button>
      <div className="content">
        Lưu ý dữ liệu testing không phải dữ liệu thật
      </div>
      <div className="actions">
        <button className="button" onClick={onclose}>
          Đóng
        </button>
      </div>
    </div>
  </Popup>
);

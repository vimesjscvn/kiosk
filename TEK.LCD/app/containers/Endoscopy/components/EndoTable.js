/* eslint-disable no-restricted-syntax */
/* eslint-disable no-nested-ternary */
/* eslint-disable arrow-body-style */
/* eslint-disable no-underscore-dangle */
/* eslint-disable react/no-array-index-key */
/* eslint-disable no-shadow */
/* eslint-disable react/prop-types */
/* eslint-disable prettier/prettier */
// eslint-disable-next-line prettier/prettier
/* eslint-disable indent */
/* eslint-disable prettier/prettier */
import React, { useEffect, useRef, useState } from 'react';
import styled from 'styled-components';
import SwiperCore, { Autoplay } from 'swiper';
import { Swiper, SwiperSlide } from 'swiper/react';
import { DEFAULT_COLOR, createPlaceWaiting, linkAudio } from '../../App/helper';
import { TableItemEndo } from './TableItemEndo';
// eslint-disable-next-line import/order
import ReactAudioPlayer from 'react-audio-player';
import 'swiper/swiper.min.css';

export const TableColumns = [
  { _id: 1, label: 'Phòng' },
  { _id: 2, label: 'Dịch vụ' },
  { _id: 3, label: 'Người Bệnh Đang Thực Hiện' },
  { _id: 4, label: 'STT' },
];

export const Table = styled.div`
  flex: 1;
  display: flex;
  flex-direction: column;
  height: 100%;
`;

export const TableHead = styled.div`
  width: 100%;
  height: 15%;
  font-size: 2rem;
  font-weight: bold;
  color: ${DEFAULT_COLOR};
  display: flex;
  border-bottom: 10px solid ${DEFAULT_COLOR};
  border-left: 4px solid ${DEFAULT_COLOR};
  border-right: 4px solid ${DEFAULT_COLOR};
  background: rgb(227, 246, 255);
  > div {
    text-transform: uppercase;
  }
  > div:nth-child(1) {
    width: 15%;
    border-right: 4px solid ${DEFAULT_COLOR};
  }
  > div:nth-child(2) {
    width: 30%;
    border-right: 4px solid ${DEFAULT_COLOR};
  }
  > div:nth-child(3) {
    width: 35%;
    font-size: 1.5rem;
    border-right: 4px solid ${DEFAULT_COLOR};
  }
  > div:nth-child(4) {
    width: 20%;
    color: #de1111;
  }

  @media (max-width: 1361px) {
    font-size: 2rem;
    > span:nth-child(2) {
    }
    @media (min-width: 1250px) {
      font-size: 1.7rem;
    }
  }
`;

export const TableHeading = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 3rem;
  @media (max-width: 1300px) {
    font-size: 2rem;
    line-height: 1.1;
  }
`;

export const TableBody = styled.div`
  width: 100%;
  overflow: hidden;
  border-bottom: 4px solid ${DEFAULT_COLOR};
  height: 85%;
`;

export function EndoTable({ tables, number }) {
  const audioQueueRef = useRef([]);
  const [audioSrc, setAudioSrc] = useState('');
  const isPlayingRef = useRef(false);
  useEffect(() => {
    for (const table of tables) {
      if (
        table.department_id &&
        table.isChangeNormal &&
        table.normal_audio_url
      ) {
        const dept = audioQueueRef.current.find(
          a => a.department_id === table.department_id,
        );
        if (dept) {
          if (dept.normal_number === table.normal_number) break;
          audioQueueRef.current = audioQueueRef.current.filter(
            a => a.department_id !== table.department_id,
          );
        }
        audioQueueRef.current.push(table);
      }
    }
    nextAudio();
  }, [tables]);
  useEffect(() => {
    if (audioSrc !== '') return;
    nextAudio();
  }, [audioSrc]);
  const nextAudio = () => {
    if (isPlayingRef.current) return;
    const current = audioQueueRef.current
      ? audioQueueRef.current[0]
      : undefined;
    if (current) {
      setAudioSrc(linkAudio(current.normal_audio_url));
      // setAudioSrc(
      //   'http://uat.api.admin.bvk.tekmedi.com//Audio//7//Normal_KB_PKVU_18number_result.wav',
      // );
      // setAudioSrc(
      //   `http://uat.api.admin.bvk.tekmedi.com/${current.normal_audio_url}`,
      // );
      audioQueueRef.current = audioQueueRef.current.filter(a => a !== current);
      isPlayingRef.current = true;
    } else {
      setAudioSrc('');
      isPlayingRef.current = false;
    }
  };

  if (!tables.length) return <></>;
  SwiperCore.use([Autoplay]);
  return (
    <>
      <Table>
        <TableHead>
          {TableColumns.map(col => (
            <TableHeading key={col._id}>{col.label}</TableHeading>
          ))}
        </TableHead>
        {tables.length > 5 ? (
          <Swiper
            loop
            rewind
            autoplay={{
              delay: 8000,
            }}
            speed={1200}
            longSwipesMs={300}
            direction="vertical"
            slidesPerView={5}
            slidesPerGroup={5}
            style={{ width: '100%', flex: 1 }}
          >
            {createPlaceWaiting(tables).map((table, idx) => (
              <SwiperSlide key={idx}>
                <TableItemEndo table={table} number={tables.length} />
              </SwiperSlide>
            ))}
          </Swiper>
        ) : (
          <TableBody>
            {tables.map((table, idx) => (
              <TableItemEndo table={table} key={idx} number={tables.length} />
            ))}
          </TableBody>
        )}
      </Table>
      {audioSrc !== '' && (
        <ReactAudioPlayer
          src={audioSrc}
          autoPlay
          onEnded={() => {
            isPlayingRef.current = false;
            setAudioSrc('');
          }}
          onError={() => {
            isPlayingRef.current = false;
            setAudioSrc('');
          }}
        />
      )}
    </>
  );
}

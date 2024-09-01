/* eslint-disable prefer-template */
/* eslint-disable react/no-unescaped-entities */
/* eslint-disable prettier/prettier */
/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
/* eslint-disable indent */
/* eslint-disable react/react-in-jsx-scope */
/* eslint-disable prettier/prettier */
import React from 'react';
import styled from 'styled-components';
import { isEmpty } from 'lodash';
import { DOCTOR_KEY , DEFAULT_COLOR } from 'containers/App/helper';


export const HeaderTitle = styled.div`
    width: 50%;
    height: auto;
    border-right: 10px solid ${DEFAULT_COLOR};
    padding: 0;
    margin: 0;
    color: ${DEFAULT_COLOR};
    text-align: center;
    font-size: 2.5rem;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    padding: 1rem;
    > * { 
    margin: 0;
    padding: 0;
    }
`

const TitleText = styled.p`
    margin: auto;
    text-transform: uppercase;
    font-weight: 700;
    @media (max-width: 1361px) {
        font-size: 2.8rem;
    }
`

const TitleHeading = styled.h2`
    font-weight: bold;
    font-size: 2.5rem;
    text-transform: uppercase;
    @media (max-width: 1770px) {
        font-size: 2.4rem;
    }
    @media (max-width: 1361px) {
        font-size: 1.5rem;
        font-weight: 600;
        line-height: 40px;
    }
`;


export default function AppHeaderTitle({ isRoom, room, title }) {
  const doctorName = localStorage.getItem(DOCTOR_KEY);
    return (
        <HeaderTitle>
            { isRoom ? (
                <>
                    <TitleText>{!isEmpty(room) ? room.description : ''}</TitleText>
                    {!isEmpty(room) && doctorName !== '' && <TitleHeading>{doctorName}</TitleHeading>}
                </>
            ) : (
                <>
                    <TitleText>{ title } </TitleText>
                </>
            )}
            
        </HeaderTitle>
    )
}
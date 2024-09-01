import { createGlobalStyle } from 'styled-components';

import Rockwell from './Rockwell.woff';
import Rockwell2 from './Rockwell.woff2';
import TimesNewRoman from './TimesNewRoman.woff';
import TimesNewRoman2 from './TimesNewRoman.woff2';
export default createGlobalStyle`
    @font-face {
        font-family: 'RockWell';
        src: url(${Rockwell2}) format('woff2'),
        url(${Rockwell}) format('woff');
        font-weight: 400;
        marginTop: 4px;
        font-style: normal;
    }
    @font-face {
        font-family: 'Times New Roman';
        src: local('Times New Roman'), local('TimesNewRoman'),
        url(${TimesNewRoman2}) format('woff2'),
        url(${TimesNewRoman}) format('woff');
        font-weight: 500;
        font-style: normal;
    }
`;

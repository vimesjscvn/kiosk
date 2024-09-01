/* eslint-disable no-restricted-syntax */
/* eslint-disable prefer-const */
/* eslint-disable guard-for-in */
import { isEmpty, camelCase, first } from 'lodash';
export class SettingModel {
  constructor({ key, value }) {
    this.key = key;
    this.logosUrl = '';
    this.optionBackground = '';
    this.optionColor = '';
    this.optionColorByPriority = '';
    this.optionHospital = '';
    this.optionsFont = '';
    this.optionsFooter = '';
    this.optionsSizeFont = '';
    this.optionsSl = '';
    this.optionsStartBanner = '';
    this.optionsTimeBanner = '';
    this.convertSetting(value);
  }

  convertSetting(settingValue) {
    if (isEmpty(settingValue)) {
      throw new Error('Empty Object SettingValue');
    }
    for (let i in settingValue) {
      this[camelCase(i)] = first(settingValue[i]);
    }
    return this;
  }
}

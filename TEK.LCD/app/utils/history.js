/* eslint-disable default-case */
import { createBrowserHistory } from 'history';
import { TypesStart, ROUTING } from '../containers/App/helper';

const history = createBrowserHistory();
export default history;

export function redirectWithTypeStart(typeStart) {
  switch (typeStart) {
    case TypesStart.TNB:
      history.push(ROUTING.TNB);
      break;
    case TypesStart.ROOM:
      history.push(ROUTING.ROOM);
      break;
    case TypesStart.ROOM_CLS:
      history.push(ROUTING.ROOM_CLS);
      break;
    case TypesStart.CPS:
      history.push(ROUTING.CPS);
      break;
    case TypesStart.CLS:
      history.push(ROUTING.CLS);
      break;
    case TypesStart.THUOCBHYT:
      history.push(ROUTING.THUOCBHYT);
      break;
    case TypesStart.NOISOI:
      history.push(ROUTING.NOISOI);
      break;
    default:
      history.push(ROUTING.HOME);
      break;
  }
}

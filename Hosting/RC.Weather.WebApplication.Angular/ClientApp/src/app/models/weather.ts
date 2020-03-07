import { ICity } from "./city";
import { ICondition } from "./condition";

export interface IWeather extends ICondition {
  city: ICity;
}

import { ICity } from "./city";
import { FavoriteAction } from "./enum.favorite-action";

export interface IFavorite {
  city: ICity;
  action: FavoriteAction;
}

import { Component, Input, Output, EventEmitter } from "@angular/core";
import { Router } from "@angular/router";
import { ICity } from "../models/city";
import { IWeather } from "../models/weather";
import { IFavorite } from "../models/favorite";
import { FavoriteAction } from "../models/enum.favorite-action";
import { FavoritesService } from "../services/favorites-service";

@Component({
  selector: 'app-conditions',
  templateUrl: './conditions.component.html',
  styleUrls: ['./conditions.component.css']
})
export class ConditionsComponent {

  private isCityRemovable: boolean;

  @Input() public weather: IWeather;
  @Output() public removedFromFavorites: EventEmitter<IFavorite> = new EventEmitter();

  constructor(
    private router: Router,
    private favoritesService: FavoritesService) {
    this.isCityRemovable = /favorites/.test(this.router.url);
  }

  public addToFavorites(city: ICity): void {
    this.favoritesService.add(city).subscribe(response => {
      this.weather.isFavorite = true;
    });
  }

  public removeFromFavorites(city: ICity): void {
    this.favoritesService.delete(city).subscribe(response => {
      this.weather.isFavorite = false;
      this.isCityRemovable && this.removedFromFavorites.emit({ action: FavoriteAction.Delete, city: city });
    });
  }

}

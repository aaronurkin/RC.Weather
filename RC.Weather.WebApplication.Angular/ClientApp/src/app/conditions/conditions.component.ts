import { Component, Input } from "@angular/core";
import { IWeather } from "../models/weather";
import { FavoritesService } from "../services/favorites-service";
import { ICity } from "../models/city";

@Component({
  selector: 'app-conditions',
  templateUrl: './conditions.component.html',
  styleUrls: ['./conditions.component.css']
})
export class ConditionsComponent {

  @Input() public weather: IWeather;

  constructor(private favoritesService: FavoritesService) {
  }

  public addToFavorites(city: ICity): void {
    this.favoritesService.add(city).subscribe(response => {
      this.weather.isFavorite = true;
    });
  }

  public removeFromFavorites(city: ICity): void {
    this.favoritesService.delete(city).subscribe(response => {
      this.weather.isFavorite = false;
    });
  }

}

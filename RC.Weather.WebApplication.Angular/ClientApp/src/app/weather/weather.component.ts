import { Component, Input } from '@angular/core';
import { ICity } from '../models/city';
import { IWeather } from '../models/weather';
import { WeatherService } from '../services/weather.service';
import { IFavorite } from '../models/favorite';
import { FavoriteAction } from '../models/enum.favorite-action';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent {

  @Input() public cities: ICity[];

  public weather: IWeather;

  constructor(private weatherService: WeatherService) {
  }

  public getConditions(city: ICity): void {

    this.weatherService.get(city.code).subscribe(condition => {
      this.weather = <IWeather>condition;
      this.weather.city = city;
    });
  }

  public reloadCities(favorite: IFavorite): void {

    switch (favorite.action) {
      case FavoriteAction.Add:
        this.cities.push(favorite.city);
        break;
      case FavoriteAction.Delete:
        this.cities = this.cities.filter(c => c.code != favorite.city.code);
        break;
      default:
        throw new Error(`Unknown favorite action: ${favorite.action}`);
    }

  }
}

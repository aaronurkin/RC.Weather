import { Component, Input } from '@angular/core';
import { ICity } from '../models/city';
import { IWeather } from '../models/weather';
import { WeatherService } from '../services/weather.service';

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
}

import { Component } from '@angular/core';
import { ICity } from '../models/city';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public cities: ICity[];

  public reloadCities(cities: ICity[]): void {
    this.cities = cities;
  }
}

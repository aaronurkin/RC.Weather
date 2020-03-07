import { Component, Output, EventEmitter } from '@angular/core';
import { CityService } from '../services/city.service';
import { ICity } from '../models/city';

@Component({
  selector: 'app-city-search',
  templateUrl: './city-search.component.html',
  styleUrls: ['./city-search.component.css']
})
export class CitySearchComponent {

  @Output() citiesLoaded: EventEmitter<ICity[]> = new EventEmitter();

  constructor(private citiesService: CityService) {
  }

  public getCities(cityName: string): void {
    this.citiesService.search(cityName).subscribe(cities => {
      this.citiesLoaded.emit(cities);
    });
  }

}

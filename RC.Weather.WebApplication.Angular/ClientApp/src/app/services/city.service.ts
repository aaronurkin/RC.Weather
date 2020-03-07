import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ICity } from '../models/city';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../environments/environment';

@Injectable()
export class CityService {

  private citiesEndpoint: string = `${environment.weatherApi.baseUrl}/${environment.weatherApi.citiesEndpoint}`;

  constructor(private http: HttpClient) {
  }

  public search(cityName: string): Observable<ICity[]> {
    return this.http.get<ICity[]>(`${this.citiesEndpoint}?term=${cityName}`);
  }

}

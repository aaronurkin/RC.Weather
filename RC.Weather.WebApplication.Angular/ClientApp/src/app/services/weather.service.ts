import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../environments/environment';
import { ICondition } from '../models/condition';

@Injectable()
export class WeatherService {

  private weatherEndpoint: string = `${environment.weatherApi.baseUrl}/${environment.weatherApi.weatherEndpoint}`;

  constructor(private http: HttpClient) {
  }

  public get(cityCode: string): Observable<ICondition> {
    return this.http.get<ICondition>(`${this.weatherEndpoint}?cityCode=${cityCode}`);
  }

}

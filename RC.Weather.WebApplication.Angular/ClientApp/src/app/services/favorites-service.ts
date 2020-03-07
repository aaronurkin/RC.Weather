import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ICity } from '../models/city';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../environments/environment';

@Injectable()
export class FavoritesService {

  private favoritesEndpoint: string = `${environment.weatherApi.baseUrl}/${environment.weatherApi.favoritesEndpoint}`;

  constructor(private http: HttpClient) {
  }

  public get(): Observable<ICity[]> {
    return this.http.get<ICity[]>(this.favoritesEndpoint);
  }

  public add(city: ICity): Observable<any> {
    return this.http.post(this.favoritesEndpoint, city);
  }

  public delete(city: ICity): Observable<any> {
    return this.http.delete(`${this.favoritesEndpoint}/${city.code}`);
  }

}

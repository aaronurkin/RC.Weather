import { Component, OnInit } from '@angular/core';
import { ICity } from '../models/city';
import { FavoritesService } from '../services/favorites-service';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css']
})
export class FavoritesComponent implements OnInit {

  public cities: ICity[];

  constructor(private favoritesService: FavoritesService) {
  }

  ngOnInit(): void {
    this.favoritesService.get().subscribe(cities => {
      this.cities = cities;
    });
  }

}

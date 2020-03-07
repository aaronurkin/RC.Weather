import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { WeatherComponent } from './weather/weather.component';
import { NavigateComponent } from './navigate/navigate.component';
import { FavoritesComponent } from './favorites/favorites.component';
import { PageTitleComponent } from './page-title/page-title.component';
import { ConditionsComponent } from './conditions/conditions.component';
import { CitySearchComponent } from './city-search/city-search.component';

import { FavoritesService } from './services/favorites-service';
import { CityService } from './services/city.service';
import { WeatherService } from './services/weather.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    WeatherComponent,
    NavigateComponent,
    FavoritesComponent,
    PageTitleComponent,
    ConditionsComponent,
    CitySearchComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'favorites', component: FavoritesComponent }
    ])
  ],
  providers: [
    CityService,
    WeatherService,
    FavoritesService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

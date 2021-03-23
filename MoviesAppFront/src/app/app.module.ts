import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AuthServiceService } from './Services/auth-service.service';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from './navbar/navbar.component';
import { CategoryListComponent } from './Category/category-list/category-list.component';
import { CategoryService } from './Services/category.service';
import { CreateCategoryComponent } from './Category/create-category/create-category.component';
import { UpdateCategoryComponent } from './Category/update-category/update-category.component';
import { ActorListComponent } from './Actor/actor-list/actor-list.component';
import { CreateActorComponent } from './Actor/create-actor/create-actor.component';
import { ActorService } from './Services/actor.service';
import { MoviesListComponent } from './Movies/movies-list/movies-list.component';
import { CreateMovieComponent } from './Movies/create-movie/create-movie.component';
import { DeleteMovieComponent } from './Movies/delete-movie/delete-movie.component';
import { UpdateMovieComponent } from './Movies/update-movie/update-movie.component';
import { MovieDetailsComponent } from './Movies/movie-details/movie-details.component';
import { MovieService } from './Services/movie.service';
import { FilterPipe } from './Pipe/filter.pipe';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    NavbarComponent,
    CategoryListComponent,
    CreateCategoryComponent,
    UpdateCategoryComponent,
    ActorListComponent,
    CreateActorComponent,
    MoviesListComponent,
    CreateMovieComponent,
    DeleteMovieComponent,
    UpdateMovieComponent,
    MovieDetailsComponent,
    FilterPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [AuthServiceService,CategoryService,ActorService,MovieService],
  bootstrap: [AppComponent]
})
export class AppModule { }

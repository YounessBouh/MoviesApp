import { createComponent } from '@angular/compiler/src/core';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ActorListComponent } from './Actor/actor-list/actor-list.component';
import { CreateActorComponent } from './Actor/create-actor/create-actor.component';
import { CategoryListComponent } from './Category/category-list/category-list.component';
import { CreateCategoryComponent } from './Category/create-category/create-category.component';
import { UpdateCategoryComponent } from './Category/update-category/update-category.component';
import { LoginComponent } from './login/login.component';
import { CreateMovieComponent } from './Movies/create-movie/create-movie.component';
import { DeleteMovieComponent } from './Movies/delete-movie/delete-movie.component';
import { MovieDetailsComponent } from './Movies/movie-details/movie-details.component';
import { MoviesListComponent } from './Movies/movies-list/movies-list.component';
import { UpdateMovieComponent } from './Movies/update-movie/update-movie.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './Services/auth-guard.service';


const routes: Routes = [

  {path:"Register",component:RegisterComponent},
  {path:"Login",component:LoginComponent},
  {path:"NewCategory",component:CreateCategoryComponent,canActivate:[AuthGuardService]},
  {path:"UpdateCategory/:id",component:UpdateCategoryComponent,canActivate:[AuthGuardService]},
  {path:"Categories",component:CategoryListComponent,canActivate:[AuthGuardService]},
  {path:"Actors",component:ActorListComponent,canActivate:[AuthGuardService]},
  {path:"NewMovie",component:CreateMovieComponent,canActivate:[AuthGuardService]},
  {path:"NewActor",component:CreateActorComponent,canActivate:[AuthGuardService]},
  {path:"Movies",component:MoviesListComponent},
  {path:"Movies/:id",component:MovieDetailsComponent},
  {path:"DeleteMovie",component:DeleteMovieComponent,canActivate:[AuthGuardService]},
  {path:"UpdateMovie/:id",component:UpdateMovieComponent,canActivate:[AuthGuardService]},
  {path:"**",component:MoviesListComponent},

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

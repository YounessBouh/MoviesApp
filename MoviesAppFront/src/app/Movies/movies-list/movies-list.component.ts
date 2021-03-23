import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/Models/Movie';
import { MovieService } from 'src/app/Services/movie.service';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.css']
})
export class MoviesListComponent implements OnInit {

  path="/assets/Images/"
  filterByCategory=""

  constructor(private movieService:MovieService)
   {
     this.getMovies()
    }
  movies:Movie[]
  ngOnInit(): void {
  }

  getMovies()
  {
    return this.movieService.getMovies().subscribe(
      data=>{this.movies=data,console.log(this.movies)},error=>{console.log(error)}
    )
  }
  SelectSF()
  {
    this.filterByCategory="bf2ra6d1-a82b-6a65-8ff6-f4480099b3f7"
  }
  SelectAC()
  {
    this.filterByCategory="bf2ra6d1-a82b-6a65-8ff6-f4480099b3f8"
  }
  SelectAD()
  {
    this.filterByCategory="bf2ra6d1-a62b-6a65-8ff6-f4480099b3f8"
  }
  SelectDR()
  {
    this.filterByCategory="bf2ra6d1-a82b-6a65-8ff6-f4480099b3f3"
  }
  SelectDO()
  {
    this.filterByCategory="bf2ra6d1-a82b-6a65-8ff6-f4480099b3f3"
  }


}

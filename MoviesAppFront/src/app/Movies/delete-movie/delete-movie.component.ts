import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from 'src/app/Models/Movie';
import { MovieService } from 'src/app/Services/movie.service';

@Component({
  selector: 'app-delete-movie',
  templateUrl: './delete-movie.component.html',
  styleUrls: ['./delete-movie.component.css']
})
export class DeleteMovieComponent implements OnInit {

movies:Movie[]
path="/assets/Images/"

  constructor(private movieService:MovieService,private router:Router)
  {
     this.getMovies()
  }

  ngOnInit(): void {
  }

  getMovies()
   {
     return this.movieService.getMovies().subscribe(
           data=>{this.movies=data}
     )
   }

   Delete(id)
   {
   this.movieService.deleteMovie(id).subscribe(
     data =>{this.router.navigate(['/Movies'])}
   )
   }

}

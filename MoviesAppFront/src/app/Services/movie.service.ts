import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from '../Models/Movie';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  moviePath="https://localhost:5001/api/Movie"

  constructor(private http:HttpClient) { }

  getMovies():Observable<Movie[]>
  {
    return this.http.get<Movie[]>(this.moviePath+'/GetMoviesList')
  }
  getMovie(id:string):Observable<Movie>
  {
    return this.http.get<Movie>(this.moviePath+'/'+id)
  }
  addMovie(data:FormData):Observable<any>
  {
   return this.http.post(this.moviePath+'/Create',data)
  }
  deleteMovie(id):Observable<any>
  {
     return this.http.delete(this.moviePath+'/'+id)
  }
  update(data:FormData):Observable<any>
  {
    return this.http.put(this.moviePath+'/Update',data)
  }
}

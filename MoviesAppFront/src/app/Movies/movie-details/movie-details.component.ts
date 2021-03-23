import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Movie } from 'src/app/Models/Movie';
import { MovieService } from 'src/app/Services/movie.service';
import * as $ from 'jquery'
import { CategoryService } from 'src/app/Services/category.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
movie:Movie
path="/assets/Images/"
id;
category:string
categoryId:string


  constructor(private movieService:MovieService,private categoryService:CategoryService,private route:ActivatedRoute)
  {
   this.route.params.subscribe(url=>{this.id=url['id'];
   this.movieService.getMovie(this.id).subscribe(
    data=>{this.movie=data;this.categoryId=this.movie.categoryId;this.getCategory()});

  })

  }

  ngOnInit(): void {

  }


 getCategory()
 {
   this.categoryService.getCategory(this.categoryId).subscribe(
     data=>{this.category=data.name}
   )
 }

 uploadVideo()
 {
  var movieId=$('#mov');
  movieId[0].src=this.path+this.movie.movieLink
  movieId.parent()[0].load()
  movieId.parent()[0].play()

  $('html, body').animate({
    scrollTop: $("#myVideo").offset().top
}, 1000);
 }



}

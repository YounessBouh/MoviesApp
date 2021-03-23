import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Actor } from 'src/app/Models/Actor';
import { category } from 'src/app/Models/Category';
import { Movie } from 'src/app/Models/Movie';
import { ActorService } from 'src/app/Services/actor.service';
import { CategoryService } from 'src/app/Services/category.service';
import { MovieService } from 'src/app/Services/movie.service';
import * as $ from 'jquery'

@Component({
  selector: 'app-update-movie',
  templateUrl: './update-movie.component.html',
  styleUrls: ['./update-movie.component.css']
})
export class UpdateMovieComponent implements OnInit {
  UpdateMovie:FormGroup
  actors:Actor[]
  actorsNameList:string[]
  categories:category[]
  PictureFile:File=null
  MovieFile:File=null
  movie:Movie
  path="/assets/Images/"
  id;
  category:string
  categoryId:string

  constructor(private fb:FormBuilder,private actorService:ActorService,
    private categoryService:CategoryService,private router:Router,
    private movieService:MovieService,private route:ActivatedRoute)
    {

      this.UpdateMovie=this.fb.group({
        title:[''],
        description:[''],
      })
    }

  ngOnInit(): void {
    this.actorsNameList=[]
    this.route.params.subscribe(url=>{this.id=url['id'];
    this.movieService.getMovie(this.id).subscribe(
     data=>{this.movie=data;
     this.UpdateMovie=this.fb.group({
       id:[this.movie.id],
       title:[this.movie.title],
       description:[this.movie.description],
       Video:[this.movie.movieLink],
       picture:[this.movie.picture],
       CategoryId:[this.movie.categoryId]

     })
     this.uploadVideo()
    });
   })



  }



  Update()
  {
    const formData=new FormData
    formData.append('Id',this.UpdateMovie.value.id)
    formData.append('Title',this.UpdateMovie.value.title)
    formData.append('Description',this.UpdateMovie.value.description)
    if(this.PictureFile!=null)
    {
      formData.append('Picture',this.PictureFile)
    }
    else
    {
      formData.append('Picture',this.PictureFile)
    }

    if(this.MovieFile!=null)
    {
      formData.append('video',this.MovieFile)
    }
    else
    {
      formData.append('video',this.MovieFile)
    }


    formData.forEach((value,key) => {
      console.log(key+" "+value)
    });

    this.movieService.update(formData).subscribe(
      data=>{this.router.navigate(['/Movies'])}
    )

  }

  onMovieSelected(event)
  {
    this.MovieFile=<File>event.target.files[0];
  }

  onPictureSelected(event)
  {
    this.PictureFile=<File>event.target.files[0];
  }



  uploadVideo()
 {
  var movieId=$('#mov');
  movieId[0].src=this.path+this.movie.movieLink
  movieId.parent()[0].load()

 }

  get title()
  {
    return this.UpdateMovie.value.title
  }

  get description()
  {
    return this.UpdateMovie.value.description
  }

  get Video()
  {
    return this.UpdateMovie.value.video
  }

  get picture()
  {
    return this.UpdateMovie.value.picture
  }


}

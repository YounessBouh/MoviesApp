import { compilePipeFromMetadata } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Actor } from 'src/app/Models/Actor';
import { category } from 'src/app/Models/Category';
import { ActorService } from 'src/app/Services/actor.service';
import { CategoryService } from 'src/app/Services/category.service';
import { MovieService } from 'src/app/Services/movie.service';

@Component({
  selector: 'app-create-movie',
  templateUrl: './create-movie.component.html',
  styleUrls: ['./create-movie.component.css']
})
export class CreateMovieComponent implements OnInit {

CreateMovie:FormGroup
actors:Actor[]
actorsNameList:string[]
categories:category[]
PictureFile:File=null
MovieFile:File=null

  constructor(private fb:FormBuilder,private actorService:ActorService,
    private categoryService:CategoryService,private router:Router,
    private movieService:MovieService)
    {
      this.getActors()
      this.getCategories()
    }

  ngOnInit(): void {
    this.actorsNameList=[]
    this.CreateMovie=this.fb.group({
      Title:['',Validators.required],
      Description:['',Validators.required],
      CategoryId:['',Validators.required],
      actorId:['',Validators.required]
    })
  }

  getActors()
  {
    return this.actorService.getActors().subscribe(
      data=>{this.actors=data}
    )
  }

  getCategories()
  {
    return this.categoryService.getCategories().subscribe(
      data=>{this.categories=data}
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

  onSelect()
  {
  this.actorsNameList.push(String(this.CreateMovie.value.actorId))
  }

  Create()
  {
    const formData=new FormData
    formData.append('Title',this.Title.value)
    formData.append('Description',this.Description.value)
    formData.append('Picture',this.PictureFile)
    formData.append('video',this.MovieFile)
    formData.append('categoryId',this.CategoryId.value)

    for (let m=0;m<this.actorsNameList.length;m++)
    {
     formData.append('actorsId',this.actorsNameList[m])
    }

    formData.forEach((value,key) => {
      console.log(key+" "+value)
    });

    this.movieService.addMovie(formData).subscribe(
      data=>{this.router.navigate(['/Movies'])}
    )

  }

  get Title()
  {
    return this.CreateMovie.get('Title')
  }
  get Description()
  {
    return this.CreateMovie.get('Description')
  }
  get CategoryId()
  {
    return this.CreateMovie.get('CategoryId')
  }
  get actorId()
  {
    return this.CreateMovie.get('actorId')
  }
}

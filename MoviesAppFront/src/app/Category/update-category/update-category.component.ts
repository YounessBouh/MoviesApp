import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { category } from 'src/app/Models/Category';
import { CategoryService } from 'src/app/Services/category.service';
import {map,mergeMap} from 'rxjs/operators'

@Component({
  selector: 'app-update-category',
  templateUrl: './update-category.component.html',
  styleUrls: ['./update-category.component.css']
})
export class UpdateCategoryComponent implements OnInit {

  category:category
  id
  UpdateCategory:FormGroup
  constructor(private categoryService:CategoryService,private route:ActivatedRoute,
    private fb:FormBuilder,private router:Router)
  {
    this.UpdateCategory=this.fb.group({
      categoryId:[''],
      name:['']
    })
  }

  ngOnInit(): void {
  this.fetchData()
  }

  fetchData()
  {
    this.route.params.pipe(map(url=>{
      const catId=url['id'];
      return catId
    }),mergeMap(catId=>this.categoryService.getCategory(catId))).subscribe(
      data=>{this.category=data;
      console.log(this.category);
        this.UpdateCategory=this.fb.group({
                 categoryId:[this.category.categoryId],
                 name:[this.category.name,Validators.required]
               })
      }
    )
  }


  update()
  {
    console.log(this.UpdateCategory.value)
    return this.categoryService.updateCategory(this.UpdateCategory.value).subscribe(
      data=>{this.router.navigate(['Categories'])}
    )

  }


  get name()
  {
    return this.UpdateCategory.get('name')
  }



}

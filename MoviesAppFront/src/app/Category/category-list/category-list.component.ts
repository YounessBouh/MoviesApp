import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/Services/category.service';
import {category} from 'src/app/Models/Category'
import { Router } from '@angular/router';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

  categories:category[]
  constructor(private categoryService:CategoryService,private router:Router) { }

  ngOnInit(): void {
    this.getCategories()
  }

  getCategories()
  {
    return this.categoryService.getCategories().subscribe(
      data=>{this.categories=data,console.log(this.categories)},error=>{}
    )
  }

  Delete(id)
  {
 this.categoryService.deleteCategory(id).subscribe(
   data=>{console.log(data)}
 )
  }



}

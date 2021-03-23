import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CategoryService } from 'src/app/Services/category.service';

@Component({
  selector: 'app-create-category',
  templateUrl: './create-category.component.html',
  styleUrls: ['./create-category.component.css']
})
export class CreateCategoryComponent implements OnInit {

  CategoryForm:FormGroup
  constructor(public fb:FormBuilder,private categoryService:CategoryService) { }

  ngOnInit(): void {
    this.CategoryForm=this.fb.group({
      name:['',Validators.required]
    })
  }

  addCategory()
  {
    return this.categoryService.addCategory(this.CategoryForm.value).subscribe(
    data=>{console.log(data)},error=>{console.log(error)}
 )
  }

  get name()
  {
   return this.CategoryForm.get('name')
  }
}

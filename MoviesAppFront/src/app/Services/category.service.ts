import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { category } from '../Models/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  categoryPath="https://localhost:5001/api/Category"

  constructor(private http:HttpClient) { }

 getCategories():Observable<category[]>
 {
  return this.http.get<category[]>(this.categoryPath + "/Categories")
 }

 getCategory(id:string):Observable<category>
 {
  return this.http.get<category>(this.categoryPath + "/"+id)
 }

  addCategory(data:category):Observable<any>
  {
    return this.http.post(this.categoryPath +"/Create",data);
  }

  updateCategory(data):Observable<any>
  {
    return this.http.put(this.categoryPath + "/Update",data)
  }

  deleteCategory(id:string):Observable<any>
  {
   return this.http.delete(this.categoryPath +"/"+id)
  }

}

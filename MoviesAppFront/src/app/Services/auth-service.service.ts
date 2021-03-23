import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  constructor(private http:HttpClient) { }
  LoginPath="https://localhost:5001/api/Account/Login"
  RegisterPath="https://localhost:5001/api/Account/Register"

  Login(data:any):Observable<any>
  {
  return this.http.post(this.LoginPath,data);
  }

  Register(data:any):Observable<any>
  {
    return this.http.post(this.RegisterPath,data)
  }

  SaveToken(token)
  {
    localStorage.setItem('token',token)
  }

  getToken()
  {
    return localStorage.getItem('token');
  }
}

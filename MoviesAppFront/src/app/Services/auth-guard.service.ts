import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {

  constructor(private route:Router) { }

  canActivate():boolean
  {
    if(this.isAuthenicated())
    {
     return true;
    }
    else{
      this.route.navigate(['Login']);
      return false;
    }
  }

  getToken()
  {
    return localStorage.getItem('token');
  }

  isAuthenicated()
  {
    if(this.getToken())
    {
      return true;
    }
    return false;
  }
}

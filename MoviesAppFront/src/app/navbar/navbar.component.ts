import { Component, OnInit } from '@angular/core';
import { AuthGuardService } from '../Services/auth-guard.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private guardService:AuthGuardService) { }

  ngOnInit(): void {
    this.LoggedUser()
  }

  LoggedUser():boolean
  {
    return this.guardService.isAuthenicated()
  }

  logOut()
  {
    localStorage.removeItem('token');
  }

}

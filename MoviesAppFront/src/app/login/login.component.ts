import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthServiceService } from '../Services/auth-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  LoginForm:FormGroup
  constructor(private fb:FormBuilder,private loginService:AuthServiceService,private route:Router) { }

  ngOnInit(): void {
    this.LoginForm=this.fb.group({
      email:['',Validators.required],
      password:['',Validators.required]
    })
  }

  Login()
  {
  this.loginService.Login(this.LoginForm.value).subscribe(
    data=>{this.loginService.SaveToken(data['jwtToken']),this.route.navigate(['/Movies'])},
    error=>{console.log(error)}
  )
  }

  get email()
  {
    return this.LoginForm.get('email')
  }

  get password()
  {
    return this.LoginForm.get('password')
  }

}

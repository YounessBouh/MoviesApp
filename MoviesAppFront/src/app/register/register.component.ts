import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthServiceService } from '../Services/auth-service.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

RegisterForm:FormGroup

  constructor(private fb:FormBuilder,private RegisterService:AuthServiceService,private route:Router) { }

  ngOnInit(): void {
    this.RegisterForm=this.fb.group({
      username:['',Validators.required],
      email:['',Validators.required],
      mobile:['',Validators.required],
      Address:['',Validators.required],
      password:['',Validators.required]
    })
  }

  Register()
  {
  this.RegisterService.Register(this.RegisterForm.value).subscribe(
    data=>{this.route.navigate(['/Login'])},error=>{console.log(error)}
  )
  }
  get username()
  {
   return this.RegisterForm.get('username')
  }

  get email()
  {
    return this.RegisterForm.get('email')
  }

  get mobile()
  {
    return this.RegisterForm.get('mobile')
  }

  get Address()
  {
    return this.RegisterForm.get('Address')
  }

  get password()
  {
    return this.RegisterForm.get('password')
  }

}

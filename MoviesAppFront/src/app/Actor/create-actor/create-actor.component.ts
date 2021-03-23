import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActorService } from 'src/app/Services/actor.service';


@Component({
  selector: 'app-create-actor',
  templateUrl: './create-actor.component.html',
  styleUrls: ['./create-actor.component.css']
})
export class CreateActorComponent implements OnInit {
  SingleFile:File=null;
  path:string=""
  CreateActor:FormGroup
  constructor(private fb:FormBuilder,private actorService:ActorService) { }

  ngOnInit(): void {
    this.CreateActor=this.fb.group({
      ActorName:['',Validators.required],
      ActorPicture:['']
    })
  }

  onFileSelected(event)
  {
    this.SingleFile=<File>event.target.files[0];
    console.log(this.SingleFile)
    this.path="/assets/Images/"+this.SingleFile.name
  }
  Create()
  {
    if(this.SingleFile==null)
    {
      document.getElementById('item').innerHTML="this.Field is required"
    }
    else{
      console.log('running')
      const formData= new FormData();
      formData.append('ActorName',this.ActorName.value)
      formData.append('ActorPicture',this.SingleFile)
      this.actorService.addActor(formData).subscribe(
        data=>{console.log(data)}
      )
    }

  }
  get ActorName()
  {
    return this.CreateActor.get('ActorName')
  }
  get ActorPicture()
  {
    return this.CreateActor.get('ActorPicture')
  }

}

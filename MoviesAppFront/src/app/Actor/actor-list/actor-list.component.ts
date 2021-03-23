import { Component, OnInit } from '@angular/core';
import { Actor } from 'src/app/Models/Actor';
import { ActorService } from 'src/app/Services/actor.service';

@Component({
  selector: 'app-actor-list',
  templateUrl: './actor-list.component.html',
  styleUrls: ['./actor-list.component.css']
})
export class ActorListComponent implements OnInit {
actors:Actor[]
path="/assets/Images/"
  constructor(private actorService:ActorService)
   {
  this.getActors()
   }

  ngOnInit(): void {
  }

  getActors()
  {
    this.actorService.getActors().subscribe(
      data=>{this.actors=data,console.log(this.actors)},error=>{}
    )
  }

  Delete(id)
  {
  this.actorService.deleteActor(id).subscribe(
    data=>{console.log(data)}
  )
  }

}

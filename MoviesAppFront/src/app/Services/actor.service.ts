import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Actor } from '../Models/Actor';

@Injectable({
  providedIn: 'root'
})
export class ActorService {
  actorPath="https://localhost:5001/api/Actor"

  constructor(private http:HttpClient) { }

  getActors():Observable<Actor[]>
  {
    return this.http.get<Actor[]>(this.actorPath+"/Actors")
  }
  deleteActor(id:string):Observable<any>
  {
  return this.http.delete(this.actorPath+'/'+id)
  }
  updateActor(data:Actor):Observable<Actor>
  {
  return this.http.put<Actor>(this.actorPath+'/Update',data)
  }

  addActor(data):Observable<any>
  {
  return this.http.post<any>(this.actorPath+"/Create",data)
  }


}

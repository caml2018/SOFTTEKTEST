import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Response} from '../models/Response.model';
import { headerRestrictionTable } from '../models/headerTableRestrictions.model';

@Injectable({
  providedIn: 'root'
})
export class RestrictionsService {

  urlGetRestrictions:string;
  urlAddRestrictions:string;
  public formData!: headerRestrictionTable;
  
  constructor(private _http: HttpClient)
  {
    this.urlGetRestrictions= "https://localhost:44340/api/" + "Configuration/getExceptions";
    this.urlAddRestrictions= "https://localhost:44340/api/" + "Configuration/addExceptions";
  }
  getRestrictions(): Observable<Response> {
    return this._http.get<Response>(this.urlGetRestrictions);
  }
  addRestrictions():Observable<Response>{
    var body={
      ...this.formData
    }
    return this._http.post<Response>(this.urlAddRestrictions,body)
  }
  
}

import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Response} from '../models/Response.model';

@Injectable({
  providedIn: 'root'
})
export class DowloadpdfService {

  urlGetPdf:string;

  constructor(private _http: HttpClient) {
    this.urlGetPdf= "https://localhost:44309/api/" + "InformeResultado";
  }

  getPdf(): Observable<Response> {
    return this._http.get<Response>(this.urlGetPdf);
  }
}

import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EntityValidateService {

  validate(elements:any[], element:any):boolean
  {
    debugger;
    var obj=elements.find(x=>x.id==element.id)
    if(JSON.stringify(element).toLowerCase() === JSON.stringify(obj).toLowerCase()){
      return true;
    }
    else
      return false;
  }

  constructor() { }
}

import { Component, EventEmitter, Input, Output} from '@angular/core';
import { headerRestrictionTable } from 'src/app/models/headerTableRestrictions.model';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent {

  restriction: headerRestrictionTable |null =null;

  @Input() title = "";
  @Input() tableData: any[] =[];
  @Input() displayedColumns: any[]=[];
  @Output() updateRegisterEvent=new EventEmitter<any>();
  
  public show=false;

  showModal(){
    this.show = true;
  }
  
  hideModal(){
    this.show = false;
  }

  onUpdateRegister(element:headerRestrictionTable)
  {
    this.updateRegisterEvent.emit(element);
  }
}

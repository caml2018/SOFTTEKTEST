import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { headerRestrictionTable } from 'src/app/models/headerTableRestrictions.model';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnChanges {

  @Input() title = "";
  @Input() tableData: any[] =[];
  @Input() displayedColumns: any[]=[];
  @Output() updateEvent = new EventEmitter<any>();
  @Output() deleteEvent = new EventEmitter<any>();

  
  //displayedRows: string[] = ['cuenta', 'naturaleza', 'tercero', 'valorAjustePeso'];
  dataSource! : MatTableDataSource<headerRestrictionTable>;

  @ViewChild('scheduledOrdersPaginator') set paginator(pager:MatPaginator) {
    if (pager) this.dataSource.paginator = pager;
  }
  @ViewChild(MatSort) set sort(sorter:MatSort) {
    if (sorter) this.dataSource.sort = sorter;
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.dataSource = new MatTableDataSource(this.tableData);
  }
  
  applyFilter(event: Event) {

    
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  // update(element:any)
  // {
  //   console.log("Actualizar");
  // }
  onDelete(element:any)
  {
    debugger;
    this.deleteEvent.emit(element);
    console.log("Borrar");
  }

  onUpdate(element:any) {
    debugger;
    this.updateEvent.emit(element);
    console.log("Actualizar");
  }

}

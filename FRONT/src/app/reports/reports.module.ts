import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from '@angular/common/http';
import{FormsModule,ReactiveFormsModule} from '@angular/forms';

import {MatIconModule} from '@angular/material/icon';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';
import {MatSortModule} from '@angular/material/sort';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';

import { ReportsRoutingModule } from './reports-routing.module';
import { MayorBalanceComponent } from './components/pages/mayor-balance/mayor-balance.component';
import { LayoutComponent } from './components/layout/layout.component';
import { DndDirective } from './directive/dnd.directive';
import { ProgressComponent } from './components/progress/progress.component';
import { ModalComponent } from './components/modal/modal.component';
import { TableComponent } from './components/table/table.component';


@NgModule({
  declarations: [
    MayorBalanceComponent,
    LayoutComponent,
    DndDirective,
    ProgressComponent,
    ModalComponent,
    TableComponent
  ],
  imports: [
    CommonModule,
    ReportsRoutingModule,
    MatIconModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatFormFieldModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    SweetAlert2Module.forRoot()
  ],
  providers:[],
  bootstrap:[MayorBalanceComponent]
})
export class ReportsModule { }

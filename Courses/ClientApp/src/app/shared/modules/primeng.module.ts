import { NgModule } from '@angular/core';
import {TableModule} from 'primeng/table';
import {ToastModule} from 'primeng/toast';
import {CalendarModule} from 'primeng/calendar';
import {MultiSelectModule} from 'primeng/multiselect';
import {ContextMenuModule} from 'primeng/contextmenu';
import {DialogModule} from 'primeng/dialog';
import {ButtonModule} from 'primeng/button';
import {DropdownModule} from 'primeng/dropdown';
import {InputTextModule} from 'primeng/inputtext';
import {ToggleButtonModule} from 'primeng/togglebutton';
import {PaginatorModule} from 'primeng/paginator';


@NgModule({
  imports: [
    TableModule,
    MultiSelectModule,
    InputTextModule,
    DropdownModule,
    CalendarModule,
    ButtonModule,
    DialogModule,
    ContextMenuModule,
    ToggleButtonModule,
    PaginatorModule
    
  ],
  declarations: [],
  exports: [
    TableModule,
    MultiSelectModule,
    InputTextModule,
    DropdownModule,
    CalendarModule,
    ButtonModule,
    DialogModule,
    ContextMenuModule,
    ToggleButtonModule,
    PaginatorModule
  ]
})
export class PrimeNgModule { }

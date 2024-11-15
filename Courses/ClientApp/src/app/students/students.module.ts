import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentsComponent } from './students.component';
import { StudentsRoutes } from './students.routing';
import { ListComponent } from './pages/List/List.component';
import { AddComponent } from './pages/add/add.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    StudentsRoutes
  ],
  declarations: [StudentsComponent, ListComponent, AddComponent]
})
export class StudentsModule { }

import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BlockUIModule } from 'ng-block-ui';
import { BlockUIHttpModule } from 'ng-block-ui/http';
import { BlockUIRouterModule } from 'ng-block-ui/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';
import { CustomFormsModule } from 'ngx-custom-validators';
import { CovalentLayoutModule } from '@covalent/core/layout';
import { CovalentStepsModule } from '@covalent/core/steps';
import { CovalentFileModule } from '@covalent/core/file';
import { AgmCoreModule } from '@agm/core';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { MaterialModule } from './modules/material.module';
import { PrimeNgModule } from './modules/primeng.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CustomFormsModule,
    NgbModule,
    RouterModule,
    MaterialModule,
    CovalentLayoutModule,
    CovalentStepsModule,
    CovalentFileModule,
    AgmCoreModule.forRoot({
    }),
    NgxMatSelectSearchModule,
    ReactiveFormsModule,
    NgxMaterialTimepickerModule.forRoot(),
    PrimeNgModule
    ,
  ],
  declarations: [
  ],
  exports: [
    NgbModule,
    FormsModule,
    CustomFormsModule,
    RouterModule,
    CommonModule,
    BlockUIModule,
    BlockUIHttpModule,
    BlockUIRouterModule,
    MaterialModule,
    NgxMatSelectSearchModule,
    CovalentLayoutModule,
    CovalentStepsModule,
    CovalentFileModule,
    ReactiveFormsModule,
    AgmCoreModule,
    NgxMaterialTimepickerModule,
    PrimeNgModule,
  ],
  entryComponents: []
})
export class SharedModule { }

import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PlatformLocation } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  isAuth$: Observable<boolean>;
  constructor(private modalService: NgbModal , private platformLocation: PlatformLocation) {
    platformLocation.onPopState(() => this.modalService.dismissAll()); 
  }
}

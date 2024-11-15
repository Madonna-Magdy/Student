import { Component, OnInit } from '@angular/core';
import { StudentsService } from '../../../core/services/students.service';
import { StudentAddVm } from '../../../core/models/student-add-vm';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentVm } from '../../../core/models/student-vm';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  id = 0;
  model: StudentAddVm = {
    address: '',
    mobileNumber: '',
    name: ''
  };

  constructor(private studentsService: StudentsService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.id = +this.route.snapshot.params.id || 0;

    if (this.id) {
      this.studentsService.getByid(this.id).subscribe(x => this.model = x);
    }
  }

  save() {
    if (this.id) {
      let editModel: StudentVm = { ...this.model, id: this.id };
      this.studentsService.edit(editModel).subscribe(x => this.router.navigate(["../"], { relativeTo: this.route }));
    } else {
      this.studentsService.add(this.model).subscribe(x => this.router.navigate(["../"], { relativeTo: this.route }));
    }
  }

}

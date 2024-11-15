import { Component } from '@angular/core';
import { StudentsService } from '../../../core/services/students.service';
import { StudentVm } from '../../../core/models/student-vm';

@Component({
  selector: 'app-List',
  templateUrl: './List.component.html',
  styleUrls: ['./List.component.css']
})
export class ListComponent {

  students: StudentVm[];

  constructor(private studentsService: StudentsService) {
    this.students = [{name: 'aaa', id: 1,  mobileNumber:'012456464684', address:'ddd'}];
    studentsService.getAll().subscribe(x => this.students = x);
  }

  delete(id: number) {
    this.studentsService.delete(id).subscribe(() => {
      let indexToBeRemoved = this.students.findIndex(x => x.id === id);
      this.students.splice(indexToBeRemoved, 1);
    });
  }
}

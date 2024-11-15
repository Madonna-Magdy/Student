import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StudentVm } from '../models/student-vm';
import { StudentAddVm } from '../models/student-add-vm';

@Injectable({
    providedIn: 'root'
})

export class StudentsService {
    controllerUrl: string = '';

    constructor(private http: HttpClient) {
        this.controllerUrl = 'api/student/';
    }

    getAll() {
        return this.http.get<StudentVm[]>(`${this.controllerUrl}`);
    }

    getByid(id: number) {
        return this.http.get<StudentVm>(this.controllerUrl + id);
    }

    add(model: StudentAddVm) {
        return this.http.post<void>(this.controllerUrl, model);
    }

    edit(model: StudentVm) {
        return this.http.put<void>(this.controllerUrl + model.id, model);
    }

    delete(id: number) {
        return this.http.delete<void>(this.controllerUrl + id);
    }
}

import { Routes, RouterModule } from '@angular/router';
import { StudentsComponent } from './students.component';
import { ListComponent } from './pages/List/List.component';
import { AddComponent } from './pages/add/add.component';

const routes: Routes = [
  {
    path: '', component: StudentsComponent, children: [
      { path: '', component: ListComponent },
      { path: 'add', component: AddComponent },
      { path: 'edit/:id', component: AddComponent }
    ]
  },
];
export const StudentsRoutes = RouterModule.forChild(routes);

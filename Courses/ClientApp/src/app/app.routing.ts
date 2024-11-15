import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  {
    path: "",
    loadChildren: "./students/students.module#StudentsModule"
  }
];

export const AppRoutes = RouterModule.forRoot(routes);

import { Routes } from '@angular/router';
import { RegistrarEstudiantesComponent } from './Pages/RegistarEstudiante/registrar-estudiantes.component';
import { EstudiantesComponent } from './Pages/Estudiantes/estudiantes.component';

export const routes: Routes = [

    {path:"",component:EstudiantesComponent},
    {path:"inicio",component:EstudiantesComponent},

];

import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { EstudianteService } from '../../Services/estudiante.service';
import { MateriaService } from '../../Services/materia.service';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatListModule } from '@angular/material/list';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RegistrarEstudiantesComponent } from '../RegistarEstudiante/registrar-estudiantes.component';

@Component({
  selector: 'app-estudiantes',
  standalone: true,
  imports: [
    CommonModule,
    MatIconModule,
    MatTableModule,

    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatCardModule,
    MatDialogModule,
    MatListModule,
    MatExpansionModule,
    MatInputModule,
    MatFormFieldModule,
    MatTooltipModule
  ],
  templateUrl: './estudiantes.component.html',
  styleUrl: './estudiantes.component.css'
})
export class EstudiantesComponent {

  dataSource = new MatTableDataSource<any>();
  materiasEstudiante: any[] = [];
  nombreEstudiante: string = "";
  todasMaterias: any[] = [];
  displayedColumns: string[] = ['id', 'nombre', 'email', 'acciones'];

  constructor(
    private http: HttpClient,
    private snackBar: MatSnackBar,
    private router: Router,
    private estudianteServices: EstudianteService,
    private materiaService: MateriaService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.obtenerEstudiantes();
  }

  obtenerEstudiantes() {
    this.estudianteServices.getEstudiantes().subscribe(
      (response) => {
        this.dataSource.data = response;
      });
  }

  verMateriasEstudiante(id: number) {
    this.estudianteServices.getMateriasPorEStudianteId(id).subscribe(
      (response) => {
        this.materiasEstudiante = response.Materias;
        this.nombreEstudiante = response.Nombre;
      });
  }

  verListadoMaterias() {
    this.materiaService.getMaterias().subscribe(
      (response) => {
        this.todasMaterias = response;
      });
  }

  registrarEstudiante() {
    this.dialog.open(RegistrarEstudiantesComponent, {
      width: '800px',
      data: { student: null }
    });

  }

  registrarMaterias(student: any) {
    this.dialog.open(RegistrarEstudiantesComponent, {
      width: '800px',
      data: { student: student }

    });

  }

}

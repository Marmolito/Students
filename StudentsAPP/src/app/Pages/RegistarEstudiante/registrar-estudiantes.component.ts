import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MateriaService } from '../../Services/materia.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EstudianteService } from '../../Services/estudiante.service';


@Component({
  selector: 'app-estudiantes',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatListModule,
    MatSnackBarModule],
  templateUrl: './registrar-estudiantes.component.html',
  styleUrl: './registrar-estudiantes.component.css'
})
export class RegistrarEstudiantesComponent implements OnInit {

  registroForm: FormGroup;
  materias: any[] = [];
  disable: boolean = false;

  estudiante = {
    id: 0,
    nombre: "",
    email: "",
    materiasIds: []
  };

  student: any;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private snackBar: MatSnackBar,
    private dialogRef: MatDialogRef<RegistrarEstudiantesComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private materiaServices: MateriaService,
    private estudianteServices: EstudianteService
  ) {
    this.student = data?.student || {};
    this.registroForm = this.fb.group({
      nombre: [this.student.Nombre? this.student.Nombre: "", Validators.required],
      correo: [this.student.Email? this.student.Email: "", [Validators.required, Validators.email]],
      materias: [[], [Validators.required, Validators.minLength(3), Validators.maxLength(3)]]
    });

    console.log('entro al enviar:', this.estudiante.id)

  }

  ngOnInit() {
    this.obtenerMaterias();
    this.isDisable();
    if (this.disable) {
      this.registroForm.get('nombre')?.disable();
      this.registroForm.get('correo')?.disable();
    }
  }

  isDisable() {
    this.disable = this.student.Nombre != "" && this.student.Nombre != null? true : false
  }

  obtenerMaterias() {
    this.materiaServices.getMaterias().subscribe(response => {
      this.materias = response;
    });
  }

  registrarEstudiante() {
    if (this.registroForm.invalid) {
      this.snackBar.open('Por favor, completa el formulario correctamente', 'Cerrar', { duration: 3000 });
      return;
    }

    console.log('entro al enviar:', this.estudiante.id)

    if (this.disable) {
      this.estudiante = {
        id: this.student.Id,
        nombre: this.student.Nombre,
        email: this.student.Email,
        materiasIds: this.registroForm.value.materias
      };
    } else {
      this.estudiante = {
        id: 0,
        nombre: this.registroForm.value.nombre,
        email: this.registroForm.value.correo,
        materiasIds: this.registroForm.value.materias
      };
    }

    console.log('entro al enviar:', this.estudiante.id)

    if (this.registroForm.valid) {
      this.estudianteServices.registrarMateriasAEstudiante(this.estudiante).subscribe({
        next: (response) => {
          console.log('Estudiante Guardado:', response);
          this.snackBar.open('Estudiante registrado con éxito!', 'Cerrar', {
            duration: 3000,  // Duración en milisegundos
            verticalPosition: 'top',
            horizontalPosition: 'center',
            panelClass: ['success-snackbar'] // Clase CSS para personalizar el estilo
          });
          this.closeForm();
        },
        error: (error) => {
          console.error('Error al registrar estudiante:', error);
          this.snackBar.open('Hubo un error al registrar al estudiante. Inténtalo nuevamente.', 'Cerrar', {
            duration: 3000,  // Duración en milisegundos
            verticalPosition: 'top',
            horizontalPosition: 'center',
            panelClass: ['error-snackbar'] // Clase CSS para personalizar el estilo
          });
        }
      });
      
    } else {
      console.log('Formulario no válido');
    }

  }

  closeForm(): void {
    this.dialogRef.close();
  }

}

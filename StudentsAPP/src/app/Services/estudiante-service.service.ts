import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appSettings } from '../Settings/appSetings';
import { catchError, Observable, throwError } from 'rxjs';
import { Estuidiante } from '../Models/Estudiante';

@Injectable({
  providedIn: 'root'
})
export class EstudianteServiceService {

  private http = inject(HttpClient);
  private apiUrl: string = appSettings.apiUrl + "estudiantes";

  constructor() { }

  getEstudiantes(): Observable<Estuidiante> {
    return this.http.get<Estuidiante>(this.apiUrl).pipe(
      catchError((error: HttpErrorResponse) => {
        console.error('Error fetching estudiantes:', error);
        return throwError(() => new Error('Error fetching estudiantes'));
      })
    );
  }

}

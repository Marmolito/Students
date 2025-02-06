import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appSettings } from '../Settings/appSetings';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EstudianteService {

  private http = inject(HttpClient);
  private apiUrl: string = appSettings.apiUrl + "estudiantes";

  constructor() { }

  getEstudiantes(): Observable<any> {
    return this.http.get<any>(this.apiUrl).pipe(
      catchError((error: HttpErrorResponse) => {
        console.error('Error fetching estudiantes:', error);
        return throwError(() => new Error('Error fetching estudiantes'));
      })
    );
  }

  getMateriasPorEStudianteId(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`).pipe(
      catchError((error: HttpErrorResponse) => {
        console.error('Error fetching estudiantes:', error);
        return throwError(() => new Error('Error fetching estudiantes'));
      })
    );
  }

  registrarMateriasAEstudiante(obj: any): Observable<any> {
    return this.http.post(this.apiUrl, obj).pipe(
      catchError((error: HttpErrorResponse) => {
        return throwError(() => new Error('Error fetching estudiantes'));
      })
    );
  }


}

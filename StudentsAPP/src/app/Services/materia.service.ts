import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appSettings } from '../Settings/appSetings';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MateriaService {

  private http = inject(HttpClient);
  private apiUrl: string = appSettings.apiUrl + "materias";

  constructor() { }

  getMaterias(): Observable<any> {
    return this.http.get<any>(this.apiUrl).pipe(
      catchError((error: HttpErrorResponse) => {
        console.error('Error fetching materias:', error);
        return throwError(() => new Error('Error fetching materias'));
      })
    );
  }
}

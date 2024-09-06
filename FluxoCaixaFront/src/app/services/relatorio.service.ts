import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../utils/constants';
import { SaldoDiario } from '../models/saldoDiario';

@Injectable({
  providedIn: 'root'
})
export class RelatorioService {
  private apiUrl = `${environment.Relatorio_URL_API}`;

  constructor(private http: HttpClient) { }

  getExtractByDate(date: string): Observable<SaldoDiario> {
    return this.http.get<SaldoDiario>(`${this.apiUrl}/${date}`);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Lancamento } from '../models/lancamento';
import { environment } from '../utils/constants';

@Injectable({
  providedIn: 'root'
})
export class LancamentoService {
  private apiUrl = `${environment.Lancamento_URL_API}/`;

  constructor(private http: HttpClient) { }

  createTransaction(transactionRequest: Lancamento): Observable<Lancamento> {
    return this.http.post<Lancamento>(this.apiUrl, transactionRequest);
  }
}

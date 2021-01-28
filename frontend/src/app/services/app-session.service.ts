import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { DadosUsuario } from '../pages/login/models/DadosUsuario.model';
import { Token } from '../pages/login/models/Token.model';

@Injectable({
  providedIn: 'root'
})
export class AppSessionService {

  
  constructor(private http: HttpClient) { 
    const tokenLocalStorage = localStorage.getItem('b618b910-0109-4e1a-885e-66d9a4471f73');
  }

  obterInformacoesContexto(token: string): Observable<DadosUsuario> {
    return this.http.post<DadosUsuario>(`autenticacao/usuario`, {
      token: token
    });
   }

  salvarDadosAcesso(token: Token): Observable<void> {
    return of(localStorage.setItem("b618b910-0109-4e1a-885e-66d9a4471f73", JSON.stringify(token)));
  }

  obterDadosAcesso(): Observable<any> {
     return of(localStorage.getItem("b618b910-0109-4e1a-885e-66d9a4471f73"));
  }

}

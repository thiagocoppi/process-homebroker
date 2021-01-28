import { Token } from './../pages/login/models/Token.model';
import { Observable } from 'rxjs';
import { AutenticacaoUsuario } from './../pages/login/models/AutenticacaoUsuario.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  realizarLogin(autenticar: AutenticacaoUsuario) : Observable<Token> {
    return this.http.post<Token>("Seguranca/login", autenticar );
  }
}

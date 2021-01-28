import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { LoginService } from 'src/app/services/login.service';
import { AutenticacaoUsuario } from './models/AutenticacaoUsuario.model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(private loginService : LoginService,
              private spinnerService: NgxSpinnerService,
              private router: Router) {}
  register = false;
  autenticacao = new AutenticacaoUsuario();
  mostrarSpinner = false;

  realizarLogin() {
    console.log(this.spinnerService);
    this.mostrarSpinner = true;
    this.spinnerService.show()
    this.loginService.realizarLogin(this.autenticacao)
    .pipe(finalize(() => {
      this.spinnerService.hide();
      this.mostrarSpinner = false;
    }))
    .subscribe(() => {
      this.router.navigate(['dashboard']);
    }, (error) => {
      console.log(error);
      
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Ocorreu um erro!',
        footer: '<a href>Why do I have this issue?</a>'
      });
    });
  }

}

import { Router } from '@angular/router';
import { SeguridadService } from './../seguridad.service';
import { Usuario } from './../../Model/Usuario';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  usuario: Usuario;
  errorMessage: string;

  constructor(private seguridadService: SeguridadService, private router: Router) {
    this.usuario = new Usuario();
    this.usuario.idUsuario = '';
    this.usuario.clave = '';
   }

  ngOnInit() {
  }

   onSubmit(editForm) {
    this.getUser(<Usuario>editForm.value);
  }

  getUser(usr: Usuario) {
    usr.clave = btoa(usr.clave);

    this.seguridadService.login(usr)
    .subscribe(
      user => this.onUserRetrieve(user),
      error => this.errorMessage = <any>error
    );
  }

  onUserRetrieve(user) {
    if (user === true) {
      this.router.navigate(['/']);
    } else {
      this.usuario.clave = '';
    }
  }
}

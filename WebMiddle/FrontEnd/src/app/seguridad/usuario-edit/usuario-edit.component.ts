import { MaestroModel } from './../../Model/MaestroModel';
import { Router, ActivatedRoute } from '@angular/router';
import { SeguridadService } from './../seguridad.service';
import { Usuario } from './../../Model/Usuario';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-usuario-edit',
  templateUrl: './usuario-edit.component.html',
  styleUrls: ['./usuario-edit.component.css']
})
export class UsuarioEditComponent implements OnInit {

  usuario: Usuario;
  errorMessage: string;
  roles: MaestroModel[];

  constructor(private seguridadService: SeguridadService, private router: Router, private route: ActivatedRoute) {
    this.usuario = new Usuario();
    this.usuario.idUsuario = '';

    this.seguridadService.obtenerRoles()
    .subscribe(res => this.roles = res);
  }

  ngOnInit() {
    const id = this.route.snapshot.params['id'];

    this.getUsuario(id);
  }

  getUsuario(id: number) {
    this.seguridadService.obtenerUsuario(id)
    .subscribe(
      usuario => this.onRetrieve(usuario),
      error => this.errorMessage = <any>error
    );
  }

   onRetrieve(Usuario: Usuario) {
    this.usuario = Usuario;
  }

  onSubmit(editForm) {
    this.seguridadService.EditarUsuario(this.usuario)
    .subscribe(res => this.router.navigate(['usuario']));
  }
}

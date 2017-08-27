import { MaestroModel } from './../../Model/MaestroModel';
import { Usuario } from './../../Model/Usuario';
import { Router } from '@angular/router';
import { SeguridadService } from './../seguridad.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-usuario-add',
  templateUrl: './usuario-add.component.html',
  styleUrls: ['./usuario-add.component.css']
})
export class UsuarioAddComponent implements OnInit {

   formulario: FormGroup;
   roles: MaestroModel[];

  constructor(private formBuilder: FormBuilder, private seguridadService: SeguridadService, private router: Router) {
    this.seguridadService.obtenerRoles()
    .subscribe(res => this.roles = res);
  }

  ngOnInit() {
      this.formulario = this.formBuilder.group({
        idUsuario: [null, Validators.required],
        idRol: [null, Validators.required],
    });
  }

  onSubmit() {
    this.seguridadService.nuevoUsuario(<Usuario>this.formulario.value).subscribe(res => this.router.navigate(['usuario']));
  }
}

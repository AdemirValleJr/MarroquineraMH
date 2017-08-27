import { Router } from '@angular/router';
import { SeguridadService } from './../seguridad.service';
import { MaestroModel } from './../../Model/MaestroModel';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-guard-rol-add',
  templateUrl: './guard-rol-add.component.html',
  styleUrls: ['./guard-rol-add.component.css']
})
export class GuardRolAddComponent implements OnInit {

  formulario: FormGroup;
  roles: MaestroModel[];

 constructor(private formBuilder: FormBuilder, private seguridadService: SeguridadService, private router: Router) {
   this.seguridadService.obtenerRoles()
   .subscribe(res => this.roles = res);
 }

 ngOnInit() {
     this.formulario = this.formBuilder.group({
       id: [null, Validators.required],
       descripcion: [null, Validators.required],
   });
 }

 onSubmit() {
   this.seguridadService.nuevoGuardRol(<MaestroModel>this.formulario.value).subscribe(res => this.router.navigate(['guardrol']));
 }

}

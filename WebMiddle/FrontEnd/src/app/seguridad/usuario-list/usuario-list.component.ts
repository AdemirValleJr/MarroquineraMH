import { Usuario } from './../../Model/Usuario';
import { DataTableModule, SharedModule} from 'primeng/primeng';
import { SeguridadService } from './../seguridad.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-usuario-list',
  templateUrl: './usuario-list.component.html',
  styleUrls: ['./usuario-list.component.css']
})
export class UsuarioListComponent implements OnInit {

  usuarios: Usuario[];

  constructor(private seguridadService: SeguridadService) { }

  ngOnInit() {
    this.loadData()
  }

  loadData() {
    this.seguridadService.obtenerUsuarios()
    .subscribe(usuarios => this.usuarios = usuarios);
  }

  delete(id) {
    this.seguridadService.eliminarUsuario(id).subscribe(res => this.loadData());
  }

}

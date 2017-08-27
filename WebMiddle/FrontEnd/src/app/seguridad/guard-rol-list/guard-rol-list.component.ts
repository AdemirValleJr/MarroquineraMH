import { SeguridadService } from './../seguridad.service';
import { MaestroModel } from './../../Model/MaestroModel';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-guard-rol-list',
  templateUrl: './guard-rol-list.component.html',
  styleUrls: ['./guard-rol-list.component.css']
})
export class GuardRolListComponent implements OnInit {

    guardRoles: MaestroModel[];

    constructor(private seguridadService: SeguridadService) { }

    ngOnInit() {
      this.loadData()
    }

    loadData() {
      this.seguridadService.obtenerGuardRoles()
      .subscribe(guardRoles => this.guardRoles = guardRoles);
    }

    delete(guard, rol) {
      const id = guard + '-' + rol;
      this.seguridadService.eliminarGuardRol(id).subscribe(res => this.loadData());
    }
}

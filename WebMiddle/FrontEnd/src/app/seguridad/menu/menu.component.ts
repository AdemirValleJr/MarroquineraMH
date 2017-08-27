import { SeguridadService } from './../seguridad.service';
import { BsDropdownModule } from 'ngx-bootstrap';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  usuarioLogueado: boolean;

  constructor(private SeguridadService: SeguridadService) { }

  ngOnInit() {
    this.SeguridadService.mostrarMenu.subscribe(
      logueado => this.usuarioLogueado = logueado
    );
  }

}

import { ColorComponent } from './../../data-maestra/color/color.component';
import { KardexTiendaProductoColor } from './../../Model/KardexTiendaProductoColor';
import { ReportesService } from './../reportes.service';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-stock-prod-color-sucursal',
  templateUrl: './stock-prod-color-sucursal.component.html',
  styleUrls: ['./stock-prod-color-sucursal.component.css']
})
export class StockProdColorSucursalComponent implements OnInit {

  cTienda: string;
  cProducto: string;
  cColor: string;

  modal: string;
  busquedaValida: boolean;
  reporte: ReportesService;

  @ViewChild('tiendaModal') public tiendaModal: ModalDirective;
  @ViewChild('productoModal') public productModal: ModalDirective;
  @ViewChild('colorModal') public colorModal: ModalDirective;

  constructor() { }

  ngOnInit() {
    this.cTienda = '';
    this.cProducto = '';
    this.cColor = '';
    this.modal = '';
    this.busquedaValida = false;
    this.consultar();
  }

  public hideModal(modal): void {
    switch (modal) {
      case 't':
        this.tiendaModal.hide();
        break;
      case 'p':
        this.productModal.hide();
        break;
      default: this.colorModal.hide();
    }
  }

  selecciona(event: MouseEvent, modal) {
    let nodoSeleccionado: boolean;
    let nodos: any;
    let seguirBuscando: boolean;

    nodoSeleccionado = false;

    if ((<HTMLInputElement>event.target).tagName === 'BUTTON') {
      nodos = (<HTMLInputElement>event.target).parentNode.parentNode.parentNode.childNodes;
      nodoSeleccionado = true;
    } else if ((<HTMLInputElement>event.target).tagName === 'SPAN') {
      nodos = (<HTMLInputElement>event.target).parentNode.parentNode.parentNode.parentNode.childNodes;
      nodoSeleccionado = true;
    }

    if (nodoSeleccionado) {

      seguirBuscando = true;

      for (const entry of nodos) {
        if ((<HTMLInputElement>entry).nodeName === 'TD') {
          if (seguirBuscando) {
            switch (modal) {
              case 't':
                this.cTienda = (<HTMLInputElement>entry).innerText;
                break;
              case 'p':
                this.cProducto = (<HTMLInputElement>entry).innerText;
                break;
              default: this.cColor = (<HTMLInputElement>entry).innerText;
            }
            seguirBuscando = false;
            this.hideModal(modal);
          }
        }
      }
    }
  }

  consultar() {
    this.busquedaValida = false;

    if (this.cTienda.length > 0 && this.cProducto.length > 0 && this.cColor.length > 0) {
      this.busquedaValida = true;
    }
  }

  reload() {
    location.reload();
  }
}

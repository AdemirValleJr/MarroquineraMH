import { ColorComponent } from './../../data-maestra/color/color.component';
import { EventEmitter } from '@angular/core';
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

  cTienda: string = '';
  cProducto: string = '';
  cColor: string = '';

  modal: string = "";
  nodos: any;
  nodoSeleccionado: boolean = false;
  seguirBuscando: boolean = false;
  busquedaValida: boolean = false;
  //busqueda: string = "";

  reporte: ReportesService;
  emitirParametros = new EventEmitter<string[]>();

  @ViewChild('tiendaModal') public tiendaModal: ModalDirective;
  @ViewChild('productoModal') public productModal: ModalDirective;
  @ViewChild('colorModal') public colorModal: ModalDirective;

  constructor() { }
  //constructor(private reportesService: ReportesService) { }

  ngOnInit() {
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
      default: this.colorModal.hide();;
    }
  }

  selecciona(event: MouseEvent, modal) {
    this.nodoSeleccionado = false;

    //console.log((<HTMLInputElement>event.target).tagName);
    if ((<HTMLInputElement>event.target).tagName == "BUTTON") {
      this.nodos = (<HTMLInputElement>event.target).parentNode.parentNode.parentNode.childNodes;
      this.nodoSeleccionado = true;
    }

    else if ((<HTMLInputElement>event.target).tagName == "SPAN") {
      this.nodos = (<HTMLInputElement>event.target).parentNode.parentNode.parentNode.parentNode.childNodes;
      this.nodoSeleccionado = true;
    }

    if (this.nodoSeleccionado) {

      this.seguirBuscando = true;

      for (let entry of this.nodos) {
        if ((<HTMLInputElement>entry).nodeName == 'TD') {
          if (this.seguirBuscando) {
            switch (modal) {
              case 't':
                this.cTienda = (<HTMLInputElement>entry).innerText;
                break;
              case 'p':
                this.cProducto = (<HTMLInputElement>entry).innerText;
                break;
              default: this.cColor = (<HTMLInputElement>entry).innerText;
            }
            this.seguirBuscando = false;
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
      //ReportesService.emisorStockSucursalProdColorParams.emit([this.cTienda, this.cProducto, this.cColor]);
      //console.log('se emitieron los parametros');
    }
  }

  reload() {
    //this.zone.runOutsideAngular(() => {
    location.reload();
    //});
  }
}

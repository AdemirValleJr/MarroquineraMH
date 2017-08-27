import { Router } from '@angular/router';
import { SubgrupoProducto } from './../../Model/SubgrupoProducto';
import { MaestroModel } from './../../Model/MaestroModel';
import { ReportesService } from './../reportes.service';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-sell-trhu',
  templateUrl: './sell-trhu.component.html',
  styleUrls: ['./sell-trhu.component.css']
})
export class SellTrhuComponent implements OnInit {

  redesTiendas: MaestroModel[];
  tiendas: MaestroModel[];
  gruposProducto: MaestroModel[];
  subgruposProd: MaestroModel[];
  modelosProducto: MaestroModel[];
  colores: MaestroModel[];
  fabricantes: MaestroModel[];
  temporadas: MaestroModel[];
  colecciones: MaestroModel[];
  tiposProd: MaestroModel[];
  sexos: MaestroModel[];

  red: string;
  tienda: string;
  grupo: string;
  subgrupo: string;
  modelo: string;
  color: string;
  fabricante: string;
  temporada: string;
  coleccion: string;
  tipo: string;
  sexo: string;
  producto: string;
  corteDesde: Date;
  corteHasta: Date;

  colRed: boolean;
  colTienda: boolean;
  colGrupo: boolean;
  colSubgrupo: boolean;
  colModelo: boolean;
  colColor: boolean;
  colFabricante: boolean;
  colTemporada: boolean;
  colColeccion: boolean;
  colVentas: boolean;
  colSemanas: boolean;

  colTipo: boolean;
  colSexo: boolean;
  colProducto: boolean;

  queryTiendas: string;
  queryProducto: string;
  agrupadores: string;
  otrasColumnas: string;

  es: any;

  @ViewChild('productoModal') public productModal: ModalDirective;

  constructor(private _dataService: ReportesService, private router: Router) {
    console.clear();

    this.resetea();

    this._dataService.obtenerRedTiendas()
    .subscribe(res => this.redesTiendas = res);

    this._dataService.obtenerGruposProducto()
    .subscribe(res => this.gruposProducto = res);

    this._dataService.obtenerModelos()
    .subscribe(res => this.modelosProducto = res);

    this._dataService.obtenerColores()
    .subscribe(res => this.colores = res);

    this._dataService.obtenerFabricantes()
    .subscribe(res => this.fabricantes = res);

    this._dataService.obtenertemporadas()
    .subscribe(res => this.temporadas = res);

    this._dataService.obtenerColecciones()
    .subscribe(res => this.colecciones = res);

    this._dataService.obtenerTiposProducto()
    .subscribe(res => this.tiposProd = res);

    this.sexos = this._dataService.obtenerSexos();

    this.buildTiendaQuery();
    this.buildProdQuery();
    this.buildAgrupadores();
  }

  ngOnInit() {
    this.es = {
            firstDayOfWeek: 0,
            dayNames: ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Sabado", "Domingo"],
            dayNamesShort: ["Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab"],
            dayNamesMin: ["Do","Lu","Ma","Mi","Ju","Vi","Sa"],
            monthNames: [ "Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre" ],
            monthNamesShort: [ "Ene", "Feb", "Mar", "Abr", "May", "Jun","Jul", "Ago", "Sep", "Oct", "Nov", "Dic" ]
        };
  }

  onRedSelect(redId) {
    this._dataService.obtenerTiendasPorRed(redId)
    .subscribe(res => this.tiendas = res);

    this.buildTiendaQuery();
  }

  onGrupoSelect(grupoId) {
    this._dataService.obtenerSubgruposPopductoPorGrupo(grupoId)
    .subscribe(res => this.subgruposProd = res);

    this.buildProdQuery();
  }

  seleccionaProd(event: MouseEvent) {
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
            console.log((<HTMLInputElement>entry).innerText);
            this.producto = (<HTMLInputElement>entry).innerText;
            seguirBuscando = false;
            this.buildProdQuery();
            this.hideModal();
          }
        }
      }
    }
  }

  hideModal(): void {
    this.productModal.hide();
  }

  buildTiendaQuery() {
    this.queryTiendas = this.red.trim() + '--' + this.tienda.trim();
  }

  buildProdQuery() {

    const separador = /\./gi;
    let prod: string;

    prod = this.producto.trim() !== 'Todos' ? this.producto.trim().replace(separador, '_') : '';

    this.queryProducto =
      this.grupo.trim() + '--' + this.subgrupo.trim() + '--' + this.sexo.trim() + '--' +
      this.modelo.trim() + '--' + this.fabricante.trim() + '--' + this.temporada.trim() + '--' +
      this.tipo.trim() + '--' + this.coleccion.trim() + '--' + prod + '--' + this.color.trim() + '--' +
      this.corteDesde.getFullYear() + '-' + (this.corteDesde.getMonth() + 1) + '-' + this.corteDesde.getDate() + '--' +
      this.corteHasta.getFullYear() + '-' + (this.corteHasta.getMonth() + 1) + '-' + this.corteHasta.getDate();
  }

  buildAgrupadores() {

    this.otrasColumnas = '';
    if ( this.colSemanas ) {
      this.otrasColumnas = '1';
    } else {
      this.otrasColumnas = '';
    }

    if ( this.colVentas ) {
      this.otrasColumnas += '--' + '1';
    } else {
      this.otrasColumnas += '--';
    }

    this.agrupadores = '';

    if ( this.colRed ) {
      this.agrupadores = '1';
    } else {
      this.agrupadores = '';
    }

    if ( this.colTienda ) {
      this.agrupadores += '--' + '1';
    } else {
      this.agrupadores += '--';
    }

    if ( this.colGrupo ) {
      this.agrupadores += '--' + '1';
    } else {
      this.agrupadores += '--';
    }

    if ( this.colSubgrupo ) {
      this.agrupadores += '--' + '1';
    } else {
      this.agrupadores += '--';
    }

    if ( this.colModelo ) {
      this.agrupadores += '--' + '1';
    } else {
      this.agrupadores += '--';
    }

    if ( this.colFabricante ) {
      this.agrupadores += '--' + '1';
    } else {
      this.agrupadores += '--';
    }

    if ( this.colTemporada ) {
      this.agrupadores += '--' + '1';
    } else {
      this.agrupadores += '--';
    }

    if ( this.colSexo ) {
      this.agrupadores += '--' + '1';
    } else {
      this.agrupadores += '--';
    }

    if ( this.colTipo ) {
      this.agrupadores += '--' + '1';
    } else {
      this.agrupadores += '--';
    }

    if ( this.colColor ) {
      this.agrupadores += '--' + '1';
    } else {
      this.agrupadores += '--';
    }

    if ( this.colProducto ) {
      this.agrupadores += '--' + '1';
    } else {
      this.agrupadores += '--';
    }

    if ( this.colColeccion ) {
      this.agrupadores += '--' + '1';
    } else {
      this.agrupadores += '--';
    }
  }

  resetea() {
    this.red = '';
    this.tienda = '';
    this.grupo  = '';
    this.subgrupo  = '';
    this.modelo  = '';
    this.color = '';
    this.fabricante = '';
    this.temporada = '';
    this.coleccion = '';

    this.tipo = '';
    this.sexo = '';
    this.producto = 'Todos';

    this.colRed = false;
    this.colTienda = false;
    this.colGrupo = false;
    this.colSubgrupo = false;
    this.colModelo = false;
    this.colColor = false;
    this.colFabricante = false;
    this.colTemporada = false;
    this.colColeccion = false;
    this.colTipo = false;
    this.colSexo = false;
    this.colProducto = false;
    this.colVentas = false;
    this.colSemanas = false;

    this.corteDesde = new Date();
    this.corteDesde.setDate(this.corteDesde.getDate() - 30);
    this.corteHasta = new Date();
  }
}

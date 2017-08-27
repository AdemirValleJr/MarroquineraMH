import { Subscription } from 'rxjs/Rx';
import { Sellthru } from './../../Model/SellThru';
import { Component, OnInit, Input } from '@angular/core';
import { ReportesService } from './../reportes.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sell-trhu-detalle',
  templateUrl: './sell-trhu-detalle.component.html',
  styleUrls: ['./sell-trhu-detalle.component.css']
})

export class SellTrhuDetalleComponent implements OnInit {

  suscripcion: Subscription;
  sellThru: Sellthru[];

  showRed: boolean;
  showTienda: boolean;
  showGrupo: boolean;
  showSubGrupo: boolean;
  showSex: boolean;
  showModelo: boolean;
  showFabricante: boolean;
  showTemporada: boolean;
  showColeccion: boolean;
  showTipo: boolean;
  showProducto: boolean;
  showColor: boolean;
  showSemanas: boolean;
  showVentas: boolean;

cols: string[];

  constructor(private route: ActivatedRoute, private reportesService: ReportesService) {
    this.showRed = false;
    this.showTienda = false;
    this.showGrupo = false;
    this.showSubGrupo = false;
    this.showSex = false;
    this.showModelo = false;
    this.showFabricante = false;
    this.showTemporada = false;
    this.showColeccion = false;
    this.showTipo = false;
    this.showProducto = false;
    this.showColor = false;
    this.showSemanas = false;
    this.showVentas = false;
  }

  ngOnInit() {
    this.suscripcion = this.route.params.subscribe(
      (params: any) => {
        const productFilter = params['idProductFilter'];
        const storeFilter = params['idStoreFilter'];
        const groupers = params['idGroupers'];
        const otros = params['idOtros'];

        let otrasCols: string[];
        otrasCols = otros.split('--');

        if (otrasCols[0].length > 0) {
          this.showSemanas = true;
        } else {
          this.showSemanas = false;
        }

        if (otrasCols[1].length > 0) {
          this.showVentas = true;
        } else {
          this.showVentas = false;
        }

        let columnas: string[];
        columnas = groupers.split('--');
        this.cols = columnas;

        if ( columnas[0].length > 0 ) {
          this.showRed = true;
        } else {
          this.showRed = false;
        }

        if ( columnas[1].length > 0 ) {
          this.showTienda = true;
        } else {
          this.showTienda = false;
        }

        if ( columnas[2].length > 0 ) {
          this.showGrupo = true;
        } else {
          this.showGrupo = false;
        }

        if ( columnas[3].length > 0 ) {
          this.showSubGrupo = true;
        } else {
          this.showSubGrupo = false;
        }

        if ( columnas[4].length > 0 ) {
          this.showModelo = true;
        } else {
          this.showModelo = false;
        }

        if ( columnas[5].length > 0 ) {
          this.showFabricante = true;
        } else {
          this.showFabricante = false;
        }

        if ( columnas[6].length > 0 ) {
          this.showTemporada = true;
        } else {
          this.showTemporada = false;
        }

        if ( columnas[7].length > 0 ) {
          this.showSex = true;
        }  else {
          this.showSex = false;
        }

        if ( columnas[8].length > 0 ) {
          this.showTipo = true;
        } else {
          this.showTipo = false;
        }

        if ( columnas[9].length > 0 ) {
          this.showColor = true;
        } else {
          this.showColor = false;
        }

        if ( columnas[10].length > 0 ) {
          this.showProducto = true;
        } else {
          this.showProducto = false;
        }

        if ( columnas[11].length > 0 ) {
          this.showColeccion = true;
        } else {
          this.showColeccion = false;
        }

        this.reportesService.obtenerSellThru(productFilter, storeFilter, groupers)
        .subscribe(res => this.sellThru = res);
      }
    );



  }

  OnDestroy() {
    this.suscripcion.unsubscribe();
  }
}

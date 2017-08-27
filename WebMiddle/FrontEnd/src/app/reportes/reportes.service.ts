import { Sellthru } from './../Model/SellThru';
import { DataMaestraService } from './../data-maestra/data-maestra.service';
import { MaestroModel } from './../Model/MaestroModel';
import { StockProdColorSucursalComponent } from './stock-prod-color-sucursal/stock-prod-color-sucursal.component';
import { ProductoTalla } from './../Model/ProductoTalla';
import { KardexTiendaProductoColor } from './../Model/KardexTiendaProductoColor';
import { Injectable, EventEmitter } from '@angular/core';
import { Headers, Http, Request, RequestMethod, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx'
import * as config from '../app.configuration';

@Injectable()
export class ReportesService {
  API_BASE_URL: string = config.appApiUrl;

  constructor(private http: Http, private dataMaestraService: DataMaestraService) { }

  obtenerStockSucursalProdColor(tienda: string, producto: string, color: string) {
    const API_STOCK_SUCURSAL_PROD_COLOR_URL = `${this.API_BASE_URL}/ReporteKardexTiendaProductoColor/${tienda}/${producto}/${color}`;

    return this.http.get(API_STOCK_SUCURSAL_PROD_COLOR_URL)
      .map(res => <KardexTiendaProductoColor[]>res.json());
  }

  obtenerSellThru(productFilter: string, storeFilter: string, groupers: string) {
    const API_SELL_TRHU_URL = `${this.API_BASE_URL}/ReporteSellthru/${productFilter}/${storeFilter}/${groupers}`;

    return this.http.get(API_SELL_TRHU_URL)
      .map(res => <Sellthru[]>res.json());
  }

  obtenerTallasProducto(producto: string) {
    const API_PRODUCTO_TALLA_URL = `${this.API_BASE_URL}/ProductoTalla/${producto.replace(/\./gi, '_')}`;

    return this.http.get(API_PRODUCTO_TALLA_URL)
      .map(res => <ProductoTalla>res.json());
  }

  obtenerRedTiendas() {
    return this.dataMaestraService.obtenerRedTiendas();
  }

  obtenerTiendasPorRed(idRed: string) {
    return this.dataMaestraService.obtenerTiendasPorRed(idRed);
  }

  obtenerGruposProducto() {
    return this.dataMaestraService.obtenerGrupoProducto();
  }

  obtenerSubgruposPopductoPorGrupo(idGrupo) {
    return this.dataMaestraService.obtenerSubgruposProductoPorGrupo(idGrupo);
  }

  obtenerModelos() {
    return this.dataMaestraService.obtenerModelos();
  }

  obtenerColores() {
    return this.dataMaestraService.obtenerColores();
  }

  obtenerFabricantes() {
    return this.dataMaestraService.obtenerFabricantes();
  }

  obtenertemporadas() {
    return this.dataMaestraService.obtenerTemporadas();
  }

  obtenerColecciones() {
    return this.dataMaestraService.obtenerColecciones();
  }

  obtenerTiposProducto() {
    return this.dataMaestraService.obtenerTiposProducto();
  }

  obtenerSexos() {
    return this.dataMaestraService.obtenerSexos();
  }
}

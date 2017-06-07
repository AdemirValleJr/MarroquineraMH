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

  //API_BASE_URL: string = 'http://sapserver/mhwebapi/api';
  API_BASE_URL: string = config.appApiUrl;
  API_STOCK_SUCURSAL_PROD_COLOR_URL: string;
  API_PRODUCTO_TALLA_URL: string;

  constructor(private http: Http) { }

  obtenerStockSucursalProdColor(tienda: string, producto: string, color: string) {
    this.API_STOCK_SUCURSAL_PROD_COLOR_URL = `${this.API_BASE_URL}/ReporteKardexTiendaProductoColor/${tienda}/${producto}/${color}`;

    console.log(this.API_STOCK_SUCURSAL_PROD_COLOR_URL)

    return this.http.get(this.API_STOCK_SUCURSAL_PROD_COLOR_URL)
      .map(res => <KardexTiendaProductoColor[]>res.json());
  }

  obtenerTallasProducto(producto: string) {
    this.API_PRODUCTO_TALLA_URL = `${this.API_BASE_URL}/ProductoTalla/${producto.replace(/\./gi, '_')}`;

    return this.http.get(this.API_PRODUCTO_TALLA_URL)
      .map(res => <ProductoTalla>res.json());
  }
}

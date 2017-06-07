import { MaestroModel } from './../Model/MaestroModel';
import { Injectable } from '@angular/core';
import { Headers, Http, Request, RequestMethod, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx'
import * as config from '../app.configuration';


@Injectable()
export class DataMaestraService {  
  API_BASE_URL: string = config.appApiUrl;
  API_PRODUCTOS_URL: string = `${this.API_BASE_URL}/producto`;
  API_TIENDAS_URL: string = `${this.API_BASE_URL}/tienda`;
  API_COLORES_URL: string = `${this.API_BASE_URL}/color`;

  constructor(private http: Http) { }

  obtenerProductos() {
    return this.http.get(this.API_PRODUCTOS_URL)
      .map(res => <MaestroModel[]>res.json())
  }

  obtenerTiendas() {
    return this.http.get(this.API_TIENDAS_URL)
      .map(res => <MaestroModel[]>res.json())
  }

  obtenerColores() {
    return this.http.get(this.API_COLORES_URL)
      .map(res => <MaestroModel[]>res.json())
  }
}

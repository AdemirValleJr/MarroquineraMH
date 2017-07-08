import { SubgrupoProducto } from './../Model/SubgrupoProducto';
import { MaestroModel } from './../Model/MaestroModel';
import { Injectable } from '@angular/core';
import { Headers, Http, Request, RequestMethod, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx'
import * as config from '../app.configuration';


@Injectable()
export class DataMaestraService {
  constructor(private http: Http) { }

  obtenerProductos() {
    return this.http.get(`${config.appApiUrl}/producto`)
      .map(res => <MaestroModel[]>res.json());
  }

  obtenerTiendas() {
    return this.http.get(`${config.appApiUrl}/tienda`)
      .map(res => <MaestroModel[]>res.json());
  }

  obtenerTiendasPorRed(idRed: string) {
    return this.http.get(`${config.appApiUrl}/tienda/${idRed}`)
      .map(res => <MaestroModel[]>res.json());
  }

  obtenerColores() {
    return this.http.get(`${config.appApiUrl}/color`)
      .map(res => <MaestroModel[]>res.json());
  }

  obtenerFabricantes() {
    return this.http.get(`${config.appApiUrl}/fabricante`)
      .map(res => <MaestroModel[]>res.json());
  }

  obtenerGrupoProducto() {
    return this.http.get(`${config.appApiUrl}/grupoproducto`)
      .map(res => <MaestroModel[]>res.json());
  }

  obtenerSubgruposProducto() {
    return this.http.get(`${config.appApiUrl}/subgrupoproducto`)
      .map(res => <MaestroModel[]>res.json());
  }

  obtenerSubgruposProductoPorGrupo(idGrupo: string) {
    return this.http.get(`${config.appApiUrl}/subgrupoproducto/${idGrupo}`)
      .map(res => <SubgrupoProducto[]>res.json());
  }

  obtenerModelos() {
    return this.http.get(`${config.appApiUrl}/modelo`)
      .map(res => <MaestroModel[]>res.json());
  }

  obtenerRedTiendas() {
    return this.http.get(`${config.appApiUrl}/redtiendas`)
      .map(res => <MaestroModel[]>res.json());
  }

  obtenerTemporadas() {
    return this.http.get(`${config.appApiUrl}/temporada`)
      .map(res => <MaestroModel[]>res.json());
  }

  obtenerTiposProducto() {
    return this.http.get(`${config.appApiUrl}/TipoProducto`)
      .map(res => <MaestroModel[]>res.json());
  }

  obtenerSexos() {
    return [
      {id: 0, descripcion: 'SxINDEFINIDO'},
      {id: 1, descripcion: 'INDEFINIDO'},
      {id: 2, descripcion: 'MASCULINO'},
      {id: 3, descripcion: 'FEMININO'},
      {id: 4, descripcion: 'UNISSEX'}
    ];
  }
}

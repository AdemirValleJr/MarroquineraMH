import { element } from 'protractor';
import { MenuTreeModel } from './../Model/MenuTree';
import { TreeNode } from 'primeng/primeng';
import { MenuModel } from './../Model/Menu';
import { Usuario } from './../Model/Usuario';
import { MaestroModel } from './../Model/MaestroModel';
import { Injectable, EventEmitter } from '@angular/core';
import { Headers, Http, Request, RequestMethod, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx'
import 'rxjs/add/operator/toPromise';
import * as config from '../app.configuration';

@Injectable()
export class SeguridadService {

  API_BASE_URL: string = config.appApiUrl;
  usuarioAutenticado: boolean;
  idUsuario: string;
  desRol: string;
  guards: string[];
  mostrarMenu = new EventEmitter<boolean>();

  constructor(private http: Http) { }

  obtenerRoles() {
    return this.http.get(`${this.API_BASE_URL}/rol`)
      .map(res => <MaestroModel[]>res.json());
  }

  obtenerRol(id: number) {
    return this.http.get(`${this.API_BASE_URL}/rol/${id}`)
    .map(res => this.handleMapRol(res, id))
    .do(data => console.log('Data: ' + JSON.stringify(data)))
    .catch(this.handleError);
  }

  eliminarRol(id: string) {
    return this.http.delete(`${this.API_BASE_URL}/rol/${id}`)
      .map(res => res.json());
  }

  EditarRol(rol: MaestroModel) {
    return this.http.put(`${config.appApiUrl}/rol`, rol)
    .map(res => res.json());
  }

  nuevoRol(rol: MaestroModel) {
    return this.http.post(`${config.appApiUrl}/rol`, rol)
    .map(res => console.log(res.json()));
  }

  obtenerGuardRoles() {
    return this.http.get(`${this.API_BASE_URL}/guardrol`)
      .map(res => <MaestroModel[]>res.json());
  }

  nuevoGuardRol(guardRol: MaestroModel) {
    return this.http.post(`${config.appApiUrl}/guardrol`, guardRol)
    .map(res => console.log(res.json()));
  }

  eliminarGuardRol(id: string) {
    return this.http.delete(`${this.API_BASE_URL}/guardrol/${id}`)
      .map(res => res.json());
  }

  obtenerUsuarios() {
    return this.http.get(`${this.API_BASE_URL}/usuario`)
      .map(res => <Usuario[]>res.json());
  }

  obtenerUsuario(id: number) {
    return this.http.get(`${this.API_BASE_URL}/usuario/${id}`)
    .map(res => this.handleMapUsuario(res, id))
    .do(data => console.log('Data: ' + JSON.stringify(data)))
    .catch(this.handleError);
  }

  eliminarUsuario(id: string) {
    return this.http.delete(`${this.API_BASE_URL}/usuario/${id}`)
      .map(res =>res.json());
  }

  EditarUsuario(usuario: Usuario) {
    return this.http.put(`${config.appApiUrl}/usuario`, usuario)
    .map(res => res.json());
  }

  nuevoUsuario(usuario: Usuario) {
    return this.http.post(`${config.appApiUrl}/usuario`, usuario)
    .map(res => res.json());
  }

  obtenerMenus() {
    return this.http.get(`${this.API_BASE_URL}/menu`)
      .map(res => <MenuModel[]>res.json());
  }

  obtenerMenu(id: number) {
    return this.http.get(`${this.API_BASE_URL}/menu/${id}`)
    .map(res => this.handleMapMenu(res, id))
    .do(data => console.log('Data: ' + JSON.stringify(data)))
    .catch(this.handleError);
  }

  eliminarMenu(id: string) {
    return this.http.delete(`${this.API_BASE_URL}/menu/${id}`)
      .map(res => res.json());
  }

  EditarMenu(menu: MenuModel) {
    return this.http.put(`${config.appApiUrl}/menu`, menu)
    .map(res => res.json());
  }

  nuevoMenu(menu: MenuModel) {
    return this.http.post(`${config.appApiUrl}/menu`, menu)
    .map(res => console.log(res.json()));
  }

  getMenu() {
    return this.http.get(`${config.appApiUrl}/menu`)
    .toPromise()
    .then(res => <TreeNode[]> res.json().data);
  }

  getMenuRol(idRol: number) {
    return this.http.get(`${config.appApiUrl}/menurol/${idRol}`)
    .toPromise()
    .then(res => <TreeNode[]> res.json().data);
  }

  login(usuario: Usuario) {
    return this.http.post(`${config.appApiUrl}/logon`, usuario)
    .map(res => this.handleMapLogin(<Usuario>res.json()));
  }

  private handleMapRol(res: any, id: number) {
    const data = <MaestroModel> res.json();

    if (id === 0) {
        return {
            'descripcion': '',
            'id': 0
        };
    }
    return <MaestroModel> data;
  }

  private handleMapUsuario(res: any, id: number) {
    const data = <Usuario> res.json();

    if (id === 0) {
        return {
            'descripcion': '',
            'id': 0
        };
    }
    return <Usuario> data;
  }

  private handleMapMenu(res: any, id: number) {
    const data = <MenuModel> res.json();

    if (id === 0) {
        return {
            'id': null,
            'idPadre': null,
            'tipoMenu': '',
            'ruta': ''
        };
    }
    return <MenuModel> data;
  }

  private handleError(error: Response) {
    console.error(error);
    return Observable.throw(error.json().error || 'Server error');
  }

  private handleMapLogin(data: Usuario) {
    if ( data.idRol !== 0 ) {
      this.usuarioAutenticado = true;
      this.idUsuario = data.clave;
      this.desRol = data.descripcion;
      this.guards = data.guards;
      this.mostrarMenu.emit(true);

      // this.http.get(`${this.API_BASE_URL}/guardrol`).subscribe(res => this.guards = res.json());
      return true;
    }

    this.mostrarMenu.emit(false);
    return false;
  }

  usuarioEstaAutenticado() {
      return this.usuarioAutenticado;
  }

  rolUsuario() {
      return this.desRol;
  }

  validaGuardRol(guard) {
    let res: boolean;
    res = false;

    this.guards.forEach(element => {
      if(!res){
      if (element === guard) {
        res = true;
      } else {
        res = false;
      }
    }
    });

    return res;
  }

  private handleMapGuards(data) {

    console.log(data);
    this.guards = data;
  }

}

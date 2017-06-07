import { Subscription } from 'rxjs/Rx';
import { MaestroModel } from './../../Model/MaestroModel';
import { ProductoTalla } from './../../Model/ProductoTalla';
import { KardexTiendaProductoColor } from './../../Model/KardexTiendaProductoColor';
import { ReportesService } from './../reportes.service';
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-stock-prod-color-sucursal-detalle',
  templateUrl: './stock-prod-color-sucursal-detalle.component.html',
  styleUrls: ['./stock-prod-color-sucursal-detalle.component.css']
})
export class StockProdColorSucursalDetalleComponent implements OnInit {

  //tienda: string = "";
  //producto: string = "";
  //color: string = "";

  _kardex: KardexTiendaProductoColor[];
  _productoTalla: ProductoTalla;

  constructor(private route: ActivatedRoute, private reportesService: ReportesService) { }

  suscripcion: Subscription;

  ngOnInit() {
    this.suscripcion = this.route.params.subscribe(
      (params: any) => {
        let cTienda = params["idTienda"];
        let cProducto = params["idProducto"];
        let cColor = params['idColor'];

        this.generarReporte(cTienda, cProducto, cColor);
      }
    );    
  }

  generarReporte(tienda, producto, color) {
    this.reportesService.obtenerStockSucursalProdColor(tienda, producto, color)
      .subscribe(res => this.recibirReporte(res, producto));
  }

  recibirReporte(data, producto) {
    //console.log(data);
    this._kardex = data;
    //console.log(this._kardex);

    this.consultarTallas(producto);
  }

  consultarTallas(producto) {
    this.reportesService.obtenerTallasProducto(producto)
      .subscribe(res => this.recibirTallas(res));
  }

  recibirTallas(datos) {
    this._productoTalla = datos;
    //console.log(this._productoTalla);
    this.trabajarDatos();
  }

  cols: any;
  numTallas: number;

  trabajarDatos() {

    this.numTallas = this._productoTalla.TAMANHOS_DIGITADOS;

    let modelo = new Array<{ field: string, header: string, color:string }>();

    for (var index = 0; index < this.numTallas; index++) {

      let campo = `mov${this.pad(index + 1, 2)}`;
      let etiqueta = this._productoTalla[`TAMANHO_${index + 1}`];


      modelo.push({ field: campo, header: etiqueta, color:'blue' });
    }

    for (var index = 0; index < this.numTallas; index++) {

      let campo = `saldo${this.pad(index + 1, 2)}`;
      let etiqueta = this._productoTalla[`TAMANHO_${index + 1}`];


      modelo.push({ field: campo, header: etiqueta, color:'green' });
    }

    this.cols = modelo;

    console.log(this.cols);
  }


  pad(num: number, size: number): string {
    var s = num + "";
    while (s.length < size) s = "0" + s;
    return s;
  }

  ngOnDestroy() {
    this.suscripcion.unsubscribe();
  }

}

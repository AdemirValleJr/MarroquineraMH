import { MaestroModel } from './../../Model/MaestroModel';
import { DataMaestraService } from './../data-maestra.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit {

  productos: MaestroModel[];

  constructor(private dataMaestraService: DataMaestraService) { }  

  ngOnInit() {
    this.dataMaestraService.obtenerProductos()
    .subscribe(res => this.productos = res);
  }
}

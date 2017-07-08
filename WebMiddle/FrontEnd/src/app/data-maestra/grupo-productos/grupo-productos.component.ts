import { MaestroModel } from './../../Model/MaestroModel';
import { DataMaestraService } from './../data-maestra.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-grupo-productos',
  templateUrl: './grupo-productos.component.html',
  styleUrls: ['./grupo-productos.component.css']
})
export class GrupoProductosComponent implements OnInit {

  grupos: MaestroModel[];

  constructor(private dataMaestraService: DataMaestraService) { }

  ngOnInit() {
    this.dataMaestraService.obtenerGrupoProducto()
      .subscribe(res => this.grupos = res);
  }

}

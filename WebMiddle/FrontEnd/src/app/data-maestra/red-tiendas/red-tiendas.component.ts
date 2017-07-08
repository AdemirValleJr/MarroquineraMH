import { MaestroModel } from './../../Model/MaestroModel';
import { DataMaestraService } from './../data-maestra.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-red-tiendas',
  templateUrl: './red-tiendas.component.html',
  styleUrls: ['./red-tiendas.component.css']
})
export class RedTiendasComponent implements OnInit {

  redTiendas: MaestroModel[];

  constructor(private dataMaestraService: DataMaestraService) { }

  ngOnInit() {
    this.dataMaestraService.obtenerRedTiendas()
      .subscribe(res => this.redTiendas = res);
  }
}

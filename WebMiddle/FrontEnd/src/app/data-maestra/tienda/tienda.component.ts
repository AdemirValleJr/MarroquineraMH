import { DataMaestraService } from './../data-maestra.service';
import { MaestroModel } from './../../Model/MaestroModel';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tienda',
  templateUrl: './tienda.component.html',
  styleUrls: ['./tienda.component.css']
})
export class TiendaComponent implements OnInit {

tiendas: MaestroModel[];

  constructor(private dataMaestraService: DataMaestraService) { }

ngOnInit() {
    this.dataMaestraService.obtenerTiendas()
    .subscribe(res => this.tiendas = res);    
  }  
}

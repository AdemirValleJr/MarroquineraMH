import { MaestroModel } from './../../Model/MaestroModel';
import { DataMaestraService } from './../data-maestra.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-color',
  templateUrl: './color.component.html',
  styleUrls: ['./color.component.css']
})
export class ColorComponent implements OnInit {

  colores: MaestroModel[];

  constructor(private dataMaestraService: DataMaestraService) { }

  ngOnInit() {
    this.dataMaestraService.obtenerColores()
      .subscribe(res => this.colores = res);
  }

}

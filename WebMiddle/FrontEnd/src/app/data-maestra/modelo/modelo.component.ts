import { MaestroModel } from './../../Model/MaestroModel';
import { DataMaestraService } from './../data-maestra.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-modelo',
  templateUrl: './modelo.component.html',
  styleUrls: ['./modelo.component.css']
})
export class ModeloComponent implements OnInit {

  modelos: MaestroModel[];

  constructor(private dataMaestraService: DataMaestraService) { }

  ngOnInit() {
    this.dataMaestraService.obtenerModelos()
      .subscribe(res => this.modelos = res);
  }
}

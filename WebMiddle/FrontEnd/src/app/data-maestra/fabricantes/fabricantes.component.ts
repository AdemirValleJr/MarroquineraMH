import { MaestroModel } from './../../Model/MaestroModel';
import { DataMaestraService } from './../data-maestra.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-fabricantes',
  templateUrl: './fabricantes.component.html',
  styleUrls: ['./fabricantes.component.css']
})
export class FabricantesComponent implements OnInit {

  fabricantes: MaestroModel[];

  constructor(private dataMaestraService: DataMaestraService) { }

  ngOnInit() {
    this.dataMaestraService.obtenerFabricantes()
      .subscribe(res => this.fabricantes = res);
  }
}

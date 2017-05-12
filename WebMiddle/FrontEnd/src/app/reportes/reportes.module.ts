import { ReportesRoutingModule } from './reportes.routing.module';
import { DataTableModule } from 'primeng/primeng';
//import { RouterModule } from '@angular/router';
import { ReportesService } from './reportes.service';
import { DataMaestraModule } from './../data-maestra/data-maestra.module';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StockProdColorSucursalComponent } from './stock-prod-color-sucursal/stock-prod-color-sucursal.component';
import { StockProdColorSucursalDetalleComponent } from './stock-prod-color-sucursal-detalle/stock-prod-color-sucursal-detalle.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    DataTableModule,
    ModalModule.forRoot(),
    DataMaestraModule,
    ReportesRoutingModule
  ],
  exports:[
    StockProdColorSucursalComponent
  ],
  declarations: [StockProdColorSucursalComponent, StockProdColorSucursalDetalleComponent],
  providers:[ReportesService]
})
export class ReportesModule { }

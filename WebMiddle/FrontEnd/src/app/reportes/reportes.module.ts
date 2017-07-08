import { ReportesRoutingModule } from './reportes.routing.module';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations'
import { DataTableModule, CalendarModule } from 'primeng/primeng';
import { ReportesService } from './reportes.service';
import { DataMaestraModule } from './../data-maestra/data-maestra.module';
import { ModalModule } from 'ngx-bootstrap/modal';
import { DatepickerModule } from 'ngx-bootstrap/datepicker';

import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StockProdColorSucursalComponent } from './stock-prod-color-sucursal/stock-prod-color-sucursal.component';
import { StockProdColorSucursalDetalleComponent } from './stock-prod-color-sucursal-detalle/stock-prod-color-sucursal-detalle.component';
import { SellTrhuComponent } from './sell-trhu/sell-trhu.component';
import { SellTrhuDetalleComponent } from './sell-trhu-detalle/sell-trhu-detalle.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    BrowserAnimationsModule,
    NoopAnimationsModule,
    DataTableModule,
    ModalModule.forRoot(),
    DatepickerModule.forRoot(),
    CalendarModule,
    DataMaestraModule,
    ReportesRoutingModule
  ],
  exports: [
    StockProdColorSucursalComponent
  ],
  declarations: [StockProdColorSucursalComponent, StockProdColorSucursalDetalleComponent, SellTrhuComponent, SellTrhuDetalleComponent],
  providers: [ReportesService]
})
export class ReportesModule { }

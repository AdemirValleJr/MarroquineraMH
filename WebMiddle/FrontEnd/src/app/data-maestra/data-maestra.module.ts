import { DataTableModule } from 'primeng/primeng';
import { DataMaestraService } from './data-maestra.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductoComponent } from './producto/producto.component';
import { TiendaComponent } from './tienda/tienda.component';
import { ColorComponent } from './color/color.component';
import { ProductoTallaComponent } from './producto-talla/producto-talla.component';


@NgModule({
  imports: [
    CommonModule,
    DataTableModule
  ],
  exports:[
    ProductoComponent, 
    TiendaComponent, 
    ColorComponent
    ],
  declarations: [
    ProductoComponent, 
    TiendaComponent, 
    ColorComponent, ProductoTallaComponent
    ],
  providers: [DataMaestraService]
})
export class DataMaestraModule { }

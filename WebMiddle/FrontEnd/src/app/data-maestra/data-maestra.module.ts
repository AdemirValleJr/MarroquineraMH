import { DataTableModule } from 'primeng/primeng';
import { DataMaestraService } from './data-maestra.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductoComponent } from './producto/producto.component';
import { TiendaComponent } from './tienda/tienda.component';
import { ColorComponent } from './color/color.component';
import { ProductoTallaComponent } from './producto-talla/producto-talla.component';
import { FabricantesComponent } from './fabricantes/fabricantes.component';
import { GrupoProductosComponent } from './grupo-productos/grupo-productos.component';
import { SubgrupoProductosComponent } from './subgrupo-productos/subgrupo-productos.component';
import { ModeloComponent } from './modelo/modelo.component';
import { RedTiendasComponent } from './red-tiendas/red-tiendas.component';
import { TemporadaComponent } from './temporada/temporada.component';
import { ColeccionComponent } from './coleccion/coleccion.component';


@NgModule({
  imports: [
    CommonModule,
    DataTableModule
  ],
  exports: [
    ProductoComponent,
    TiendaComponent,
    ColorComponent,
    FabricantesComponent,
    GrupoProductosComponent,
    SubgrupoProductosComponent,
    ModeloComponent,
    RedTiendasComponent,
    TemporadaComponent
    ],
  declarations: [
    ProductoComponent,
    TiendaComponent,
    ColorComponent,
    ProductoTallaComponent,
    FabricantesComponent,
    GrupoProductosComponent,
    SubgrupoProductosComponent,
    ModeloComponent,
    RedTiendasComponent,
    TemporadaComponent,
    ColeccionComponent
    ],
  providers: [DataMaestraService]
})
export class DataMaestraModule { }

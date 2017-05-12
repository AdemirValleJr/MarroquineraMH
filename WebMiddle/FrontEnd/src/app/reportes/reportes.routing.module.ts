import { StockProdColorSucursalDetalleComponent } from './stock-prod-color-sucursal-detalle/stock-prod-color-sucursal-detalle.component';
import { StockProdColorSucursalComponent } from './stock-prod-color-sucursal/stock-prod-color-sucursal.component';
//import { PaginaNaoEncontradaComponent } from './pagina-nao-encontrada/pagina-nao-encontrada.component';
import { NgModule } from '@angular/core';
import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const reportesRoutes: Routes = [
    {
        path: 'stockSucursalProdColor',
        component: StockProdColorSucursalComponent,
        children: [
            {
                path: ':idTienda/:idProducto/:idColor',
                component: StockProdColorSucursalDetalleComponent
            }
        ]
    },
    ///reportes/stockSucursalProdColor',    
];

@NgModule({
    imports: [RouterModule.forChild(reportesRoutes)],
    exports: [RouterModule]
})
export class ReportesRoutingModule { }
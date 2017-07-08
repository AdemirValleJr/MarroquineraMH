import { SellTrhuDetalleComponent } from './sell-trhu-detalle/sell-trhu-detalle.component';
import { SellTrhuComponent } from './sell-trhu/sell-trhu.component';
import { StockProdColorSucursalDetalleComponent } from './stock-prod-color-sucursal-detalle/stock-prod-color-sucursal-detalle.component';
import { StockProdColorSucursalComponent } from './stock-prod-color-sucursal/stock-prod-color-sucursal.component';
// import { PaginaNaoEncontradaComponent } from './pagina-nao-encontrada/pagina-nao-encontrada.component';
import { NgModule } from '@angular/core';
import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const reportesRoutes: Routes = [
    {
        path: 'reportes/kardex',
        component: StockProdColorSucursalComponent,
        children: [
            {
                path: ':idTienda/:idProducto/:idColor',
                component: StockProdColorSucursalDetalleComponent
            }
        ]
    },
    {
        path: 'reportes/sellthru',
        component: SellTrhuComponent,
        children: [
            {
                path: ':idProductFilter/:idStoreFilter/:idGroupers',
                component: SellTrhuDetalleComponent
            }
        ]
    },
];

@NgModule({
    imports: [RouterModule.forChild(reportesRoutes)],
    exports: [RouterModule]
})
export class ReportesRoutingModule { }

import { StockProdColorSucursalDetalleComponent } from './reportes/stock-prod-color-sucursal-detalle/stock-prod-color-sucursal-detalle.component';
import { StockProdColorSucursalComponent } from './reportes/stock-prod-color-sucursal/stock-prod-color-sucursal.component';
import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const APP_ROUTES: Routes = [
    { path: 'reportes/stockSucursalProdColor', component: StockProdColorSucursalComponent },
    { path: 'reportes/stockSucursalProdColor/:idTienda/:idProducto/:idColor', component: StockProdColorSucursalDetalleComponent },
    //{ path: 'login', component: LoginComponent },
    //{ path: 'naoEncontrado', component: CursoNaoEncontradoComponent },
    { path: '', component: StockProdColorSucursalComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(APP_ROUTES);
import { GuardRolGuard } from './Guards/guard-rol.guard';
import { UsuariosGuard } from './Guards/usuarios.guard';
import { SellThruGuard } from './Guards/sell-thru.guard';
import { KardexGuard } from './Guards/kardex.guard';
import { AuthGuard } from './Guards/auth.guard';
import { AppRoutingModule } from './app.routing.module';
import { Routes, RouterModule } from '@angular/router';
import { SeguridadModule } from './seguridad/seguridad.module';
import { ReportesModule } from './reportes/reportes.module';
import { DataMaestraModule } from './data-maestra/data-maestra.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule,
    ReportesModule,
    SeguridadModule,
    AppRoutingModule
  ],
  providers: [
    AuthGuard, KardexGuard, SellThruGuard, UsuariosGuard, GuardRolGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

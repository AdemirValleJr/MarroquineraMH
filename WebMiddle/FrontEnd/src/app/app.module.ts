import { AppRoutingModule } from './app.routing.module';
//import { routing } from './app.routing';
import { RouterModule } from '@angular/router';
import { SeguridadModule } from './seguridad/seguridad.module';
import { ReportesModule } from './reportes/reportes.module';
import { DataMaestraModule } from './data-maestra/data-maestra.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
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
  providers: [],    
  bootstrap: [AppComponent]
})
export class AppModule { }

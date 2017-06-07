import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { SeguridadService } from './seguridad.service';
import { MenuComponent } from './menu/menu.component';
import { Routes, RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    BsDropdownModule.forRoot()
  ],  
  declarations: [MenuComponent],
  exports:[MenuComponent],
  providers:[SeguridadService]
})
export class SeguridadModule { }

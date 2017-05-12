import { SeguridadService } from './seguridad.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './menu/menu.component';

@NgModule({
  imports: [
    CommonModule
  ],  
  declarations: [MenuComponent],
  exports:[MenuComponent],
  providers:[SeguridadService]
})
export class SeguridadModule { }

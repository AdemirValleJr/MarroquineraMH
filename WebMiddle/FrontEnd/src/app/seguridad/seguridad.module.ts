import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataTableModule } from 'primeng/primeng';
import { SeguridadRoutingModule } from './seguridad.routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { SeguridadService } from './seguridad.service';
import { MenuComponent } from './menu/menu.component';
import { Routes, RouterModule } from '@angular/router';
import { UsuarioListComponent } from './usuario-list/usuario-list.component';
import { UsuarioAddComponent } from './usuario-add/usuario-add.component';
import { UsuarioEditComponent } from './usuario-edit/usuario-edit.component';
import { TreeModule , TreeNode} from 'primeng/primeng';
import { LoginComponent } from './login/login.component';
import { NoEncontradoComponent } from './no-encontrado/no-encontrado.component';
import { GuardRolListComponent } from './guard-rol-list/guard-rol-list.component';
import { GuardRolAddComponent } from './guard-rol-add/guard-rol-add.component';

@NgModule({
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    RouterModule,
    DataTableModule,
    TreeModule,
    SeguridadRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ],
  declarations: [
    MenuComponent,
    UsuarioListComponent,
    UsuarioAddComponent,
    UsuarioEditComponent,
    LoginComponent,
    NoEncontradoComponent,
    GuardRolListComponent,
    GuardRolAddComponent,
  ],
  exports: [MenuComponent],
  providers: [SeguridadService]
})
export class SeguridadModule { }

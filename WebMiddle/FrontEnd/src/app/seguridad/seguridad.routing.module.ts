import { GuardRolGuard } from './../Guards/guard-rol.guard';
import { UsuariosGuard } from './../Guards/usuarios.guard';
import { GuardRolAddComponent } from './guard-rol-add/guard-rol-add.component';
import { GuardRolListComponent } from './guard-rol-list/guard-rol-list.component';
import { LoginComponent } from './login/login.component';
import { UsuarioEditComponent } from './usuario-edit/usuario-edit.component';
import { UsuarioAddComponent } from './usuario-add/usuario-add.component';
import { UsuarioListComponent } from './usuario-list/usuario-list.component';

import { NgModule } from '@angular/core';
import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const seguridadRoutes: Routes = [
    {
        path: 'usuario',
        component: UsuarioListComponent, canActivate: [UsuariosGuard]
    },
    {
        path: 'usuario/add',
        component: UsuarioAddComponent, canActivate: [UsuariosGuard]
    },
    {
        path: 'usuario/:id',
        component: UsuarioEditComponent, canActivate: [UsuariosGuard]
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
      path: 'guardrol',
      component: GuardRolListComponent, canActivate: [GuardRolGuard]
    },
    {
      path: 'guardrol/add',
      component: GuardRolAddComponent, canActivate: [GuardRolGuard]
    },
];

@NgModule({
    imports: [RouterModule.forChild(seguridadRoutes)],
    exports: [RouterModule]
})
export class SeguridadRoutingModule { }

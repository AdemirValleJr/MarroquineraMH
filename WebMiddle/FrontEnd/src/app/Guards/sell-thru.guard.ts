import { Observable } from 'rxjs/Rx';
import { SeguridadService } from './../seguridad/seguridad.service';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
@Injectable()
export class SellThruGuard implements CanActivate {

  constructor(
    private authService: SeguridadService,
    private router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | boolean {

      if (this.authService.usuarioEstaAutenticado() && this.authService.validaGuardRol('SellThru')) {
        return true;
      }

      this.router.navigate(['/']);
      return false;
    }
}

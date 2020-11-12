import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs';
import {JwtHelperService} from '@auth0/angular-jwt';
import {Injectable} from '@angular/core';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(private jwtService: JwtHelperService, private router: Router) {
  }

  canActivate(): boolean | Observable<boolean> {
    const token = localStorage.getItem('jwt');
    if (token && !this.jwtService.isTokenExpired(token)){
      return true;
    }
    this.router.navigate(['/auth/login']);
    return false;
  }

}

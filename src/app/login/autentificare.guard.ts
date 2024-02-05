import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuService } from '../services/autentificare.service';
import { Observable } from 'rxjs';
import { map, first } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private autService: AuService, private router: Router) {}

  canActivate(): Observable<boolean> | boolean {
    return this.autService.isLoggedIn.pipe(
      first(),
      map((loggedIn: boolean) => {
        if (loggedIn) {
          return true;
        } else {
          this.router.navigate(['/login']);
          return false;
        }
      })
    );
  }
}



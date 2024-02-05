import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuService {
  private loggedIn = new BehaviorSubject<boolean>(false);

  get isLoggedIn(): Observable<boolean> {
    return this.loggedIn.asObservable();
  }

  login(username: string, password: string): void {
    if (username === 'user' && password === 'password') {
      this.loggedIn.next(true);
    } else {
      this.loggedIn.next(false);
    }
  }

  logout(): void {
    this.loggedIn.next(false);
  }
}

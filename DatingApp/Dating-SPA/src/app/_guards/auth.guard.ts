import { Injectable } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
 
 constructor(private authService: AuthService, private router: Router ) {
   
 }

  canActivate(): boolean {
    if(this.authService.loggedIn())
    {
      return true;
    }
    
    console.log("you shall not pass");
    this.router.navigate(['/home']);
    
  }
  
}

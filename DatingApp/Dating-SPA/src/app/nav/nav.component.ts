import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
//import { AlertifyService } from '../_services/alertify.service'
import { Router } from '@angular/router'

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  model: any = {};

  constructor(public authService: AuthService,private router: Router ) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('login successfull');
    }, error =>{

      console.log('registration unsuccessfull');
    }, () => {
      this.router.navigate(['/members']);
    })
  }

  loggedIn(){
   return this.authService.loggedIn();
  }

  logout(){
    localStorage.removeItem('token');
    console.log('logged out')
    this.router.navigate(['/home'])

  }

}

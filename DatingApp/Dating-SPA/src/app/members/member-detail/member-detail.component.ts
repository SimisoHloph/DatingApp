import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.scss']
})
export class MemberDetailComponent implements OnInit {
 user : User;

  constructor(private userService: UserService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.LoadUser();
  }

  LoadUser()
  {
    this.userService.getUser(+this.route.snapshot.params['id']).subscribe((user: User)=>{
      this.user =user;
    },error => {
      console.log(error);
    });
  
   
  }
}

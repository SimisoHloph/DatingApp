import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/user';
import { UserService } from '../../_services/user.service';



@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.scss']
})
export class MemberListComponent implements OnInit {

  users: User[];
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.LoadUsers();
  }

  LoadUsers(){
    this.userService.getUsers().subscribe((users: User[])=>{
      this.users=users;
    }, error =>{
      console.log(error);
    })
  }

}

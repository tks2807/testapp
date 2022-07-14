import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { User } from './user';
import { UserPermission } from './userpermission';

@Component({
  selector: 'app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [DataService]
})
export class AppComponent implements OnInit {

  user: User = new User();
  up: UserPermission = new UserPermission();
  users: User[] = [];
  ups: UserPermission[] = [];
  tableMode: boolean = true;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.dataService.getUsers()
      .subscribe((data: User[]) => this.users = data);
  }

  save() {
    if (this.user.UserId == null) {
      this.dataService.createUser(this.user)
        .subscribe((data: User) => this.users.push(data));
    } else {
      this.dataService.updateUser(this.user)
        .subscribe(data => this.loadUsers());
    }
    this.cancel();
  }
  editUser(u: User) {
    this.user = u;
  }
  cancel() {
    this.user = new User();
    this.tableMode = true;
  }
  delete(u: User) {
    this.dataService.deleteUser(u.UserId)
      .subscribe(data => this.loadUsers());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }

  assign() {
    this.dataService.assignPermission(this.up)
      .subscribe((data: UserPermission) => this.ups.push(data));
  }

  remove(up: UserPermission) {
    this.dataService.removePermission(up.UserId, up.PermissionId)
      .subscribe(data => this.loadUsers());
  }
}

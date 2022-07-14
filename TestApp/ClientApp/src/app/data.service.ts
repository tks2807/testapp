import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user';
import { UserPermission } from './userpermission';

@Injectable()
export class DataService {
  private url = "/api/Values";

  constructor(private http: HttpClient) {
  }

  getUsers() {
    return this.http.get<User[]>(this.url + '/getusers');
  }

  getUser(id: number) {
    return this.http.get(this.url + '/user/' + id);
  }

  createUser(user: User) {
    return this.http.post(this.url + '/saveuser', user);
  }
  updateUser(user: User) {
    return this.http.put(this.url + '/updateuser', user);
  }
  deleteUser(id?: number) {
    return this.http.delete(this.url + '/deleteuser/' + id);
  }

  assignPermission(up: UserPermission) {
    return this.http.post(this.url + '/assignpermission', up);
  }

  removePermission(uid?: number, pid?: number) {
    return this.http.delete(this.url + '/deletepermission/' + uid + '/' + pid);
  }
}

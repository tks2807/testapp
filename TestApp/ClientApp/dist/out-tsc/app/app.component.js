import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { DataService } from './data.service';
import { User } from './user';
import { UserPermission } from './userpermission';
let AppComponent = class AppComponent {
    constructor(dataService) {
        this.dataService = dataService;
        this.user = new User();
        this.up = new UserPermission();
        this.users = [];
        this.ups = [];
        this.tableMode = true;
    }
    ngOnInit() {
        this.loadUsers();
    }
    loadUsers() {
        this.dataService.getUsers()
            .subscribe((data) => this.users = data);
    }
    save() {
        if (this.user.UserId == null) {
            this.dataService.createUser(this.user)
                .subscribe((data) => this.users.push(data));
        }
        else {
            this.dataService.updateUser(this.user)
                .subscribe(data => this.loadUsers());
        }
        this.cancel();
    }
    editUser(u) {
        this.user = u;
    }
    cancel() {
        this.user = new User();
        this.tableMode = true;
    }
    delete(u) {
        this.dataService.deleteUser(u.UserId)
            .subscribe(data => this.loadUsers());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
    assign() {
        this.dataService.assignPermission(this.up)
            .subscribe((data) => this.ups.push(data));
    }
    remove(up) {
        this.dataService.removePermission(up.UserId, up.PermissionId)
            .subscribe(data => this.loadUsers());
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app',
        templateUrl: './app.component.html',
        styleUrls: ['./app.component.css'],
        providers: [DataService]
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map
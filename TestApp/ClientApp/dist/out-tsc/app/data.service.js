import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let DataService = class DataService {
    constructor(http) {
        this.http = http;
        this.url = "/api/Values";
    }
    getUsers() {
        return this.http.get(this.url + '/getusers');
    }
    getUser(id) {
        return this.http.get(this.url + '/user/' + id);
    }
    createUser(user) {
        return this.http.post(this.url + '/saveuser', user);
    }
    updateUser(user) {
        return this.http.put(this.url + '/updateuser', user);
    }
    deleteUser(id) {
        return this.http.delete(this.url + '/deleteuser/' + id);
    }
    assignPermission(up) {
        return this.http.post(this.url + '/assignpermission', up);
    }
    removePermission(uid, pid) {
        return this.http.delete(this.url + '/deletepermission/' + uid + '/' + pid);
    }
};
DataService = __decorate([
    Injectable()
], DataService);
export { DataService };
//# sourceMappingURL=data.service.js.map
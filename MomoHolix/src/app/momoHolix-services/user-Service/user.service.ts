import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { IUser } from '../../momoHolix-interfaces/user';

import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }


  validateCredentials(emailId: string, password: string): Observable<string> {
    var userObj: IUser = {
      custId: 0,
      custName: "",
      gender: "",
      age: 0,
      custAddress: "",
      phoneNumber: 0,
      emailId: emailId,
      password: password,
      balance: 0,
      createdDate: new Date()
    };

    return this.http.post<string>('https://localhost:44378/api/User/ValidateUserCredentials', userObj).pipe(catchError(this.errorHandler));
  }

  //REGISTER User 

  registerUser(custName: string, gender: string,
    age: number,
    custAddress: string,
    phoneNumber: number,
    emailId: string,
    password: string): Observable<string> {

    var userObj: IUser = {
      custName: custName,
      gender: gender,
      age: age,
      custAddress: custAddress,
      phoneNumber: phoneNumber,
      emailId: emailId,
      password: password
    };

    return this.http.post<string>('https://localhost:44378/api/User/RegisterUser',userObj).pipe(catchError(this.errorHandler));
  }




  errorHandler(error: HttpErrorResponse) {
    console.error(error);
    return throwError(error.message || "Server Error");
  }




}

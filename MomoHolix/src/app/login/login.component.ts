import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from '../momoHolix-services/user-Service/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  msg: string = "";
  showMsgDiv: boolean = false;

  status: string = "";
  errorMsg: string = "";

  constructor(private _userService: UserService) { }


  submitLoginForm(form: NgForm) {

    this._userService.validateCredentials(form.value.email, form.value.password).subscribe(
      responseLoginStatus => {
        this.status = responseLoginStatus;
        this.showMsgDiv = true;
        if (this.status != "Invalid Credentials") {
          this.msg = "Login Successful";
        }
        else {
          this.msg = this.status + ". Try again or Register yourself NOW !!!";
        }
      },
      responseLoginError => {
        this.errorMsg = responseLoginError;
      },
      () => console.log("submitLoginForm executed successfully")

    );

  }

  ngOnInit() {

  }
 
}

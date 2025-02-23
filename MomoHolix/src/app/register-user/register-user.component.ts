import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { UserService } from '../momoHolix-services/user-Service/user.service';


@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit{

  registerForm!: FormGroup;
  status!: string;
  msg!: string;
  showMsgDiv: boolean = false;

  constructor(private _userService: UserService,private formBuilder: FormBuilder) { }

  //ngOnInit() {

  //  this.registerForm = this.formBuilder.group({
  //    customerName: ['']

  //  });

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      custName: ['',Validators.required],
      gender: ['',[Validators.required]],
      age: ['',[Validators.required]],
      custAddress: ['',[Validators.required]],
      phoneNumber: ['',[Validators.required]],
      emailId: ['', [Validators.required, Validators.minLength(12)]],
      password: ['',[Validators.required]]

    });
  }


  SubmitRegistration(form: FormGroup) {

    this._userService.registerUser(form.value.custName, form.value.gender, form.value.age, form.value.custAddress,
      form.value.phoneNumber, form.value.emailId, form.value.password).subscribe(
        responseRegistrationStatus => {
          
            this.status = responseRegistrationStatus;
           
           
        
        },
        responseRegistrationError => {
          this.status = responseRegistrationError;
          
        },
        ()=> console.log("SubmitRegistration method executed succesfully !!! ")
      )


    //if (this.registerForm.valid) {
    //  this.msg = "Registration Successful"
    //}
    //else {
    //  this.msg="Ooops...Try again Later !!!"
    //}


    console.log(form.value.custName, form.value.gender, form.value.age, form.value.custAddress,
    form.value.phoneNumber,form.value.emailId,form.value.password);
  }

}


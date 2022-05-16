import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { DaraParsingService } from '../dara-parsing.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  validateForm!: FormGroup;
  passwordVisible = false;
  password?: string;
  constructor(private fb: FormBuilder,private router: Router,private message: NzMessageService,private httpService: DaraParsingService) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      userName: [null, [Validators.required]],
      password: [null, [Validators.required]]
    });
    console.log(this.validateForm.value.userName)
  }


  
  submitForm(): void {
    this.validateForm.markAllAsTouched();
    console.log('submit', this.validateForm);
    if(this.validateForm.valid){
      const UserLoginDetail=this.validateForm.controls
      this.httpService.loginUser(UserLoginDetail["userName"].value,UserLoginDetail["password"].value).subscribe(
        (response) => {
          this.message.success('Successfully Login', {
            nzDuration: 2000
          })
          this.router.navigate(['/dashboard']);
          sessionStorage.setItem("logged_user",response.access_token);
          console.log(response.access_token);
        },
        (error: any) => {
          if(error.error.error_description==null){
            this.message.error("sometghin went wrong! Plaese Reload Your Page", {
              nzDuration: 2000
            });
          }
          else{
            this.message.error(error.error.error_description, {
              nzDuration: 2000
            });
          }
         
        },
        () => console.log("successfully Login")
      );
    }
    else{
      Object.values(this.validateForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
  
    }
  }

}

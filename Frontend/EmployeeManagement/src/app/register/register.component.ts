import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { DaraParsingService } from '../dara-parsing.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm!:FormGroup;
  passwordVisible = false;
  password?: string;
  constructor(private fb:FormBuilder,private httpService:DaraParsingService,private router:Router,private message:NzMessageService ) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      userName: [null, [Validators.required]],
      password: [null, [Validators.required,Validators.pattern("^[A-Z]{1,}[a-z]{5,}[0-9@#$%^&*()!]{1,}")]],
      confirm: ['', [this.confirmValidator]]
    });
  }

  RegisterForm(){
    
    if (this.registerForm.valid) {
      const userdetail=this.registerForm.controls
      // const RegisterBody=this.httpService.registerBody
      // RegisterBody.Email = userdetail["userName"].value;
      // RegisterBody.Password  =  userdetail["password"].value;
      // RegisterBody.ConfirmPassword = userdetail["confirm"].value;
     
      this.httpService.RegisterUser(userdetail["userName"].value,userdetail["password"].value,userdetail["confirm"].value).subscribe(
        (response) => {
          this.message.success('Successfully Register', {
            nzDuration: 2000
          })
          this.router.navigate(['/login']);
        },
        (error: any) => {
        console.log(error);       
        },
        () => console.log("successfully Register")
      );
    } else {
      Object.values(this.registerForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  validateConfirmPassword(): void {
    setTimeout(() => this.registerForm.controls['confirm'].updateValueAndValidity());
  }

  confirmValidator = (control: FormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { error: true, required: true };
    } else if (control.value !== this.registerForm.controls['password'].value) {
      return { confirm: true, error: true };
    }
    return {};
  };
  
}

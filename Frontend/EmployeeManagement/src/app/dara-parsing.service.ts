import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DaraParsingService {

  constructor(private http: HttpClient) { }

  // registerBody={
  //   "Email": "admin@getnada.com",
  //   "Password": "Admin@1234",
  //   "ConfirmPassword": "Admin@1234"
  // }


  loginUser(email: string,password: string): Observable<any>{
    let body =new URLSearchParams();
    body.set('username',email);
    body.set('password',password);
    body.set('grant_type',"password");
  
      const header=new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded');
      return this.http.post<any>(`https://4c56-106-201-236-89.ngrok.io/Token`,body,{headers:header});
    }

    RegisterUser(email: string,password: string,cpassword: string): Observable<any>{
      let Registerbody =new URLSearchParams();
      Registerbody.set('Email',email);
      Registerbody.set('Password',password);
      Registerbody.set('ConfirmPassword',cpassword);
        const header=new HttpHeaders().set('Content-Type','application/x-www-form-urlencoded');
        return this.http.post<any>(`https://4c56-106-201-236-89.ngrok.io/api/Account/Register`,Registerbody,{headers:header});
      }

    getEmployeeData(isActive:any){
        const header=new HttpHeaders().set('Content-Type','application/x-www-form-urlencoded');
        return this.http.get<any>(`https://4c56-106-201-236-89.ngrok.io/api/Project?isActive=${isActive}`,{headers:header});
    }
}

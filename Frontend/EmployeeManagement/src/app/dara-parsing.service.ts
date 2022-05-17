import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DaraParsingService {

  constructor(private http: HttpClient) { }

  ProjectBody={
    "Id": 1,
    "Name": "sample string 1",
    "Description": "sample string 2",
    "StartDate": "2022-05-17T10:54:34.5399036+05:30",
    "Status": "sample string 4",
    "IsActive": ""
  }


  loginUser(email: string,password: string): Observable<any>{
    let body =new URLSearchParams();
    body.set('username',email);
    body.set('password',password);
    body.set('grant_type',"password");
  
      const header=new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded');
      return this.http.post<any>(`https://localhost:44390/Token`,body,{headers:header});
    }

    RegisterUser(email: string,password: string,cpassword: string): Observable<any>{
      let Registerbody =new URLSearchParams();
      Registerbody.set('Email',email);
      Registerbody.set('Password',password);
      Registerbody.set('ConfirmPassword',cpassword);
        const header=new HttpHeaders().set('Content-Type','application/x-www-form-urlencoded');
        return this.http.post<any>(`https://localhost:44390/api/Account/Register`,Registerbody,{headers:header});
      }

    getEmployeeData(isActive:any){
        const header=new HttpHeaders().set('Content-Type','application/x-www-form-urlencoded');
        return this.http.get<any>(`https://localhost:44390/api/Project?isActive=${isActive}`,{headers:header});
    }

    AddProjectData(){
      const header=new HttpHeaders().set('Content-Type','application/x-www-form-urlencoded');
      return this.http.post<any>(`https://localhost:44390/api/Project`,this.ProjectBody,{headers:header});
  }
}

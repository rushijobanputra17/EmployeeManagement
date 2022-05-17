import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { DaraParsingService } from '../dara-parsing.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  showLoader = false;
  isVisible = false;
  validateForm!: FormGroup;
  Employee:any;
  EmployeeStatic:any;
  searchValue='';
  Status:any;
  switchValue = false;
  constructor(private fb: FormBuilder,private router: Router,private message: NzMessageService,private httpService: DaraParsingService) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      Name: [null, [Validators.required]],
      Description: [null, [Validators.required]],
      datePicker: [null, [Validators.required]],
      status: [],
      active:[]
    });
  }

  showModal(): void {
    this.isVisible = true;
  }

  handleOk(){
    
    this.showLoader = true;
    debugger
    const token =sessionStorage.getItem("logged_user")
    if(token==null){
      this.message.error("Login Required", {
        nzDuration: 1000
      });
      this.router.navigate(['/login']);
    }

    else{
      const ProjectDetail = this.validateForm.controls
      this.httpService.ProjectBody.Name = ProjectDetail["Name"].value;
      this.httpService.ProjectBody.Description = ProjectDetail["Description"].value;
      this.httpService.ProjectBody.StartDate = ProjectDetail["datePicker"].value;
      this.httpService.ProjectBody.Status = ProjectDetail["status"].value;
      this.httpService.ProjectBody.IsActive = ProjectDetail["active"].value;
      this.httpService.AddProjectData().subscribe(
        (response) => {
          console.log(response);
          this.showLoader = false;
          this.message.success("Project Added Successfully!", {
            nzDuration: 1000
          });
          this.isVisible = false;
          this.validateForm.reset();
          this.showLoader = false;
        },
        (error: any) => {
          this.message.error("Server Error! Please Reload Your Page", {
            nzDuration: 5000
          });
          this.showLoader = false;
        },
        () => console.log("done")
      );
    }
  
  }

  DeleteProduct(Data:any){

  }

  EditProduct(Data:any){

  }

  search(): void {
    this.Employee = this.EmployeeStatic.filter((item: any) => item.Name.toLowerCase().indexOf(this.searchValue.toLowerCase()) !== -1);
  }

  
  handleCancel():void{
    this.isVisible = false;
  }

  
  getEmployeeData(): void {
    this.showLoader = true;
    debugger
    const token =sessionStorage.getItem("logged_user")
    if(token==null){
      this.message.error("Login Required", {
        nzDuration: 1000
      });
      this.router.navigate(['/login']);
    }

    else{
      this.httpService.getEmployeeData(this.switchValue).subscribe(
        (response) => {
          console.log(response);
          this.showLoader = false;
          this.Employee=this.EmployeeStatic=response.Result;
        },
        (error: any) => {
          this.message.error("Server Error! Please Reload Your Page", {
            nzDuration: 5000
          });
          this.showLoader = false;
        },
        () => console.log("done")
      );
    }
  
  }


}

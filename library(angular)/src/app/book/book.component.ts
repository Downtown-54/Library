import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../service.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  statusAddForm: string;
  statusEditForm: string;
  values: any;

  addForm: any = {
    name: '',
    author: '',
    vendorCode: '',
    yearOfPublication: '',
    instances: '',
  }

  editForm: any = {
    id: '',
    name: '',
    author: '',
    vendorCode: '',
    yearOfPublication: '',
    instances: '',
  }

  constructor(private serviceApi: ServiceService) {
    this.statusAddForm = 'none';
    this.statusEditForm = 'none';
  }

  ngOnInit(): void {
    this.getValues();
  }
  printAddForm(): void{
    this.postValues();
  }
  printEditForm(): void{
    this.putValues();
  }

  AddFormDisplay() {
    return this.statusAddForm;
  }
  EditFormDisplay() {
    return this.statusEditForm;
  }

  change() {
    if(this.statusAddForm == 'none')
    {
      this.statusAddForm = 'block';
    }
    else
    {
      this.statusAddForm = 'none';
    }
  }

  openEditForm(id: number) {
    this.editForm.id = id;
    if(this.statusEditForm == 'none')
    {
      this.statusEditForm = 'block';
    }
    else
    {
      this.statusEditForm = 'none';
    }
  }

  putValues() {
    this.serviceApi.putData(this.editForm, "Book").subscribe((response: any) => {
       this.values = response;
    }, (error: any) => {
       console.log(error);
      });
  }

  postValues() {
    this.serviceApi.postData(this.addForm, "Book").subscribe((response: any) => {
       this.values = response;
    }, (error: any) => {
       console.log(error);
      });
  }

  getValues() {
    this.serviceApi.getData("Book").subscribe((response: any) => {
       this.values = response;
       console.log(response);
    }, (error: any) => {
       console.log(error);
      });
  }
}

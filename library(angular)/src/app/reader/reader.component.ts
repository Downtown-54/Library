import { identifierName } from '@angular/compiler';
import { Component, HostBinding,  OnInit } from '@angular/core';
import { ServiceService } from '../service.service';

@Component({
  selector: 'app-reader',
  templateUrl: './reader.component.html',
  styleUrls: ['./reader.component.css']
})
export class ReaderComponent implements OnInit {

  values: any;
  statusAddForm: string;
  statusEditForm: string;
  statusIssuedBookForm: string;

  addForm: any = {
    reader: '',
    dateBirth: '',
    numberPhone: '',
    email: '',
    address: '',
  }

  editForm: any = {
    id: '',
    reader: '',
    dateBirth: '',
    numberPhone: '',
    email: '',
    address: '',
  }

  issuedBookForm: any = {
    id: '',
    nameBook: '',
    author: '',
    dateOfDelivery: '',
  }

  constructor(private serviceApi: ServiceService) {
    this.statusAddForm = 'none';
    this.statusEditForm = 'none';
    this.statusIssuedBookForm = 'none';
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
  printIssuedBookForm(): void{
    this.postValueIssuedBook();
  }

  AddFormDisplay() {
    return this.statusAddForm;
  }
  EditFormDisplay() {
    return this.statusEditForm;
  }
  AddIssuedBookDisplay() {
    return this.statusIssuedBookForm;
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
  openIssuedBookForm(id: number) {
    this.issuedBookForm.id = id;
    if(this.statusIssuedBookForm == 'none')
    {
      this.statusIssuedBookForm = 'block';
    }
    else
    {
      this.statusIssuedBookForm = 'none';
    }
  }

  putValues() {
    this.serviceApi.putData(this.editForm, "Reader").subscribe((response: any) => {
       this.values = response;
    }, (error: any) => {
       console.log(error);
      });
  }

  postValues() {
    console.log(this.addForm);
    this.serviceApi.postData(this.addForm, "Reader").subscribe((response: any) => {
       this.values = response;
    }, (error: any) => {
       console.log(error);
      });
  }

  postValueIssuedBook() {
    this.serviceApi.postData(this.issuedBookForm, "IssuedBook").subscribe((response: any) => {
       this.values = response;
    }, (error: any) => {
       console.log(error);
      });
  }

  getValues() {
    this.serviceApi.getData("Reader").subscribe((response: any) => {
       this.values = response;
    }, (error: any) => {
       console.log(error);
      });
  }
}

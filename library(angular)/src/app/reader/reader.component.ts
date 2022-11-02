import { identifierName } from '@angular/compiler';
import { Component, HostBinding,  OnInit } from '@angular/core';
import { ServiceReader } from '../reader.service';
import { IssuedBookService } from '../issued-book.service';

export enum StatusForm {
  none = 'none',
  block = 'block'
}

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

  constructor(private api: ServiceReader, private apiIssuedBook: IssuedBookService) {
    this.statusAddForm = StatusForm.none;
    this.statusEditForm = StatusForm.none;
    this.statusIssuedBookForm = StatusForm.none;
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

  change() {
    if(this.statusAddForm == StatusForm.none)
    {
      this.statusAddForm = StatusForm.block;
    }
    else
    {
      this.addForm.reader = '';
      this.addForm.dateBirth = '';
      this.addForm.numberPhone = '';
      this.addForm.email = '';
      this.addForm.address = '';
      this.statusAddForm = StatusForm.none;
    }
  }
  openEditForm(id: number) {
    this.editForm.id = id;
    if(this.statusEditForm == StatusForm.none)
    {
      this.statusEditForm = StatusForm.block;
    }
    else
    {
      this.editForm.reader = '';
      this.editForm.dateBirth = '';
      this.editForm.numberPhone = '';
      this.editForm.email = '';
      this.editForm.address = '';
      this.statusEditForm = StatusForm.none;
    }

  }
  openIssuedBookForm(id: number) {
    this.issuedBookForm.id = id;
    if(this.statusIssuedBookForm == StatusForm.none && this.statusEditForm == StatusForm.none)
    {
      this.statusIssuedBookForm = StatusForm.block;
    }
    else
    {
      this.issuedBookForm.nameBook = '';
      this.issuedBookForm.author = '';
      this.issuedBookForm.dateOfDelivery = '';
      this.statusIssuedBookForm = StatusForm.none;
    }
  }

  putValues() {
    this.api.putData(this.editForm).subscribe((response: any) => {
       this.values = response;
    }, (error: any) => {
       console.log(error);
       alert("Что-то пошло не так! Если это повторится, то обратитесь в службу поддержки");
      });
  }

  postValues() {
    this.api.postData(this.addForm).subscribe((response: any) => {
       this.values = response;
    }, (error: any) => {
       console.log(error);
       alert("Что-то пошло не так! Если это повторится, то обратитесь в службу поддержки");
      });
  }

  postValueIssuedBook() {
    this.apiIssuedBook.postData(this.issuedBookForm).subscribe((response: any) => {
       this.values = response;
    }, (error: any) => {
       console.log(error);
       alert("Что-то пошло не так! Если это повторится, то обратитесь в службу поддержки");
      });
  }

  getValues() {
    this.api.getData().subscribe((response: any) => {
       this.values = response;
    }, (error: any) => {
       console.log(error);
       alert("Что-то пошло не так! Если это повторится, то обратитесь в службу поддержки");
      });
  }
}

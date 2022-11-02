import { Component, OnInit } from '@angular/core';
import { BookService } from '../book.service';

export enum StatusForm {
  none = 'none',
  block = 'block'
}

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

  constructor(private api: BookService) {
    this.statusAddForm = StatusForm.none;
    this.statusEditForm = StatusForm.none;
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

  change() {
    if(this.statusAddForm == StatusForm.none)
    {
      this.statusAddForm = StatusForm.block;
    }
    else
    {
      this.addForm.name = '';
      this.addForm.author = '';
      this.addForm.vendorCode = '';
      this.addForm.yearOfPublication = '';
      this.addForm.instances = '';
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
      this.editForm.name = '';
      this.editForm.author = '';
      this.editForm.vendorCode = '';
      this.editForm.yearOfPublication = '';
      this.editForm.instances = '';
      this.statusEditForm = StatusForm.none;
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

  getValues() {
    this.api.getData().subscribe((response: any) => {
       this.values = response;
       console.log(response);
    }, (error: any) => {
       console.log(error);
       alert("Что-то пошло не так! Если это повторится, то обратитесь в службу поддержки");
      });
  }
}

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ReaderComponent } from './reader/reader.component';
import { BookComponent } from './book/book.component';
import { RouterModule } from '@angular/router';
import { MainComponent } from './main/main.component';
import { HttpClientModule }   from '@angular/common/http';
import { FormsModule }   from '@angular/forms';

const routes = [
  {path: '', component: MainComponent},
  {path: 'reader', component: ReaderComponent},
  {path: 'book', component: BookComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    ReaderComponent,
    BookComponent,
    MainComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

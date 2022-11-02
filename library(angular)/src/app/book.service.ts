import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  putData(params: HttpParams){
    return  this.http.put(environment.configUrlBook, params,
      {headers: new HttpHeaders({'Content-Type': 'application/x-www-form-urlencoded'}) });
  }

  postData(params: HttpParams){
    return  this.http.post(environment.configUrlBook, params,
        {headers: new HttpHeaders({'Content-Type': 'application/x-www-form-urlencoded'})});
  }

  getData(){
    return this.http.get(environment.configUrlBook);
  }
}

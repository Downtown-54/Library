import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class IssuedBookService {
  constructor(private http: HttpClient) { }

  postData(params: HttpParams){
    return  this.http.post(environment.urlApi + "IssuedBook", params,
        {headers: new HttpHeaders({'Content-Type': 'application/x-www-form-urlencoded'})});
  }
}

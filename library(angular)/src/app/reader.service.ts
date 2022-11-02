import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class ServiceReader {

  constructor(private http: HttpClient) { }

  putData(params: HttpParams){
    return  this.http.put(environment.configUrlReader, params,
      {headers: new HttpHeaders({'Content-Type': 'application/x-www-form-urlencoded'}) });
  }

  postData(params: HttpParams){
    return  this.http.post(environment.configUrlReader, params,
        {headers: new HttpHeaders({'Content-Type': 'application/x-www-form-urlencoded'})});
  }

  getData(){
    return this.http.get(environment.configUrlReader);
  }

}



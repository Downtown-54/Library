import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class ServiceService {

  constructor(private http: HttpClient) { }

  putData(params: HttpParams, api: string){
    const configUrl= 'https://localhost:7194/' + api;

    return  this.http.put(configUrl, params, {headers: new HttpHeaders({'Content-Type': 'application/x-www-form-urlencoded'}) });
  }

  postData(params: HttpParams, api: string){
    const configUrl= 'https://localhost:7194/' + api;
    console.log(configUrl);

    return  this.http.post(configUrl, params,
        {headers: new HttpHeaders({'Content-Type': 'application/x-www-form-urlencoded'})});
  }

  getData(api: string){
    return this.http.get("https://localhost:7194/" + api);
  }

}



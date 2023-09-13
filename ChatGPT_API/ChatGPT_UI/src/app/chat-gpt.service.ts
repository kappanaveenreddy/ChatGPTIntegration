import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChatGPTService {


  constructor(private http:HttpClient) {

   }
  //  getData(input:string):Observable<any>{
  //   return this.http.get('https://localhost:7021/ChatGPT?input='+input,{responseType:'text'});
  //  }
   getData(input:string) {
    return this.http.get('https://localhost:44313/ChatGPT?input='+input,{responseType:'text'});
  }
}

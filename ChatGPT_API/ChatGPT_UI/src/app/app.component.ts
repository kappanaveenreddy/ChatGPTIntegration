import { Component } from '@angular/core';
import { ChatGPTService } from './chat-gpt.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ChatGPT Integration';
  searchText:string='';
  showOutput:boolean=false;
  output:string='';
  isLoading:boolean=false;
  // constructor(private service:ChatGPTService){

  // }
  constructor(private service:ChatGPTService){}
  getResult(){
    this.isLoading=true;
    this.output="";
    this.service.getData(this.searchText).subscribe(data=>{
      this.output=data as string;
      this.showOutput=true;
      this.isLoading=false;
    })
  }

}

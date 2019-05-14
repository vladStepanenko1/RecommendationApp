import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-help',
  templateUrl: './help.component.html',
  styleUrls: ['./help.component.css']
})
export class HelpComponent implements OnInit {
  message:string;
  constructor() { }

  ngOnInit() {
    this.message = "Розділ знаходиться в розробці";
  }

}

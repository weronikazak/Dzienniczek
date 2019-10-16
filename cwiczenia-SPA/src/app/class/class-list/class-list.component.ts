import { Component, OnInit } from '@angular/core';
import { Class } from 'src/app/models/class';

@Component({
  selector: 'app-class-list',
  templateUrl: './class-list.component.html',
  styleUrls: ['./class-list.component.css']
})
export class ClassListComponent implements OnInit {
  class: Class;
  classes: Class[];

  constructor() { }

  ngOnInit() {
  }

}

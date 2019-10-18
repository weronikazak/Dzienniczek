import { Component, OnInit } from '@angular/core';
import { Class } from 'src/app/models/class';
import { ClassService } from 'src/app/services/class.service';

@Component({
  selector: 'app-class-list',
  templateUrl: './class-list.component.html',
  styleUrls: ['./class-list.component.css']
})
export class ClassListComponent implements OnInit {
  class: Class;
  classes: Class[];

  constructor(private classService: ClassService) { }

  ngOnInit() {
    this.loadClasses();
  }

  loadClasses() {
    this.classService.getClasses().subscribe((classes: Class[]) => {
      this.classes = classes;
    });
  }

}

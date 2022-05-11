import { Component, Input, OnInit } from '@angular/core';
import { Subject } from '../../shared/models/subject';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'st-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.css'],
})
export class SubjectComponent implements OnInit {
  @Input()
  data: Subject;

  parentNames:string[]

  constructor() {}

  ngOnInit(): void {
    this.parentNames=Object.values(this.data.parents);
  }
  changeFinish(){
    this.data.finished= !this.data.finished;
  }
}

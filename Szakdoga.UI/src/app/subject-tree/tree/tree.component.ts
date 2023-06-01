import { Component, OnInit } from '@angular/core';
import { SubjectService } from '../services/subject.service';
import {Subject} from "../../shared/models/subject";
import {groupBy} from "../../shared/Extensions/arrayExtensions";

@Component({
  selector: 'st-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.css'],
})
export class TreeComponent implements OnInit {
  constructor(public subjectService: SubjectService) {

  }
  getMainSubjectsBySemester(): Subject[][] {
    if(this.subjectService.mainSubjects==null)
      return null;
    let output = Object.values(
      groupBy(this.subjectService.mainSubjects, (x) => x.recommendedSemester)
    );
    return output;
  }
  ngOnInit(): void {}

  getSpecSubjectsBySemester(): Subject[][] {
    if(this.subjectService.specSubjects==null)
      return null;
    let output = Object.values(
      groupBy(this.subjectService.specSubjects, (x) => x.recommendedSemester)
    );
    return output;
  }
  reDraw() {}
}

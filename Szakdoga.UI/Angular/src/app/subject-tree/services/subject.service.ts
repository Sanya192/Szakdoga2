import { Injectable } from '@angular/core';
import { groupBy } from '../../shared/Extensions/arrayExtensions';
import { Subject } from '../../shared/models/subject';
import { SyllabiService } from '../../shared/services/syllabi.service';
import { map, Observable } from 'rxjs';
import { newArray } from '@angular/compiler/src/util';
import { EventService } from '../../shared/services/event.service';

@Injectable({
  providedIn: 'root',
})
export class SubjectService {
  mainSubjects: Subject[];
  specSubjects: Subject[];
  otherSubjects: Subject[];
  specStartingSem: number;

  constructor(
    private syllabiService: SyllabiService,
    private events: EventService
  ) {
    events.subjectChanged.subscribe(() => {
      this.resetSubjects();
    });
  }

  getOtherSubjectsBySemester(): Subject[][] {
    let output = Object.values(
      groupBy(this.otherSubjects, (x) => x.recommendedSemester)
    );
    return output;
  }

  resetSubjects() {
    this.mainSubjects = this.syllabiService?.activeMainSyllabus?.subjects;
    this.specStartingSem =
      this.syllabiService?.activeMainSyllabus?.startingSpecSemester;
    this.specSubjects = [];
    console.log(this.syllabiService.selectedSpecSyllabi);
    if (this.syllabiService.selectedSpecSyllabi)
      this.syllabiService.selectedSpecSyllabi.forEach((x) => {
        x.subjects.forEach((y) => this.specSubjects.push(y));
      });
    console.log(this.specSubjects);
  }
}

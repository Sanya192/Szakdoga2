import { Component, Input, OnInit } from '@angular/core';
import { Subject } from '../../shared/models/subject';
import { MatCardModule } from '@angular/material/card';
import { RestClientService } from '../../shared/services/rest-client.service';

/**
 * A component for handling Subjects.
 * It visualizes them and also handles triggering the Finish for the subject.
 */
@Component({
  selector: 'st-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.css'],
})
export class SubjectComponent implements OnInit {
  @Input()
  data: Subject;

  @Input()
  spec: boolean;

  parentNames: string[];

  constructor(private rest: RestClientService) {}

  ngOnInit(): void {
    this.parentNames = Object.values(this.data.parents);
  }

  /**
   * Changes the Finish of the subject. Triggered by clicking on the component.
   */
  changeFinish() {
    if (this.data.finished) {
      this.rest.deSetFinishSubject(this.data.id).subscribe(
        () => (this.data.finished = false),
        () => {
          window.location.reload();
        }
      );
    } else {
      this.rest.setFinishSubject(this.data.id).subscribe(
        () => (this.data.finished = true),
        () => {
          window.location.reload();
        }
      );
    }
  }

  getHasParents() {
    return Object.keys(this.data.parents).length > 0;
  }
}

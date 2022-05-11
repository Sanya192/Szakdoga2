import { Component } from '@angular/core';
import { Subject } from './shared/models/subject';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Angular';
  sampleSubject = Subject.SampleSubject();

  constructor() {
    console.log(this.sampleSubject);
    console.log(Subject.SampleSubject());
  }
}

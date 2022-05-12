import { Component } from '@angular/core';
import { Subject } from './shared/models/subject';
import { EventService } from './shared/services/event.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Angular';
  sampleSubject = Subject.SampleSubject();
  loaded = false;

  constructor(private event: EventService) {
    event.subjectChanged.subscribe(x=>this.loaded=true);
  }
}

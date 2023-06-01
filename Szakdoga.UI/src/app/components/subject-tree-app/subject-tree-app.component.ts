import { Component, OnInit } from '@angular/core';
import { EventService } from '../../shared/services/event.service';

/**
 * Component for the Subject tree App.
 */
@Component({
  selector: 'app-subject-tree-app',
  templateUrl: './subject-tree-app.component.html',
  styleUrls: ['./subject-tree-app.component.css'],
})

export class SubjectTreeAppComponent implements OnInit {
  loaded = false;

  constructor(private event: EventService) {
    event.subjectChanged.subscribe((x) => (this.loaded = true));
  }

  ngOnInit(): void {}
}

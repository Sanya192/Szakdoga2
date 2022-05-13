import { Component, OnInit } from '@angular/core';
import { SyllabiService } from '../../services/syllabi.service';
import { EventService } from '../../services/event.service';

@Component({
  selector: 'app-head',
  templateUrl: './head.component.html',
  styleUrls: ['./head.component.css'],
})
export class HeadComponent implements OnInit {
  canStart: boolean;

  mainSyllabikeys() {
    return Object.keys(this.syllabusService?.allMainSyllabi);
  }

  mainSelectedKey: string;

  mainSelected(id: string) {
    this.syllabusService?.changeActiveMainSyllabus(id);
    this.specSelectedKeys = [];
  }

  specSyllabikeys() {
    return Object.keys(this.syllabusService?.allSpecForMain);
  }

  specSelectedKeys: string[];

  constructor(
    public syllabusService: SyllabiService,
    private events: EventService
  ) {
    this.canStart = false;
    events.syllabusLoaded.subscribe((x) => this.start());

  }

  specSelected() {
    if (!Array.isArray(this.specSelectedKeys))
      this.specSelectedKeys = [this.specSelectedKeys];

    this.syllabusService.selectMultibleSpec(this.specSelectedKeys);
    console.log('spec');
  }

  start() {
    if(!this.canStart){
    this.mainSelectedKey = this.syllabusService.activeMainSyllabus.id;
    this.specSelectedKeys = [];
    this.syllabusService.selectedSpecSyllabi.forEach((x) =>
      this.specSelectedKeys.push(x.id)
    );
    this.canStart = true;
  }}
}

  ngOnInit(): void {}
}

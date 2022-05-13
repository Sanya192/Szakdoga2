import { Component, OnInit } from '@angular/core';
import { SyllabiService } from '../../services/syllabi.service';
import { EventService } from '../../services/event.service';

@Component({
  selector: 'header-tree-head',
  templateUrl: './tree-head.component.html',
  styleUrls: ['./tree-head.component.css'],
})
export class TreeHeadComponent implements OnInit {
  canStart: boolean;
  canStartSpec: boolean;
  loadedDefaultPos:boolean;

  mainSyllabikeys: string[];

  mainSelectedKey: string;

  mainSelected() {
    console.log('I header called');
    this.specSelectedKeys = [];
    this.syllabusService?.changeActiveMainSyllabus(this.mainSelectedKey);
    this.specSelectedKeys = [];
  }

  specSyllabikeys() {
    if (this.syllabusService?.allSpecForMain)
      return Object.keys(this.syllabusService?.allSpecForMain);
    return null;
  }

  specSelectedKeys: string[];

  constructor(
    public syllabusService: SyllabiService,
    private events: EventService
  ) {
    this.canStart = false;
    this.canStartSpec = false;
    events.syllabusLoaded.subscribe((x) => this.startMain());
    events.specSyllabusLoaded.subscribe((x) => this.startspec());
    events.subjectChanged.subscribe(x=>this.loadDefaultSubject());
  }

  specSelected() {
    if (!Array.isArray(this.specSelectedKeys))
      this.specSelectedKeys = [this.specSelectedKeys];
    this.syllabusService.selectMultibleSpec(this.specSelectedKeys);
    console.log('spec');
  }

  startMain() {
    if (!this.canStart) {
      this.getMainKeys();
      this.canStart = true;
    }
  }
  loadDefaultSubject(){
    this.mainSelectedKey = this.syllabusService?.activeMainSyllabus?.id;
    this.loadedDefaultPos=true
  }

  startspec() {
    if (!this.canStartSpec) {
      this.specSelectedKeys = [];
      this.syllabusService.selectedSpecSyllabi.forEach((x) =>
        this.specSelectedKeys.push(x.id)
      );
      this.canStartSpec = true;
    }
  }

  getMainKeys() {
    this.mainSyllabikeys = Object.keys(this.syllabusService?.allMainSyllabi);
  }

  ngOnInit(): void {}
}

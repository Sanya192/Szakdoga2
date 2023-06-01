import { Component, OnInit } from '@angular/core';
import { SyllabiService } from '../../services/syllabi.service';
import { EventService } from '../../services/event.service';

@Component({
  selector: 'header-tree-head',
  templateUrl: './tree-head.component.html',
  styleUrls: ['./tree-head.component.css'],
})

/**
 * Header for the subject tree. Should be refactored into SubjectTree model.
 */
export class TreeHeadComponent implements OnInit {
  canStart: boolean;
  canStartSpec: boolean;
  loadedDefaultPos: boolean;

  mainSyllabikeys: string[];

  mainSelectedKey: string;

  /**
   * Triggered when selection for the main subject changed.
   */
  mainSelected() {
    this.specSelectedKeys = [];
    this.syllabusService?.changeActiveMainSyllabus(this.mainSelectedKey);
    this.specSelectedKeys = [];
  }

  /**
   * Gets all specialization keys.
   */
  specSyllabikeys() {
    if (this.syllabusService?.allSpecForMain)
      return Object.keys(this.syllabusService?.allSpecForMain);
    return null;
  }

  specSelectedKeys: string[];

  /**
   * Creates the object, and subscribes for events for loading.
   * @param syllabusService Injected dependency
   * @param events Injected dependency
   */
  constructor(
    public syllabusService: SyllabiService,
    private events: EventService
  ) {
    this.canStart = false;
    this.canStartSpec = false;
    events.syllabusLoaded.subscribe((x) => this.startMain());
    events.specSyllabusLoaded.subscribe((x) => this.startspec());
    events.subjectChanged.subscribe((x) => this.loadDefaultSubject());
  }

  /**
   * Gets All selected specialization.
   */
  specSelected() {
    if (!Array.isArray(this.specSelectedKeys))
      this.specSelectedKeys = [this.specSelectedKeys];
    this.syllabusService.selectMultibleSpec(this.specSelectedKeys);
    console.log('spec');
  }

  /**
   * Get's the main syllabi keys.
   */
  startMain() {
    if (!this.canStart) {
      this.getMainKeys();
      this.canStart = true;
    }
  }

  loadDefaultSubject() {
    this.mainSelectedKey = this.syllabusService?.activeMainSyllabus?.id;
    this.loadedDefaultPos = true;
  }

  /**
   * Get's the  specialization keys.
   */
  startspec() {
    if (!this.canStartSpec) {
      this.specSelectedKeys = [];
      this.syllabusService.selectedSpecSyllabi.forEach((x) =>
        this.specSelectedKeys.push(x.id)
      );
      this.canStartSpec = true;
    }
  }

  /**
   * Gets the keys of the main syllabi.
   */
  getMainKeys() {
    this.mainSyllabikeys = Object.keys(this.syllabusService?.allMainSyllabi);
  }

  ngOnInit(): void {}
}

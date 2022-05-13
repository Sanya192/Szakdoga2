import { Injectable } from '@angular/core';
import { Syllabus } from '../models/syllabus';
import { RestClientService } from './rest-client.service';
import { EventService } from './event.service';

@Injectable({
  providedIn: 'root',
})
export class SyllabiService {
  public activeMainSyllabus: Syllabus;
  public selectedSpecSyllabi: Syllabus[];
  public allMainSyllabi: Record<string, string>;
  public allSpecForMain: Record<string, string>;

  constructor(private rest: RestClientService, private events: EventService) {
    this.loadSettingsForSyllabi();
    this.selectedSpecSyllabi = [];
  }

  defaultSetupForSyllabi() {
    this.changeActiveMainSyllabus('NBNEUM');
    this.selectSpec('NBNEUM-NN-KIB');
  }

  saveSettingsForSyllabi() {
    localStorage.setItem('selectedMainSylabbusId', this.activeMainSyllabus?.id);
    let specName = [];
    this.selectedSpecSyllabi.forEach((x) => specName.push(x.id));
    localStorage.setItem('selectedSpec', JSON.stringify(specName));
  }

  loadSettingsForSyllabi() {
    let mainId = localStorage.getItem('selectedMainSylabbusId') ?? 'NBNEUM';
    let specName = JSON.parse(localStorage.getItem('selectedSpec')) ?? [
      'NBNEUM-NN-KIB',
    ];
    this.changeActiveMainSyllabus(mainId);
    this.selectMultibleSpec(specName);
    this.rest.getMainSyllabusNames().subscribe((x: Record<string, string>) => {
      this.allMainSyllabi = x;
      console.log(x);
      this.rest
        .getSpecSyllabusNames(mainId)
        .subscribe((x: Record<string, string>) => {
          this.allSpecForMain = x;
        });
    });
  }

  changeActiveMainSyllabus(id: string) {
    this.rest.getSyllabus(id).subscribe((x: Syllabus) => {
      this.activeMainSyllabus = x;
      console.log(x);
      this.events.triggerSubjectChanged();
      this.saveSettingsForSyllabi();
      this.rest
        .getSpecSyllabusNames(x.id)
        .subscribe((x: Record<string, string>) => {this.allSpecForMain = x;      this.events.triggerSyllabusLoad();
        });
    });
  }

  selectMultibleSpec(ids: string[]) {
    this.selectedSpecSyllabi = [];
    ids.forEach((x) => this.selectSpec(x));
  }

  selectSpec(id: string) {
    this.rest.getSyllabus(id).subscribe((x: Syllabus) => {
      this.selectedSpecSyllabi.push(x);
      this.events.triggerSubjectChanged();
      this.saveSettingsForSyllabi();
    });
  }

  deSelectSpec(id: string) {
    this.selectedSpecSyllabi = this.selectedSpecSyllabi.filter(
      (x) => x.id !== id
    );
    this.saveSettingsForSyllabi();
  }
}

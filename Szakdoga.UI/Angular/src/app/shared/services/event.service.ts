import { Injectable,EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  public subjectChanged: EventEmitter<void>;
  public syllabusLoaded: EventEmitter<void>;

  constructor() {
    this.subjectChanged=new EventEmitter();
    this.syllabusLoaded=new EventEmitter<void>();
  }
  triggerSubjectChanged(){
    this.subjectChanged.emit();
  }
  triggerSyllabusLoad(){
    this.syllabusLoaded.emit();
  }
}

import {Injectable, EventEmitter} from '@angular/core';
import {EqualPair} from "../models/equalPair";
import {EqualsTable} from "../models/equalsTable";

@Injectable({
  providedIn: 'root',
})
export class EventService {
  public subjectChanged: EventEmitter<void>;
  public syllabusLoaded: EventEmitter<void>;
  public mainSubjectChanged: EventEmitter<void>;
  public specSyllabusLoaded: EventEmitter<void>;
  public equalsTableQueryLoaded:EventEmitter<EqualsTable>;

  constructor() {
    this.subjectChanged = new EventEmitter();
    this.mainSubjectChanged = new EventEmitter();

    this.syllabusLoaded = new EventEmitter<void>();
    this.specSyllabusLoaded = new EventEmitter<void>();
    this.equalsTableQueryLoaded = new EventEmitter<EqualsTable>();
  }

  triggerSubjectChanged() {
    this.subjectChanged.emit();
  }

  triggerSyllabusLoad() {
    this.syllabusLoaded.emit();
  }

  triggerSpecSyllabusLoad() {
    this.specSyllabusLoaded.emit();
  }
  triggerEqualTableLoaded(x:EqualsTable){
    this.equalsTableQueryLoaded.emit(x);
  }
}

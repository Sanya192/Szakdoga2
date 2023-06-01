import { Subject } from './subject';

export class EqualPair {
  targetSubject: Subject;
  requiredSubject: Subject;

  constructor(prop:any) {
    this.targetSubject = prop.targetSubject;
    this.requiredSubject = prop.requiredSubject;
  }
}

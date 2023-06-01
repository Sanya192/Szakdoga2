import {EqualPair} from "./equalPair";

export class EqualsTable {
  sourceSyllabusId: string;
  targetSyllabusId: string;
  sourceSyllabusName:string;
  targetSyllabusName:string;

  equalPairDtos:EqualPair[];

  constructor(prop:any) {
    this.sourceSyllabusId = prop.sourceSyllabusId;
    this.targetSyllabusId = prop.targetSyllabusId;
    this.equalPairDtos = prop.equalPairDtos;
  }
}

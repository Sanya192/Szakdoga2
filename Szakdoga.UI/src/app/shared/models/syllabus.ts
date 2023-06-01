import {Subject} from "./subject";

export  class Syllabus{
  id:string;
  name:string;
  length:number;
  mustChoseCredit:number;
  chosableCredit:number;
  startingSpecSemester:number;
  parent:string;
  subjects:Subject[];


  constructor(prop:any) {
    this.id = prop.id;
    this.name = prop.name;
    this.length = +prop.length;
    this.mustChoseCredit = +prop.mustChoseCredit;
    this.chosableCredit = +prop.chosableCredit;
    this.startingSpecSemester = +prop.startingSpecSemester;
    this.parent = prop.parent;
    this.subjects = prop.subjects;
  }
}

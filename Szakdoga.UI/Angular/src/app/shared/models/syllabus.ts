import {Subject} from "./subject";

export  class Syllabus{
  Id:string;
  Name:string;
  Length:number;
  MustChoseCredit:number;
  ChosableCredit:number;
  StartingSpec:string;
  Parent:string;
  Subjects:Subject[];


  constructor(prop:any) {
    this.Id = prop.Id;
    this.Name = prop.Name;
    this.Length = +prop.Length;
    this.MustChoseCredit = +prop.MustChoseCredit;
    this.ChosableCredit = +prop.ChosableCredit;
    this.StartingSpec = prop.StartingSpec;
    this.Parent = prop.Parent;
    this.Subjects = prop.Subjects;
  }
}

export class Subject {
  id: string;
  name: string;
  kredit: number;
  recommendedSemester: number;
  syllabusId: string;
  parents: Record<string, string>;
  language: string;
  subjectType:string;
  finished: boolean;

  constructor(prop: any) {
    this.id = prop.id;
    this.name = prop.name;
    this.kredit = +prop.kredit;
    this.recommendedSemester = +prop.recommendedSemester;
    this.syllabusId = prop.syllabusId;
    this.parents = prop.parents;
    this.language= prop.language;
    this.subjectType=prop.subjectType;
    this.finished = prop.finished || false;
  }
  static SampleSubject(): Subject {
    let sampleObject = `{
    "id": "HFT",
    "name": "Haladó fejlesztési technikák",
    "kredit": "4",
    "recommendedSemester": "3",
    "syllabusId": "NBNEUM",
    "parents": {
      "NIXSF2PBNE": "Szoftvertervezés és -fejlesztés II."
    },
    "finished": false,
    "language": "Hungarian",
    "subjectType": "Mandatory",
    "finished":true
    }`;
    console.log(JSON.parse(sampleObject));
    return new Subject(JSON.parse(sampleObject));

  }
}

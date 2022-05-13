import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class RestClientService {
  url: string;

  constructor(private http: HttpClient) {
    this.url = environment.serverUrl;
  }

  getSubjects() {}

  getSyllabus(id: string) {
    return this.http.get(this.url + '/Syllabus/' + id);
  }

  getSpecSyllabusNames(mainId: string) {
    return this.http.get(this.url + '/Syllabus/AllSpecName/' + mainId);
  }

  getMainSyllabusNames() {
    return this.http.get(this.url + '/Syllabus/AllMainName');
  }

  setFinishSubject(id: string) {
    return this.http.get(this.url + '/Student/SetFinishForUser/' + id);
  }

  deSetFinishSubject(id: string) {
    return this.http.get(this.url + '/Student/deSetFinishForUser/' + id);
  }

  getEqualsTable(sourceId: string, targetId: string) {
    return this.http.get(this.url + '/Subject/EqualTable/'+targetId+'/'+sourceId);
  }
}

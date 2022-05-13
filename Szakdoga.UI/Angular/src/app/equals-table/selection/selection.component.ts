import { Component, OnInit } from '@angular/core';
import { RestClientService } from '../../shared/services/rest-client.service';
import {EventService} from "../../shared/services/event.service";
import {EqualsTable} from "../../shared/models/equalsTable";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'equals-selection',
  templateUrl: './selection.component.html',
  styleUrls: ['./selection.component.css'],
})
export class SelectionComponent implements OnInit {
  sourceSyllabusId: string;
  targetSyllabusId: string;
  syllabusIds: Record<string, string>;
  loaded: boolean;

  constructor(private rest: RestClientService,private event:EventService,private _snackBar:MatSnackBar) {
    rest.getMainSyllabusNames().subscribe((x: Record<string, string>) => {
      this.syllabusIds = x;
      this.loaded = true;
    });
  }

  getSyllabusIds() {
    return Object.keys(this.syllabusIds);
  }

  getSyllabusValues() {
    return Object.values(this.syllabusIds);
  }
  fetchTable(){
    if(this.sourceSyllabusId==this.targetSyllabusId)
      this.openSnackBar();
    else
      this.rest.getEqualsTable(this.sourceSyllabusId,this.targetSyllabusId).subscribe((x:EqualsTable)=>this.event.triggerEqualTableLoaded(x));

  }
  openSnackBar() {
    this._snackBar.open("Nem lehet ugyanaz a két tanterv","bezár",{duration:2000,panelClass:"snack"});
  }

  ngOnInit(): void {}
}

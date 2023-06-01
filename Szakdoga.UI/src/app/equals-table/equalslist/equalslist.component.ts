import { Component, Input, OnInit } from '@angular/core';
import { EqualsTable } from '../../shared/models/equalsTable';
import { RestClientService } from '../../shared/services/rest-client.service';
import {EventService} from "../../shared/services/event.service";

class EqualTableElement {
  firstNameAndCode: string;
  position: number;
  firstCredit: number;
  secondNameAndCode: string;
  secondCredit: number;
}

@Component({
  selector: 'equals-equalslist',
  templateUrl: './equalslist.component.html',
  styleUrls: ['./equalslist.component.css'],
})
export class EqualslistComponent implements OnInit {
  @Input()
  equalList: EqualsTable;
  elementData: EqualTableElement[];
  displayedColumns: string[] = [
    'position',
    'firstNameAndCode',
    'firstCredit',
    'secondNameAndCode',
    'secondCredit',
  ];

  constructor(private event:EventService) {
    this.elementData=[];
    event.equalsTableQueryLoaded.subscribe(x=>{this.equalList=x;this.reDraw()});
  }

  ngOnInit(): void {


  }
  reDraw(){
    this.equalList.equalPairDtos.forEach((x, index) => {
      let element = new EqualTableElement();
      element.position = index;
      element.firstNameAndCode = `${x.requiredSubject.id} ${x.requiredSubject.name} `;
      element.firstCredit = x.requiredSubject.kredit;
      element.secondNameAndCode = `${x.targetSubject.id} ${x.targetSubject.name} `;
      element.secondCredit = x.targetSubject.kredit;
      this.elementData.push(element);
    });
  }
}

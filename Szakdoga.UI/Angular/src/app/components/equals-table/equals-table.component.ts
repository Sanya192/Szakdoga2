import { Component, OnInit } from '@angular/core';
import { RestClientService } from '../../shared/services/rest-client.service';
import { EqualsTable } from '../../shared/models/equalsTable';
import { EventService } from '../../shared/services/event.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-equals-table',
  templateUrl: './equals-table.component.html',
  styleUrls: ['./equals-table.component.css'],
})
export class EqualsTableComponent implements OnInit {
  constructor(private events: EventService, private _snackBar: MatSnackBar) {}

  public equalList: EqualsTable;

  ngOnInit(): void {}
}

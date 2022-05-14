import { Component, OnInit } from '@angular/core';
import { EqualsTable } from '../../shared/models/equalsTable';
import { EventService } from '../../shared/services/event.service';
import { MatSnackBar } from '@angular/material/snack-bar';

/**
 * A component for displaying Equal Subjects
 */
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

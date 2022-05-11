import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubjectComponent } from './subject/subject.component';
import { MatCardModule } from '@angular/material/card';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule} from "@angular/material/button";
import { TreeComponent } from './tree/tree.component';

@NgModule({
  declarations: [SubjectComponent, TreeComponent],
  imports: [
    CommonModule,
    MatCardModule,
    MatProgressBarModule,
    MatDividerModule,
    MatListModule,
    MatButtonModule
  ],
  exports: [SubjectComponent],
})
export class SubjectTreeModule {}

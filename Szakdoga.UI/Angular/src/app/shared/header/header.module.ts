import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeadComponent } from './head/head.component';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [HeadComponent],
  exports: [HeadComponent],
  imports: [CommonModule, MatSelectModule, FormsModule],
})
export class HeaderModule {}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TreeHeadComponent } from './tree-head/tree-head.component';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule } from '@angular/forms';
import { GlobalHeadComponent } from './global-head/global-head.component';
import {MatButtonModule} from "@angular/material/button";

@NgModule({
  declarations: [TreeHeadComponent, GlobalHeadComponent],
  exports: [TreeHeadComponent, GlobalHeadComponent],
  imports: [CommonModule, MatSelectModule, FormsModule,MatButtonModule],
})
export class HeaderModule {}

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { SubjectTreeModule } from './subject-tree/subject-tree.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { HeaderModule } from './shared/header/header.module';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { SubjectTreeAppComponent } from './components/subject-tree-app/subject-tree-app.component';
import { RouterModule, Routes } from '@angular/router';
import { EqualsTableComponent } from './components/equals-table/equals-table.component';
import { EqualsTableModule } from './equals-table/equals-table.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { SwaggerUIComponent } from './components/swagger-ui/swagger-ui.component';

const routes: Routes = [
  { path: 'targyiHalo', component: SubjectTreeAppComponent },
  { path: 'ekvivalenciaTabla', component: EqualsTableComponent },
  { path: 'swagger', component: SwaggerUIComponent },
  { path: '**', redirectTo: '/targyiHalo' },
];

@NgModule({
  declarations: [
    AppComponent,
    SubjectTreeAppComponent,
    EqualsTableComponent,
    SwaggerUIComponent,
  ],
  imports: [
    BrowserModule,
    SubjectTreeModule,
    BrowserAnimationsModule,
    HttpClientModule,
    HeaderModule,
    MatProgressSpinnerModule,
    RouterModule.forRoot(routes),
    EqualsTableModule,
    MatFormFieldModule,
    MatSnackBarModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

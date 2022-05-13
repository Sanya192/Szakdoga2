import { Component, OnChanges, OnInit } from '@angular/core';
import SwaggerUI from 'swagger-ui';

@Component({
  selector: 'app-swagger-ui',
  templateUrl: './swagger-ui.component.html',
  styleUrls: ['./swagger-ui.component.css'],
})
export class SwaggerUIComponent implements OnInit {
  constructor() {}

  // example-swagger-exp.component.ts
  OnChanges() {}

  ngOnInit(): void {
    SwaggerUI({
      domNode: document.getElementById('swagger-ui-item'),
      url: 'https://localhost:5005/swagger/v1/swagger.json',
    });
  }
}

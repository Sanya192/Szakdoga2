import { Component, OnInit } from '@angular/core';

/**
 * Component used for having the same header on All AppComponents.
 */
@Component({
  selector: 'header-global-head',
  templateUrl: './global-head.component.html',
  styleUrls: ['./global-head.component.css'],
})
export class GlobalHeadComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
}

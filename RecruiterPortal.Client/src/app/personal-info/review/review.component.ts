import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {

  public hasEducation: boolean = true;
  public hasEmployment: boolean = true;

  constructor() { }

  ngOnInit() {
  }

}

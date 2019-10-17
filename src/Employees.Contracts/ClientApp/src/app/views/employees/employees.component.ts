import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {
  filter = '';
  constructor() { }

  ngOnInit() {
  }

  onFilter() {
    console.log(this.filter);

  }

}

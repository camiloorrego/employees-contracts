import { EmployeeModel } from './../../models/employee.model';
import { Component, OnInit } from '@angular/core';
import { EmployeesService } from './employees.service';
import { FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {

  filter = new FormControl('', [Validators.pattern(/^[0-9]*$/)]);
  items: EmployeeModel[] = [];
  hasItem = true;
  constructor(public service: EmployeesService) { }

  ngOnInit() {
    this.loadEmployees(this.service.getEmployees());
  }

  keyPress(event: any) {
    // If enter is pressed
    if (this.filter.valid && event.charCode === 13) {
      this.onFilter();
    }
  }

  onFilter() {
    this.items = [];
    const method = this.filter.value ? this.service.getEmployeeById(this.filter.value) : this.service.getEmployees();
    this.loadEmployees(method);
  }

  loadEmployees(method: Observable<EmployeeModel>) {
    method.subscribe((response: any) => {
      this.items = Array.isArray(response) ? response : [response];
      this.hasItem = this.items.length > 0;
    }, (e: any) => {
      if (e.status === 404) {
        this.hasItem = false;
      }

    });
  }

}

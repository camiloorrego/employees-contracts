import { Injectable, Inject } from '@angular/core';
import { map, finalize, catchError, timeout } from 'rxjs/operators';
import { forkJoin, of, from } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { EmployeeModel } from 'src/app/models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  private Url: any;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.Url = baseUrl;


  }
  public isBusy = false;

  getEmployees() {
    this.isBusy = true;

    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };

    return this.http.get<EmployeeModel>(`${this.Url}api/Employees`, options)
      .pipe(
        finalize(() => {
          this.isBusy = false;
        })
      );
  }

  getEmployeeById(id: number) {
    this.isBusy = true;

    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };

    return this.http.get<EmployeeModel>(`${this.Url}api/Employees/${id}`, options)
      .pipe(
        finalize(() => {
          this.isBusy = false;
        })
      );
  }

}

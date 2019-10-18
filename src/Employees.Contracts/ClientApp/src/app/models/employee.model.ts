export interface EmployeeModel {
  id: number;
  name: string;
  contractTypeName: string;
  roleId: number;
  roleName: string;
  roleDescription?: any;
  hourlySalary: number;
  monthlySalary: number;
  total: number;
}

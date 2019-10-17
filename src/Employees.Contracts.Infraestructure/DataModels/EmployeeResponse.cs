using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Contracts.Infraestructure.DataModels
{
   internal class EmployeeResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("contractTypeName")]
        public string ContractTypeName { get; set; }
        [JsonProperty("roleId")]
        public int RoleId { get; set; }
        [JsonProperty("roleName")]
        public string RoleName { get; set; }
        [JsonProperty("roleDescription")]
        public string RoleDescription { get; set; }
        [JsonProperty("hourlySalary")]
        public double HourlySalary { get; set; }
        [JsonProperty("monthlySalary")]
        public double MonthlySalary { get; set; }
    }
}

using Employees.Contracts.Domain.Entities;
using Employees.Contracts.Domain.Enums;
using Employees.Contracts.Domain.Factories;
using Employees.Contracts.Domain.Interfaces;
using Employees.Contracts.Domain.Settings;
using Employees.Contracts.Infraestructure.DataModels;
using Employees.Contracts.Infraestructure.Mappers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Employees.Contracts.Infraestructure.Repositories
{
    public class MasGlobalRepository : IEmployeeRepository
    {
        private readonly IOptions<Settings> _settings;
        private readonly HttpClient _client;

        public MasGlobalRepository(HttpClient client, IOptions<Settings> settings)
        {
            _client = client;
            _settings = settings;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var httpResponse = await _client.GetAsync(_settings.Value.ExternalSettings.Url);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Infraestructure Exception: GetEmployeesAsync");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();

            var tasks = JsonConvert.DeserializeObject<List<EmployeeResponse>>(content);
            
            return tasks.Map();
        }

    }
}

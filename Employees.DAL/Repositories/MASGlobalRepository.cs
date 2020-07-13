using Employees.BLL.Interfaces;
using Employees.BLL.Models;
using Employees.BLL.Settings;
using Employees.DAL.DataModels;
using Employees.DAL.Mappers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DAL.Repositories
{
    public class MASGlobalRepository : IMasGlobalRepository
    {
        private readonly HttpClient _http;
        private readonly IOptions<Settings> _settings;

        public MASGlobalRepository(HttpClient http, IOptions<Settings> settings)
        {
            _http = http;
            _settings = settings;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var response = await _http.GetAsync(_settings.Value.AppSettings.Url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Connection Exception: GetEmployeesAsync");
            }
            var dataContent = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<EmployeeData>>(dataContent);

            return data.Map();
        }
    }
}

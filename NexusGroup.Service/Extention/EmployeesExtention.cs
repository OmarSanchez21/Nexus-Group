using NexusGroup.Data.Models;
using NexusGroup.Service.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Extention
{
    public static class EmployeesExtention
    {
        public static EmployeesModels GetEmployeesEntity(this AddEmployees models)
        {
            EmployeesModels emp = new EmployeesModels()
            {
                name = models.name,
                lastName = models.lastName,
                photo = models.photo,
                email = models.email,
                passwordHash = models.passwordHash,
                joinDate = models.joinDate.ToDateTime(TimeOnly.MinValue),
                positionID = models.positionID,
                accessLevelID = models.accessLevelID,
            };
            return emp;

        }
    }
}

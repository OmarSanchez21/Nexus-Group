using NexusGroup.Data.Models;
using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Mappers
{
    public static class EmployeeMappers
    {
        public static M_Employees toModelAdd(AddEmployeeDTO dto)
        {
            string hashed = BcryptFunc.HashPassword(dto.Password);
            M_Employees model = new M_Employees()
            {
                Cedula = dto.Cedula,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Username = dto.Username,
                Password = hashed,
                photoURL = dto.photoURL,
                Salary = dto.Salary,
                PositionID = dto.PositionID,
                AccessLevelsID = dto.AccessLevelsID
            };
            return model;
        }
        public static M_Employees toModelEdit(EditEmployeeDTO dto)
        {
            string hashed = BcryptFunc.HashPassword(dto.Password);
            M_Employees model = new M_Employees()
            {
                EmployeeID = dto.EmployeeID,
                Cedula = dto.Cedula,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Username = dto.Username,
                Password = hashed,
                photoURL = dto.photoURL,
                Salary = dto.Salary,
                PositionID = dto.PositionID,
                AccessLevelsID = dto.AccessLevelsID
            };
            return model;
        }
    }
    
}

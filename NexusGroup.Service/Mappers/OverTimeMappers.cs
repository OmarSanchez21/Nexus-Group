using NexusGroup.Data.Models;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Mappers
{
    public static class OverTimeMappers
    {
        public static IEnumerable<OverTimeDTO> ToDTO(IEnumerable<M_Overtime> model)
        {
            IEnumerable<OverTimeDTO> dto = model.Select(m => new OverTimeDTO()
            {
                OverTimeID = m.OverTimeID,
                EmployeeID = m.EmployeeID,
                WorkDate = DateOnly.FromDateTime(m.WorkDate),
                PayrollPeriod = m.PayrollPeriod,
                TotalPayment = m.TotalPayment,
                ExtraHours = m.ExtraHours,
                HourlyRate = m.HourlyRate,
                CreateAt = m.CreateAt
            });
            return dto;
        }
        public static M_Overtime toModelAdd(AddOverTimeDTO dto)
        {
            M_Overtime model = new M_Overtime()
            {
                EmployeeID = dto.EmployeeID,
                WorkDate = dto.WorkDate.ToDateTime(TimeOnly.MinValue),
                PayrollPeriod = dto.PayrollPeriod,
                ExtraHours = dto.ExtraHours,
                HourlyRate = dto.HourlyRate,
            };
            return model;
        }
        public static M_Overtime toModelEdot(EditOverTimeDTO dto)
        {
            M_Overtime model = new M_Overtime()
            {
                OverTimeID = dto.OverTimeID,
                EmployeeID = dto.EmployeeID,
                WorkDate = dto.WorkDate.ToDateTime(TimeOnly.MinValue),
                PayrollPeriod = dto.PayrollPeriod,
                ExtraHours = dto.ExtraHours,
                HourlyRate = dto.HourlyRate,
            };
            return model;
        }
    }
}

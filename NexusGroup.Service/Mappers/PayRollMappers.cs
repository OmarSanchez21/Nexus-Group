using NexusGroup.Data.Models;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Mappers
{
    public static class PayRollMappers
    {
        public static IEnumerable<PayRollDTO> toDTO(IEnumerable<M_PayRoll> model)
        {
            IEnumerable<PayRollDTO> dto = model.Select(m => new PayRollDTO()
            {
                PayrollID = m.PayrollID,
                PayDate = DateOnly.FromDateTime(m.PayDate),
                EmployeeID = m.EmployeeID,
                BaseSalary = m.BaseSalary,
                OvertimePay = m.OvertimePay,
                Deduction = m.Deduction,
                SalaryNet = m.SalaryNet,
                CreateAt = m.CreateAt,
            });
            return dto;
        }
        public static M_PayRoll ToModelAdd(AddPayRollDTO dto)
        {
            M_PayRoll model = new M_PayRoll()
            {
                EmployeeID = dto.EmployeeID,
                BaseSalary = dto.BaseSalary,
                PayDate = dto.PayDate.ToDateTime(TimeOnly.MinValue),
                OvertimePay = dto.OvertimePay,
                Deduction = dto.Deduction
            };
            return model;
        }
        public static M_PayRoll ToModelEdit(EditPayRollDTO dto)
        {
            M_PayRoll model = new M_PayRoll()
            {
                PayrollID = dto.PayrollID,
                EmployeeID = dto.EmployeeID,
                BaseSalary = dto.BaseSalary,
                PayDate = dto.PayDate.ToDateTime(TimeOnly.MinValue),
                OvertimePay = dto.OvertimePay,
                Deduction = dto.Deduction
            };
            return model;
        }
    }
}

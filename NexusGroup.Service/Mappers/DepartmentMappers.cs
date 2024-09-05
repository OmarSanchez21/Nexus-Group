using NexusGroup.Data.Models;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Mappers
{
    public static class DepartmentMappers
    {
        public static IEnumerable<DepartmentDTO> toDTO(IEnumerable<M_Department> model)
        {
            IEnumerable<DepartmentDTO> dto = model.Select(model => new DepartmentDTO()
            {
                DepartmentID = model.DepartmentID,
                Name = model.Name,
                ManagerID = model.ManagerID,
                CreateAt = model.CreateAt,
            });
            return dto;
        }
        public static M_Department ToModelAdd(AddDepartmentDTO dto)
        {
            M_Department model = new M_Department()
            {
                Name = dto.Name,
                ManagerID = dto.ManagerID
            };
            return model;
        }
        public static M_Department ToModelEdit(EditDepartmentDTO dto)
        {
            M_Department model = new M_Department()
            {
                DepartmentID = dto.DepartmentID,
                Name = dto.Name,
                ManagerID = dto.ManagerID
            };
            return model;
        }
    }
}

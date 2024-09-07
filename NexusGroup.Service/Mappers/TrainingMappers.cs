using NexusGroup.Data.Models;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Mappers
{
    public static class TrainingMappers
    {
        public static IEnumerable<TrainingDTO> toDto(IEnumerable<M_Training> model)
        {
            IEnumerable<TrainingDTO> dto = model.Select(m => new TrainingDTO()
            {
                TrainingID = m.TrainingID,
                EmployeeID = m.EmployeeID,
                TrainingDate = DateOnly.FromDateTime(m.TrainingDate),
                TrainingDescription = m.TrainingDescription,
                CreateAt = m.CreateAt
            });
            return dto;
        }
        public static M_Training toModelAdd(AddTrainingDTO dto)
        {
            M_Training model = new M_Training()
            {
                EmployeeID = dto.EmployeeID,
                TrainingDate = dto.TrainingDate.ToDateTime(TimeOnly.MinValue),
                TrainingDescription = dto.TrainingDescription,
            };
            return model;
        }
        public static M_Training toModelEdit(EditTrainingDTO dto)
        {
            M_Training model = new M_Training()
            {
                TrainingID = dto.TrainingID,
                EmployeeID = dto.EmployeeID,
                TrainingDate = dto.TrainingDate.ToDateTime(TimeOnly.MinValue),
                TrainingDescription = dto.TrainingDescription,
            };
            return model;
        }
    }
}

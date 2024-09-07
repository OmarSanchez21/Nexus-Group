using NexusGroup.Data.Models;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Mappers
{
    public static class PerformanceReviewMappers
    {
        public static IEnumerable<PerformanceReviewDTO> toDTO(IEnumerable<M_PerformanceReview> model)
        {
            IEnumerable<PerformanceReviewDTO> dto = model.Select(m => new PerformanceReviewDTO
            {
                ReviewID = m.ReviewID,
                EmployeeID = m.EmployeeID,
                ReviewDate = DateOnly.FromDateTime(m.ReviewDate),
                ReviewDescription = m.ReviewDescription,
                Reviewer = m.Reviewer,
                Score = m.Score,
                Observation = m.Observation,
                CreateAt = m.CreateAt
            });
            return dto;
        }
        public static M_PerformanceReview toModelAdd(AddPerformanceReviewDTO dto) 
        {
            M_PerformanceReview m_PerformanceReview = new M_PerformanceReview()
            { 
                EmployeeID = dto.EmployeeID,
                ReviewDate = dto.ReviewDate.ToDateTime(TimeOnly.MinValue),
                Reviewer = dto.Reviewer,
                ReviewDescription = dto.ReviewDescription,
                Score = dto.Score,
                Observation = dto.Observation
            };
            return m_PerformanceReview;
        }
        public static M_PerformanceReview toModelEdit(EditPerformanceReviewDTO dto)
        {
            M_PerformanceReview m_PerformanceReview = new M_PerformanceReview()
            {
                ReviewID = dto.ReviewID,
                EmployeeID = dto.EmployeeID,
                ReviewDate = dto.ReviewDate.ToDateTime(TimeOnly.MinValue),
                Reviewer = dto.Reviewer,
                ReviewDescription = dto.ReviewDescription,
                Score = dto.Score,
                Observation = dto.Observation
            };
            return m_PerformanceReview;
        }
    }
}

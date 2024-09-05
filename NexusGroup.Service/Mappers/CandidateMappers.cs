using NexusGroup.Data.Models;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Mappers
{
    public static class CandidateMappers
    {
        public static IEnumerable<CandidateDTO> toDto(IEnumerable<M_Candidates> model)
        {

            IEnumerable<CandidateDTO> dto = model.Select(model => new CandidateDTO()
            {
                CandidateID = model.CandidateID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                cvURL = model.cvURL,
                ApplicationDate = DateOnly.FromDateTime(model.ApplicationDate),
                IdJobOffer = model.IdJobOffer,
                CreateAt = model.CreateAt
            });
            return dto;
        }
        public static M_Candidates toModelAdd(this AddCandidateDTO dto)
        {
            M_Candidates model = new M_Candidates()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                cvURL = dto.cvURL,
                ApplicationDate = dto.ApplicationDate.ToDateTime(TimeOnly.MaxValue),
                IdJobOffer = dto.IdJobOffer
            };
            return model;
        }
        public static M_Candidates toModelEdit(this EditCandidateDTO dto)
        {
            M_Candidates model = new M_Candidates()
            {
                CandidateID = dto.CandidateID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                cvURL = dto.cvURL,
                ApplicationDate = dto.ApplicationDate.ToDateTime(TimeOnly.MaxValue),
                IdJobOffer = dto.IdJobOffer
            };
            return model;
        }
    }
}

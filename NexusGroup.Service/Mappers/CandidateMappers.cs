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

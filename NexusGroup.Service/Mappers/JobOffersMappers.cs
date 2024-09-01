using NexusGroup.Data.Models;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Mappers
{
    public static class JobOffersMappers
    {
        public static M_JobOffers toModelAdd(this AddJobOffersDTO dto)
        {
            M_JobOffers model = new M_JobOffers()
            {
                Title = dto.Title,
                Description = dto.Description,
                StartPublication = dto.StartPublication.ToDateTime(TimeOnly.MinValue),
                EndPublication = dto.EndPublication.ToDateTime(TimeOnly.MinValue)
            };
            return model;
        }
        public static M_JobOffers toModelEdit(this EditJobOffersDTO dto)
        {
            M_JobOffers model = new M_JobOffers()
            {
                JobOfferID = dto.JobOfferID,
                Title = dto.Title,
                Description = dto.Description,
                StartPublication = dto.StartPublication.ToDateTime(TimeOnly.MinValue),
                EndPublication = dto.EndPublication.ToDateTime(TimeOnly.MinValue)
            };
            return model;
        }
    }
}

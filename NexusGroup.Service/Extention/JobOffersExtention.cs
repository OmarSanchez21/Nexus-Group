using NexusGroup.Data.Models;
using NexusGroup.Service.DTOs.JobOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Extention
{
    public static class JobOffersExtention
    {
        public static JobOffersModels GetJobOffersEntity(this AddJobOffers models)
        {
            JobOffersModels job = new JobOffersModels()
            {
                title = models.title,
                description = models.description,
                publicationDate = models.publicationDate.ToDateTime(TimeOnly.MinValue),
                clouserDate = models.clouserDate.ToDateTime(TimeOnly.MinValue)
            };
            return job;
        }
    }
}

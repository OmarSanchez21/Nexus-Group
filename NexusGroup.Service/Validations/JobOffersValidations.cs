using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Validations
{
    public static class JobOffersValidations
    {
        private static string Validations(string title, string description, DateOnly startpublication, DateOnly endpublication)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(title))
            {
                sb.AppendLine("Title cannot be empty");
            }
            if (string.IsNullOrEmpty(description)) 
            {
                sb.AppendLine("Description cannot be empty");
            }
            if(startpublication > endpublication)
            {
                sb.AppendLine("The start date cannot be later than the end date.");
            }
            if (endpublication <= DateOnly.FromDateTime(DateTime.Now))
            {
                sb.AppendLine("The end publication date must be a future date.");
            }
            return sb.ToString();
        }
        public static ServiceResult ValidationsAdd(AddJobOffersDTO dto)
        {
            string validation = Validations(dto.Title, dto.Description, dto.StartPublication, dto.EndPublication);
            return FuncCore.CreateServiceResultValidations(validation);
        }
        public static ServiceResult ValidationsEdit(EditJobOffersDTO dto)
        {
            string validation = Validations(dto.Title, dto.Description, dto.StartPublication, dto.EndPublication);
            return FuncCore.CreateServiceResultValidations(validation);
        }
    }
}

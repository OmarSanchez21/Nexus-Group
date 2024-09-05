using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Validations
{
    public static class CandidateValidation
    {
        private static string Validations(string firstname, string lastname, string email, string cvUrl, int idjoboffer)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(firstname))
            {
                sb.AppendLine("FirstName cannot be empty");
            }
            if (string.IsNullOrEmpty(lastname))
            {
                sb.AppendLine("LastName cannot be empty");
            }
            if (string.IsNullOrEmpty(email))
            {
                sb.AppendLine("Email cannot be emepty");
            }
            if (string.IsNullOrEmpty(cvUrl))
            {
                sb.AppendLine("Cv URL cannot be empty");
            }
            else if (!FuncCore.isValidEmail(email))
            {
                sb.AppendLine("Email format is not valid");
            }
            if (firstname == lastname) 
            {
                sb.AppendLine("FirstName and LastName cannot be equals");
            }
            if (idjoboffer == 0) 
            {
                sb.AppendLine("JobOffer is not selected");
            }
            return sb.ToString();
        }
        public static ServiceResult ValidationAdd(AddCandidateDTO dto)
        {
            string validation = Validations(dto.FirstName, dto.LastName, dto.Email, dto.cvURL, dto.IdJobOffer);
            return FuncCore.CreateServiceResultValidations(validation);
        }
        public static ServiceResult ValidationEdit(EditCandidateDTO dto)
        {
            string validation = Validations(dto.FirstName, dto.LastName, dto.Email, dto.cvURL, dto.IdJobOffer);
            return FuncCore.CreateServiceResultValidations(validation);
        }
    }
}

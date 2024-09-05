using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Validations
{
    public static class PositionValidations
    {
        public static string Validation(string title)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(title))
            {
                sb.AppendLine("Title cannot be empty");
            }
            if (title.Length < 0)
            {
                sb.AppendLine("The length for the title can not be higher than 100 caractheres");
            }
            return sb.ToString();
        }
        public static ServiceResult ValidationsAdd(AddPositionDTO dto)
        {
            string validation = Validation(dto.Title);
            return FuncCore.CreateServiceResultValidations(validation);
        }
        public static ServiceResult ValidationsEdit(EditPositionDTO dto)
        {
            string validation = Validation(dto.Title);
            return FuncCore.CreateServiceResultValidations(validation);
        }
    }
}

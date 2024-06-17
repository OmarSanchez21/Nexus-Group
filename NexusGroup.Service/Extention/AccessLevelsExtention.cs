using NexusGroup.Data.Models;
using NexusGroup.Service.DTOs.AccessLevels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Extention
{
    public static class AccessLevelsExtention
    {
        public static AccessLevelsModels GetAccessLevelsEntity(this AddAccessLevels addAccessLevels)
        {
            AccessLevelsModels models = new AccessLevelsModels()
            {
                name = addAccessLevels.Name
            };
            return models;
        }
    }
}

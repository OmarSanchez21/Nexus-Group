using NexusGroup.Data.Models;
using NexusGroup.Service.DTOs.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Extention
{
    public static class PositionExtention
    {
        public static PositionsModels GetPositionEntity(this AddPosition addPosition)
        {
            PositionsModels models = new PositionsModels()
            {
                name = addPosition.Name
            };
            return models;
        }
    }
}

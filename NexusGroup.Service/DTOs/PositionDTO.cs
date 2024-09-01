using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs
{
    public class PositionDTO
    {
        public int PositionID { get; set; }
        public string Title { get; set; }
        public DateTime CreateAt { get; set; }
    }
    public class AddPositionDTO
    {
        public string Title { get; set; }
    }
    public class EditPositionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}

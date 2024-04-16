using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admission.BusinessLogic
{
    public class AbiturientDirection
    {
        public Guid Id { get; set; }
        public Guid DirectionId { get; set; }
        public Direction Direction { get; set; }
        public Guid AbiturientId { get; set; }
        public Abiturient Abiturient { get; set; }
    }
}

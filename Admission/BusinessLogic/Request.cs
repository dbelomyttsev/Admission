using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admission.BusinessLogic
{
    public class Request
    {
        public Guid Id { get; set; }
        public Guid AbiturientId { get; set; }
        public Abiturient Abiturient { get; set; }  
        public State State { get; set; }
        public string Description { get; set; }
    }
    public enum State
    {
        Complete,
        InProgress

    }
}

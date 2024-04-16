using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admission.BusinessLogic
{
    public class Abiturient
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Education Education { get; set; }
        public string FullName { get; set; }
        public int Passport { get; set; }
        public int Snils { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public string FullNameParent { get; set; }
        public string EducationalInstitution { get; set; }
        public int Points { get; set; }
        public List<AbiturientDirection> Directions { get; set; } = new List<AbiturientDirection>();
        public byte[] File { get; set; }

    }


}

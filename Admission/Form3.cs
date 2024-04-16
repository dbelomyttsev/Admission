using Admission.BusinessLogic;
using Admission.BDHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationContext = Admission.BDHelper.ApplicationContext;

namespace Admission
{
    public partial class Form3 : Form
    {
        Abiturient abiturient;
        public Form3(Abiturient abiturient)
        {
            InitializeComponent();
            this.abiturient = abiturient;
        }
        Request request;
        private void Form3_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                request = db.Requests.Where(x => x.AbiturientId == abiturient.Id).FirstOrDefault();
            }
            label1.Text = request.State.ToString();
        }
    }
}

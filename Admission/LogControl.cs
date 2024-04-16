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
    public partial class LogControl : UserControl
    {
        Form2 form2;
        public LogControl(Form2 form2)
        {
            InitializeComponent();
            this.form2 = form2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.Where(x => x.Login == textBox1.Text).FirstOrDefault();
                if (user != null || user.Password == textBox2.Text)
                {
                    form2.Hide();
                    if (user.Role == Roles.Abiturient)
                    {
                        new Form3(db.Abiturients.Where(x => x.UserId == user.Id).FirstOrDefault()).Show();

                    }
                    else
                    {
                        new Form4().Show();
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            form2.RegControl.Show();
            form2.LogControl.Hide();
        }
    }
}

using Admission.BDHelper;
using Admission.BusinessLogic;
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
    public partial class RegControl : UserControl
    {
        Form2 form2;
        public RegControl(Form2 form2)
        {
            InitializeComponent();
            this.form2 = form2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User finduser = new User();
            using (ApplicationContext db = new ApplicationContext())
            {

            }
            if (textBox2.Text == textBox3.Text)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    User finduse1 = db.Users.FirstOrDefault(x => x.Login == textBox1.Text);

                    if (finduse1 != null)
                    {
                        MessageBox.Show("Логин занят");
                        return;
                    }

                    if (textBox2.Text != textBox3.Text)
                    {
                        MessageBox.Show("Пароли не совпадают");
                        return;
                    }

                    User user = new User
                    {
                        Id = Guid.NewGuid(),
                        Login = textBox1.Text,
                        Password = textBox2.Text,
                        Role = Roles.Abiturient
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Вы зарегистрированы");
                    form2.Hide();
                    new Form1(user).Show();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            form2.RegControl.Hide();
            form2.LogControl.Show();
        }
    }
}

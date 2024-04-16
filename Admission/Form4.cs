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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        List<Request> requests = new List<Request>();
        Request selectedRequest;
        private void Form4_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                requests = db.Requests.ToList();
                foreach (var item in requests)
                {
                    listBox1.Items.Add(item.Id);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string id = listBox1.SelectedItem.ToString();
            selectedRequest = requests.Where(x => x.Id.ToString() == id).FirstOrDefault();
            comboBox1.SelectedIndex = (int)selectedRequest.State;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                selectedRequest.State = (State)comboBox1.SelectedIndex;
                db.Requests.Update(selectedRequest);
                db.SaveChanges();
            };
        }
    }
}

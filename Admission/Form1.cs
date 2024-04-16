using Admission.BDHelper;
using Admission.BusinessLogic;
using System.Windows.Forms;
using ApplicationContext = Admission.BDHelper.ApplicationContext;

namespace Admission
{
    public partial class Form1 : Form
    {
        User user;
        public Form1(User user)
        {
            InitializeComponent();
            this.user = user;
            using (ApplicationContext db = new ApplicationContext())
            {
                directions = db.Directions.ToList();
            }
            foreach (Education item in Enum.GetValues(typeof(Education)))
            {
                comboBox1.Items.Add(item.ToString());
            }
            comboBox1.SelectedIndex = 0;
        }
        List<Direction> directions = new List<Direction>();
        private void button2_Click(object sender, EventArgs e)
        {
            
            using (ApplicationContext db = new ApplicationContext())
            {
                Abiturient abiturient = new Abiturient
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    Education = (Education)comboBox1.SelectedIndex,
                    FullName = textBox1.Text,
                    Passport = int.Parse(textBox2.Text),
                    Snils = int.Parse(textBox3.Text),
                    Email = textBox4.Text,
                    NumberPhone = textBox5.Text,
                    FullNameParent = textBox6.Text,
                    EducationalInstitution = textBox7.Text,
                    Points = int.Parse(textBox8.Text),
                    File = new byte[8]
                };

                List<Direction> selecteddirections = new List<Direction>();
                foreach (var item in directions)
                {
                    foreach (var item1 in checkedListBox1.SelectedItems)
                    {
                        if (item1.ToString() == item.Name)
                        {
                            selecteddirections.Add(item);
                        }
                    }
                }

                foreach (var item in selecteddirections)
                {
                    abiturient.Directions.Add(new AbiturientDirection { Id = Guid.NewGuid(), Direction = item, DirectionId = item.Id,  });
                }

                foreach (var item in directions)
                {
                    db.Directions.Attach(item);
                }
                

                db.Abiturients.Add(abiturient);
                db.Requests.Add(new Request { Id = Guid.NewGuid(), Abiturient = abiturient, AbiturientId = abiturient.Id, State = State.InProgress, Description = ""});
                db.SaveChanges();
                this.Hide();
                new Form3(abiturient).Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            checkedListBox1.Items.AddRange(directions
                        .Where(x => x.Education == (Education)comboBox1.SelectedIndex)
                        .Select(x => x.Name)
                        .ToArray());
        }
    }
}
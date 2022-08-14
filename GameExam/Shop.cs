using System.Windows.Forms;
using System.IO;

namespace GameExam
{
    public partial class Shop : Form
    {
        public Shop()
        {
            InitializeComponent();
        }
        public Shop(Hub hub, Team team)
        {
            InitializeComponent();

            team_ = team;
            bag_ = new Bag();
            eat_ = new Eat("", 0);
            equipment_ = new Equipment("", 0, "");
            comboBox1.Items.Clear();

            for (int i = 0; i < team.count_; i++)
            {
                comboBox1.Items.Add(team.GetPlayer(i).GetName());
            }

            dataGridView1.Columns.Add("column1", "Name");
            dataGridView1.Columns.Add("column2", "Weight");

            dataGridView2.Columns.Add("column1", "Name");
            dataGridView2.Columns.Add("column2", "Weight");

            string[] thing = new string[3];
            string[] things = File.ReadAllLines("shop.txt");

            foreach (var str in things)
            {
                thing = str.Split(" ");

                if (thing[0] == "eat")
                {
                    eat_.name_ = thing[0];
                    eat_.weight_ = int.Parse(thing[1]);
                    dataGridView1.Rows.Add(thing[0], int.Parse(thing[1]));

                    bag_.setEat(eat_);
                }
                else
                {
                    equipment_ = new Equipment("", 0, "");
                    equipment_.name_ = thing[0];
                    equipment_.weight_ = int.Parse(thing[1]);
                    equipment_.characteristic_ = thing[2];
                    dataGridView1.Rows.Add(thing[0], int.Parse(thing[1]));

                    bag_.setEquipment(equipment_);
                }
            }
        }

        public Team GetTeam()
        {
            return team_;
        }

        private Team team_;
        private Eat eat_;
        private Equipment equipment_;
        private Bag bag_;

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (progressBar1.Value != progressBar1.Maximum)
                {
                    dataGridView2.Rows.Add(dataGridView1.SelectedCells[0].Value, dataGridView1.SelectedCells[1].Value);

                    if (dataGridView1.SelectedCells[0].Value.Equals("eat"))
                    {
                        eat_ = new Eat("eat", 2);
                        team_.GetPlayer(comboBox1.SelectedIndex).GetBag().setEat(eat_);
                    }
                    else
                    {
                        equipment_ = bag_.getEquipment(dataGridView1.SelectedCells[0].RowIndex - 1);
                        team_.GetPlayer(comboBox1.SelectedIndex).GetBag().setEquipment(equipment_);
                        team_.GetPlayer(comboBox1.SelectedIndex).SetWeight(team_.GetPlayer(comboBox1.SelectedIndex).GetCurrentWeight()
                            + equipment_.weight_);
                    }

                    progressBar1.Maximum = team_.GetPlayer(comboBox1.SelectedIndex).GetMaxWeight();
                    progressBar1.Value = team_.GetPlayer(comboBox1.SelectedIndex).GetCurrentWeight();

                }
                else MessageBox.Show("The bag is full");
            }
            catch
            {
                MessageBox.Show("Обратите внимание, у вас либо не выбрана вся строка, либо не выбран персонаж.");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

                dataGridView2.Rows.Clear();
                progressBar1.Maximum = team_.GetPlayer(comboBox1.SelectedIndex).GetMaxWeight();
                progressBar1.Value = team_.GetPlayer(comboBox1.SelectedIndex).GetCurrentWeight();

                for (int b = 0; b < team_.GetPlayer(comboBox1.SelectedIndex).GetBag().getCountEat(); b++)
                {
                    dataGridView2.Rows.Add(team_.GetPlayer(comboBox1.SelectedIndex).GetBag().getEat(b).name_,
                        team_.GetPlayer(comboBox1.SelectedIndex).GetBag().getEat(b).weight_);
                }
                for (int b = 0; b < team_.GetPlayer(comboBox1.SelectedIndex).GetBag().getCountEquipment(); b++)
                {
                    dataGridView2.Rows.Add(team_.GetPlayer(comboBox1.SelectedIndex).GetBag().getEquipment(b).name_,
                        team_.GetPlayer(comboBox1.SelectedIndex).GetBag().getEquipment(b).weight_);
                }

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells[0].Value.Equals("eat"))
                {
                    team_.GetPlayer(comboBox1.SelectedIndex).GetBag().removeEat(0);
                }
                else
                {
                    team_.GetPlayer(comboBox1.SelectedIndex).SetWeight(team_.GetPlayer(comboBox1.SelectedIndex).GetCurrentWeight()
                        - team_.GetPlayer(comboBox1.SelectedIndex).GetBag().getEquipment(dataGridView2.SelectedCells[0].RowIndex).weight_);
                    team_.GetPlayer(comboBox1.SelectedIndex).GetBag().removeEquipment(dataGridView2.SelectedCells[0].RowIndex);
                }

                progressBar1.Maximum = team_.GetPlayer(comboBox1.SelectedIndex).GetMaxWeight();
                progressBar1.Value = team_.GetPlayer(comboBox1.SelectedIndex).GetCurrentWeight();
            }
            catch
            {
                MessageBox.Show("Обновите сумку персонажа, заного выбрав персонажа.");
            }
        }
    }
}

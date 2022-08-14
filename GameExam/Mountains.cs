using System.Windows.Forms;
using System;

namespace GameExam
{
    public partial class Mountains : Form
    {
        public Mountains()
        {
            InitializeComponent();
        }
        public Mountains(Hub hub, Team team)
        {
            InitializeComponent();

            team_ = team;
            rand_ = new Random();

            Weather(rand_.Next(1, 4));
            DayTime(rand_.Next(1, 4));

            dataGridView1.Columns.Add("column1", "task");
            dataGridView1.Columns.Add("column2", "place");

            if (team_.task_[0] == '1')
            {
                dataGridView1.Rows.Add(team_.task_, "vilage");
            }
            else if (team_.task_[0] == '2')
            {
                dataGridView1.Rows.Add(team_.task_, "town");
            }

            for (int i = 0; i < team_.count_; i++)
            {
                comboBox1.Items.Add(team_.GetPlayer(i).GetName());
            }

        }

        private Team team_;
        private int temeratur_;
        private Random rand_;

        private void Weather(int choies)
        {
            if (choies == 1)
            {
                textBox1.Text = "winter";
                temeratur_ = -20;
            }
            else if (choies == 2)
            {
                textBox1.Text = "spring";
                temeratur_ = 10;
            }
            else if (choies == 3)
            {
                textBox1.Text = "summer";
                temeratur_ = 30;
            }
            else if (choies == 4)
            {
                textBox1.Text = "fall";
                temeratur_ = -10;
            }

        }
        private void DayTime(int choies)
        {
            if (choies == 1)
            {
                textBox2.Text = "night";
                temeratur_ += -10;
            }
            else if (choies == 2)
            {
                textBox2.Text = "morning";
                temeratur_ += 5;
            }
            else if (choies == 3)
            {
                textBox2.Text = "afternoon";
                temeratur_ += 10;
            }
            else if (choies == 4)
            {
                textBox2.Text += "evening";
                temeratur_ = -5;
            }
        }
        private bool CheckTemp()
        {
            for (int item = 0; item < team_.count_; item++)
            {
                for (int count = 0; count < team_.GetPlayer(item).GetBag().getCountEquipment(); count++)
                {
                    team_.GetPlayer(item).SetTemp(Convert.ToInt32(team_.GetPlayer(item).GetBag().getEquipment(count).characteristic_));
                }
                team_.GetPlayer(item).SetTemp(temeratur_);

                if ((team_.GetPlayer(item).GetCurrentTemp() <= team_.GetPlayer(item).GetMinTemp()) ||
                    (team_.GetPlayer(item).GetCurrentTemp() >= team_.GetPlayer(item).GetMaxTemp()))
                {
                    MessageBox.Show("Один из членнов команды не готов к путишествию.");
                    return false;
                }
            }
            return true;
        }
        private bool CheckEat()
        {
            for (int item = 0; item < team_.count_; item++)
            {
                if (team_.GetPlayer(item).GetBag().getCountEat() == 0)
                {
                    MessageBox.Show("Один из членнов команды не готов к путишествию.");
                    return false;
                }
            }
            return true;
        }
        private bool ChechPath(int patch)
        {
            if (patch != Convert.ToInt32(team_.task_[0].ToString()))
            {
                MessageBox.Show("Неверный путь");
                return false;
            }

            return true;
        }
        private void UseEat()
        {
            for (int item = 0; item < team_.count_; item++)
            {
                team_.GetPlayer(item).GetBag().removeEat(0);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            progressBar1.Maximum = team_.GetPlayer(comboBox1.SelectedIndex).GetMaxWeight();
            progressBar1.Value = team_.GetPlayer(comboBox1.SelectedIndex).GetCurrentWeight();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckTemp() == false)
            {
                this.Close();
            }
            else if (CheckEat() == false)
            {
                this.Close();
            }
            else
            {
                UseEat();

                if (ChechPath(1))
                {
                    MessageBox.Show("Вы добрались до нужного места.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Вы ошиблись.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckTemp() == false)
            {
                this.Close();
            }
            else if (CheckEat() == false)
            {
                this.Close();
            }
            else
            {
                UseEat();

                if (ChechPath(2))
                {
                    MessageBox.Show("Вы добрались до нужного места.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Вы ошиблись.");
                }
            }
        }
    }
}

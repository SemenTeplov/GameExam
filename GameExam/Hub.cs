using System.Windows.Forms;

namespace GameExam
{
    public partial class Hub : Form
    {
        public Hub()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("column1", "Things");
            dataGridView1.Columns.Add("column2", "Weight");
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Shop shop = new Shop(this, team);
            shop.ShowDialog();
            team = shop.GetTeam();

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            BoardTask bTask = new BoardTask(this, team);
            bTask.ShowDialog();
            team = bTask.GetTeam();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Tavern tavern = new Tavern(this, team);
            tavern.ShowDialog();
            team = tavern.GetTeam();
            comboBox1.Items.Clear();

            for (int i = 0; i < team.count_; i++)
            {
                comboBox1.Items.Add(team.GetPlayer(i).GetName());
            }
        }

        private Team team = new Team();

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int ind = comboBox1.SelectedIndex;

            for (int i = 0; i < team.GetPlayer(ind).GetBag().getCountEat(); i++)
            {
                dataGridView1.Rows.Add(team.GetPlayer(ind).GetBag().getEat(i).name_, team.GetPlayer(ind).GetBag().getEat(i).weight_);
            }
            for (int i = 0; i < team.GetPlayer(ind).GetBag().getCountEquipment(); i++)
            {
                dataGridView1.Rows.Add(team.GetPlayer(ind).GetBag().getEquipment(i).name_, team.GetPlayer(ind).GetBag().getEquipment(i).weight_);
            }
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            int ind = comboBox1.SelectedIndex;

            team.SubPlayer(team.GetPlayer(ind).GetName());
            comboBox1.Items.Clear();

            for (int i = 0; i < team.count_; i++)
            {
                comboBox1.Items.Add(team.GetPlayer(i).GetName());
            }
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            if (team.task_ != null)
            {
                Mountains mount = new Mountains(this, team);
                mount.ShowDialog();
            }
            else
            {
                MessageBox.Show("Не выбрана задача.");
            }
        }
    }
}

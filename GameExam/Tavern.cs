using System.Windows.Forms;
using System.IO;

namespace GameExam
{
    public partial class Tavern : Form
    {
        public Tavern()
        {
            InitializeComponent();
        }

        public Tavern(Hub hub, Team team)
        {
            InitializeComponent();
            team_ = team;
            tavern_ = new Team();

            dataGridView1.Columns.Add("column1", "Name");
            dataGridView1.Columns.Add("column2", "Endurance");
            dataGridView1.Columns.Add("column3", "Weight");

            dataGridView2.Columns.Add("column1", "Name");
            dataGridView2.Columns.Add("column2", "Endurance");
            dataGridView2.Columns.Add("column3", "Weight");

            string[] person = new string[3];
            string[] people = File.ReadAllLines("tavern.txt");

            foreach (var str in people)
            {
                person = str.Split(" ");
                player_ = new Player(person[0], int.Parse(person[1]), int.Parse(person[2]));
                tavern_.AddPlayer(player_);

                dataGridView1.Rows.Add(person[0], int.Parse(person[1]), int.Parse(person[2]));
            }

            for (int i = 0; i < team_.count_; i++)
            {
                player_ = new Player(team_.GetPlayer(i).GetName(), 
                    team_.GetPlayer(i).GetMaxEndurance(), 
                    team_.GetPlayer(i).GetMaxWeight());
                tavern_.AddPlayer(player_);

                dataGridView2.Rows.Add(player_.GetName(), player_.GetMaxEndurance(), player_.GetMaxWeight());
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                dataGridView2.Rows.Add(dataGridView1.SelectedCells[0].Value,
                dataGridView1.SelectedCells[1].Value,
                dataGridView1.SelectedCells[2].Value);

                player_ = new Player(dataGridView1.SelectedCells[0].Value.ToString(),
                    int.Parse(dataGridView1.SelectedCells[1].Value.ToString()),
                    int.Parse(dataGridView1.SelectedCells[2].Value.ToString()));
                team_.AddPlayer(player_);
            }
            catch
            {
                MessageBox.Show("Необходимо выбрать всю строку");
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            dataGridView2.Rows.RemoveAt(dataGridView2.SelectedCells[0].RowIndex);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        public Team GetTeam()
        {
            return team_;
        }

        private Team team_;
        private Team tavern_;
        Player player_;
    }
}

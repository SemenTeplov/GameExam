using System.Windows.Forms;
using System.IO;

namespace GameExam
{
    public partial class BoardTask : Form
    {
        public BoardTask()
        {
            InitializeComponent();
        }
        public BoardTask(Hub hub, Team team)
        {
            InitializeComponent();

            team_ = team;
            tasks_ = File.ReadAllLines("tasks.txt");

            dataGridView1.Columns.Add("column", "Tasks");

            foreach (var t in tasks_)
            {
                dataGridView1.Rows.Add(t);
            }
        }
        public Team GetTeam()
        {
            return team_;
        }

        private Team team_;
        private string[] tasks_;

        private void button1_Click(object sender, System.EventArgs e)
        {
            team_.task_ = dataGridView1.SelectedCells[0].Value.ToString();
        }
    }
}

namespace GameExam
{
    public class World
    {
        public World(string name, int time, int temp, string weather) 
        {
            time_ = time;
            temp_ = temp;
            weather_ = weather;
            name_ = name;
        }

        public int time_ { get; set; }
        public int temp_ { get; set; }
        public string name_ { get; set; }
        public string weather_ { get; set; }

    }
}

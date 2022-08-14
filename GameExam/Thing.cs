namespace GameExam
{
    public abstract class Thing
    {
        public Thing() { 
            name_ = "eat";
            weight_ = 2;
        }
        public Thing(string name, int weight )
        {
            name_ = name;
            weight_ = weight;
        }

        public string name_ { get; set; }
        public int weight_ { get; set; }
    }
}

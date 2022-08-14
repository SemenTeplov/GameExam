namespace GameExam
{
    public class Equipment : Thing
    {
        public Equipment(string name, int weight, string characteristic) 
        {
            name_ = name;
            weight_ = weight;
            characteristic_ = characteristic;
        }
        public string name_ { get; set; }
        public int weight_ { get; set; }
        public string characteristic_ { get; set; }
    }
}

namespace GameExam
{
    public class Player
    {
        public Player(string name, int endurance, int weight) 
        {
            bag_ = new Bag();
            name_ = name;

            maxEndurance_ = endurance;
            currentEndurance_ = maxEndurance_;

            currentTemp_ = 36;
            minTemp_ = 20;
            maxTemp_ = 42;

            MaxWeight_ = weight;
            currentWeight_ = 0;
        }

        public void SetEndurance(int endurance)
        {
            currentEndurance_ = endurance;
        }
        public void SetTemp(int temp)
        {
            currentTemp_ += temp;
        }
        public void SetWeight(int weight)
        {
            currentWeight_ = weight;
        }

        public Bag GetBag()
        {
            return bag_;
        }
        public string GetName()
        {
            return name_;
        }
        public int GetMaxEndurance()
        {
            return maxEndurance_;
        }
        public int GetCurrentEndurance()
        {
            return currentEndurance_;
        }
        public int GetCurrentTemp()
        {
            return currentTemp_;
        }
        public int GetMinTemp()
        {
            return minTemp_;
        }
        public int GetMaxTemp()
        {
            return maxTemp_;
        }
        public int GetCurrentWeight()
        {
            return currentWeight_;
        }
        public int GetMaxWeight()
        {
            return MaxWeight_;
        }

        private string name_;

        private Bag bag_;

        private int maxEndurance_;
        private int currentEndurance_;

        private int currentTemp_;
        private int minTemp_;
        private int maxTemp_;

        private int currentWeight_;
        private int MaxWeight_;
    }
}

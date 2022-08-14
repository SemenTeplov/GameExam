using System.Collections.Generic;

namespace GameExam
{
    public class Team
    {
        public Team() 
        {
            players_ = new List<Player>();
            limit_ = 0;
            count_ = 0;
        }

        public int limit_ { get; set; }
        public int count_ { get; set; }
        public string task_ { get; set; }

        public void AddPlayer(Player player)
        {
            players_.Add(player);
            ++count_;
        }
        public void SubPlayer(string name)
        {
            for (int i = 0; i < count_; i++)
            {
                if (players_[i].GetName() == name)
                {
                    players_.Remove(players_[i]);
                    --count_;
                }
            }
        }
        public Player GetPlayer(int indx)
        {
            return players_[indx];
        }

        private List<Player> players_;
    }
}

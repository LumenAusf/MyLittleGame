namespace PureMVCContent.Model
{
    public class LeaderModel
    {
        public string Name { get; set; }
        public int Score { get; set; }
        
        public LeaderModel(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}
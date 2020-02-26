using System;

namespace PureMVCContent.Model
{
    [Serializable]
    public class EnemyModel
    {
        public int Id { get; set; }
        public int Reward { get; set; }
        public int Armor { get; set; }
        public int SkinId { get; set; }

        public EnemyModel(int id, int reward, int armor, int skinId)
        {
            Id = id;
            Reward = reward;
            Armor = armor;
            SkinId = skinId;
        }
    }
}
namespace PureMVCContent.Model
{
    public class OtherDataModel
    {
        public int LivesMax { get; set; }
        public int LivesCurrent { get; set; }
        public int BulletDamage { get; set; }
        public int BulletTTL { get; set; }
        public int BulletSpeed { get; set; }
        public int BulletSpawnPeriod { get; set; }
        public int PlayerSpeed { get; set; }
        public int CurrentLevelNumber { get; set; }
        public int MaxLevelNumber { get; set; }

        public OtherDataModel(int livesMax, int livesCurrent, int bulletDamage, int bulletTTL, int bulletSpeed, int playerSpeed, int bulletSpawnPeriod, int currentNumber, int maxLevelNumber)
        {
            LivesMax = livesMax;
            LivesCurrent = livesCurrent;
            BulletDamage = bulletDamage;
            BulletTTL = bulletTTL;
            BulletSpeed = bulletSpeed;
            PlayerSpeed = playerSpeed;
            BulletSpawnPeriod = bulletSpawnPeriod;
            CurrentLevelNumber = currentNumber;
            MaxLevelNumber = maxLevelNumber;
        }
    }
}
using System.Collections.Generic;

namespace PureMVCContent.Model
{
    public class LevelEnemy
    {
        public int EnemyId { get; set; }
        public int EnemyPosX { get; set; }
        public int EnemyPosY { get; set; }
        
        public LevelEnemy(int enemyId, int enemyPosX, int enemyPosY)
        {
            EnemyId = enemyId;
            EnemyPosX = enemyPosX;
            EnemyPosY = enemyPosY;
        }
    }
    
    public class LevelModel
    {
        public int Id { get; set; }
        public LevelEnemy[] Enemies { get; set; }

        public LevelModel(int id, LevelEnemy[] enemies)
        {
            Id = id;
            Enemies = enemies;
        }
    }
}
using System;
using Misc;
using PureMVCContent.Model;
using UnityEngine;

namespace PureMVCContent.View
{
    public class EnemyItem : MonoBehaviour
    {
        public Action Destroyed = delegate {  };

        private EnemyModel enemyData;
        
        public void UpdateItem(EnemyModel model)
        {
            enemyData = model;
        }

        public EnemyModel GetModel()
        {
            return enemyData;
        }

        private void OnCollisionEnter(Collision other)
        {
            var a = other.gameObject.TryGetComponent(typeof(Bullet), out var bull);
            if(!a) return;
            enemyData.Armor -= ((Bullet) bull).Damage;
            if(enemyData.Armor > 0) return;
            Debug.Log($"Reward: {enemyData.Reward}");
            Destroyed.Invoke();
        }
    }
}
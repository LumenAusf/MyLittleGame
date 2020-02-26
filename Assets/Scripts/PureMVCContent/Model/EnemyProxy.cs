using System.Collections.Generic;
using System.Linq;
using PureMVC.Patterns;
using UnityEngine;

namespace PureMVCContent.Model
{
    public class EnemyProxy : Proxy
    {
        public List<EnemyModel> EnemiesLists = new List<EnemyModel>();

        public new static string NAME = "Enemy";
        
        public EnemyProxy(string proxyName)
            : base(proxyName)
        {
            Debug.Log("EnemyProxy create");
        }

        public void AddEnemy(EnemyModel enemy)
        {
            EnemiesLists.Add(enemy);
        }

        public void Clear()
        {
            EnemiesLists.Clear();
        }

        public EnemyModel GetEnemy(int id)
        {
            return EnemiesLists.FirstOrDefault(x => x.Id == id);
        }
        
        public override void OnRegister()
        {
            base.OnRegister();
            Debug.Log("EnemyProxy OnRegister");
        }
        
        public override void OnRemove()
        {
            base.OnRemove();
            Debug.Log("EnemyProxy OnRemove");
        }
    }
}
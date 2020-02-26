using System.Collections.Generic;
using PureMVC.Patterns;
using UnityEngine;

namespace PureMVCContent.Model
{
    public class LevelProxy: Proxy
    {
        public List<LevelModel> LevelsLists = new List<LevelModel>();

        public new static string NAME = "Level";
        
        public LevelProxy(string proxyName)
            : base(proxyName)
        {
            Debug.Log("LevelProxy create");
        }

        public void AddLevel(LevelModel level)
        {
            LevelsLists.Add(level);
        }

        public override void OnRegister()
        {
            base.OnRegister();
            Debug.Log("LevelProxy OnRegister");
        }
        
        public override void OnRemove()
        {
            base.OnRemove();
            Debug.Log("LevelProxy OnRemove");
        }
    }
}
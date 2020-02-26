using UnityEngine;

namespace PureMVCContent.Model
{
    public class PlayerDataProxy : PureMVC.Patterns.Proxy
    {
        public new static string NAME = "PlayerData";

        public PlayerDataModel PlayerData;

        public PlayerDataProxy(string name)
            : base(name, null)
        {
            PlayerData = new PlayerDataModel();
        }

        public void GetReward(int reward)
        {
            PlayerData.RewardTotal += reward;
            SendNotification(MyFacade.PLAYER_REWARD_UPDATED,  reward);
        }

        public int GetScore()
        {
            return PlayerData.RewardTotal;
        }


        public override void OnRegister()
        {
            Debug.Log("PlayerDataProxy OnRegister");
        }

        /// <summary>
        /// Called by the Model when the Proxy is removed
        /// </summary>
        public override void OnRemove()
        {
            Debug.Log("PlayerDataProxy OnRemove");
        }
    }
}
using PureMVC.Patterns;
using UnityEngine;

namespace PureMVCContent.Model
{
    public class OtherDataProxy : Proxy
    {
        public new static string NAME = "OtherData";

        public OtherDataModel OtherData;

        public OtherDataProxy(string name)
            : base(name, null)
        {
            //now it initialize from here. In normal case use db or request))
            var max = 5;
            var current = max;
            var bulletDamage = 1;
            var bulletTTL = 3;
            var bulletSpeed = 100;
            var bulletSpawnPeriod = 300;
            var playerSpeed = 100;
            var currentLevelNumber = 0;
            var maxLevelNumber = 2;

            OtherData = new OtherDataModel(max, current, bulletDamage, bulletTTL, bulletSpeed, playerSpeed,
                bulletSpawnPeriod, currentLevelNumber,maxLevelNumber);
        }

        public void StartTry()
        {
            OtherData.LivesCurrent -= 1;
            SendNotification(MyFacade.OTHER_DATA_UPDATED, OtherData);
        }

        public void ResetTries()
        {
            OtherData.LivesCurrent = OtherData.LivesMax;
            SendNotification(MyFacade.OTHER_DATA_UPDATED, OtherData);
        }


        public override void OnRegister()
        {
            Debug.Log("OtherDataProxy OnRegister");
        }

        /// <summary>
        /// Called by the Model when the Proxy is removed
        /// </summary>
        public override void OnRemove()
        {
            Debug.Log("OtherDataProxy OnRemove");
        }

        public void SetNextLevel()
        {
            OtherData.CurrentLevelNumber++;
            if (OtherData.CurrentLevelNumber > OtherData.MaxLevelNumber)
            {
                OtherData.CurrentLevelNumber = 0;
                SendNotification(MyFacade.GAME_IS_DONE);
            }
            else
            {
                SendNotification(MyFacade.PLAY_NEXT_LEVEL,OtherData.CurrentLevelNumber);
            }
        }

        public int GetCurrentLevel()
        {
            return OtherData.CurrentLevelNumber;
        }

        public int GetLives()
        {
            return OtherData.LivesCurrent;
        }
    }
}
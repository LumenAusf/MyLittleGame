using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;
using UnityEngine;

namespace PureMVCContent.View
{
    public class GameMediator : Mediator
    {
        public new const string NAME = "GameMediator";

        private GameView View;

        private OtherDataProxy otherData;

        private PlayerDataProxy playerData;
        // private LevelProxy levelData;

        private List<EnemyItem> EnemiesItemsLists = new List<EnemyItem>();


        public GameMediator(object viewComponent) : base(NAME, viewComponent)
        {
            View = ((GameObject) ViewComponent).GetComponentInChildren<GameView>(true);
            Debug.Log("game mediator");
            otherData = Facade.RetrieveProxy(OtherDataProxy.NAME) as OtherDataProxy;
            playerData = Facade.RetrieveProxy(PlayerDataProxy.NAME) as PlayerDataProxy;
            // levelData = Facade.RetrieveProxy(LevelProxy.NAME) as LevelProxy;

            View.Portal.Enter += Enter;

            View.UpdateScore(playerData.PlayerData.RewardTotal);
        }

        private void Enter()
        {
            otherData.SetNextLevel();
        }


        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case MyFacade.PLAYER_REWARD_UPDATED:
                    View.UpdateScore(playerData.PlayerData.RewardTotal);
                    break;
                case MyFacade.LEVEL_DONE:
                    View.EnablePortal();
                    break;
                case MyFacade.PLAY_NEXT_LEVEL:
                    View.DisablePortal();
                    View.ResetPerson();
                    break;
                case MyFacade.GAME_IS_DONE:
                    View.DisablePortal();
                    View.ResetPerson();
                    Hide();
                    break;
            }
        }

        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>
            {
                MyFacade.PLAYER_REWARD_UPDATED,
                MyFacade.LEVEL_DONE,
                MyFacade.PLAY_NEXT_LEVEL,
                MyFacade.GAME_IS_DONE
            };

            return list;
        }

        public void AddItems(EnemyItem obj)
        {
            EnemiesItemsLists.Add(obj);
        }

        public GameObject InstanceEnemyItem()
        {
            return GameObjectUtility.Instance.CreateGameObject(View.EnemyTemplate, View.ParentEnemyItem);
        }

        public override void OnRegister()
        {
        }

        public override void OnRemove()
        {
        }

        public void RemoveItem(EnemyItem enemyItem)
        {
            EnemiesItemsLists.Remove(enemyItem);
            if (EnemiesItemsLists.Count == 0)
                SendNotification(MyFacade.LEVEL_DONE);
        }

        public void Show()
        {
            View.gameObject.SetActive(true);
        }

        public void Hide()
        {
            View.gameObject.SetActive(false);
        }

        public Vector3 GetEnemySize()
        {
            return View.EnemyTemplate.transform.localScale;
        }
    }
}
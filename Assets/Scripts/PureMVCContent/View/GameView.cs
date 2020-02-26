using UnityEngine;
using UnityEngine.UI;

namespace PureMVCContent.View
{
    public class GameView : MonoBehaviour
    {
        public Text Score;
        public CharacterController Person;
        public GameObject EnemyTemplate;
        public Transform ParentEnemyItem;
        public Portal Portal;

        public void UpdateScore(int score)
        {
            Score.text = score.ToString();
        }

        public void ResetPerson()
        {
            Person.transform.SetPositionAndRotation(new Vector3(0, 1.8f, -27), Quaternion.identity);
        }

        public void EnablePortal()
        {
            Portal.gameObject.SetActive(true);
        }

        public void DisablePortal()
        {
            Portal.gameObject.SetActive(false);
        }
    }
}
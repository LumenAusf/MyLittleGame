using UnityEngine;
using UnityEngine.UI;

namespace PureMVCContent.View
{
    public class NewLeaderView : MonoBehaviour
    {
        public InputField FieldName;
        public Text Score;
        public Button ButtonApply;
        
        public void Clear()
        {
            FieldName.text = string.Empty;
        }

        public void SetReward(int reward)
        {
            Score.text = reward.ToString();
        }
    }
}
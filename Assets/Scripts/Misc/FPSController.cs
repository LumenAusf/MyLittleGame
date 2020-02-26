using UnityEngine;

public class FPSController : MonoBehaviour
{
      
    public int target = 60;
      
    void Awake()
    {
        Application.targetFrameRate = target;
    }
      
    void Update()
    {
        if(Application.targetFrameRate != target)
            Application.targetFrameRate = target;
    }
}
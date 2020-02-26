using UnityEngine;

public class App : MonoBehaviour
{
    void Awake()
    {
        MyFacade.GetInstance().Launch();
    }
}
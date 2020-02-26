using System;
using Misc;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public Joystick Joystick;
    public CharacterController Target;
    public Bullet bullet;
    public Transform BulletPool;
    public Transform bulletSpawner;
    public float speed;
    public float spawnPeriodMs;

    private DateTime lastBulletSpawn;
    
    void Update()
    {
        var x = Joystick.Horizontal;
        var z = Joystick.Vertical;
        if (Math.Abs(x) < float.Epsilon && Math.Abs(z) < float.Epsilon)
        {
            if(DateTime.UtcNow > lastBulletSpawn + TimeSpan.FromMilliseconds(spawnPeriodMs))
                FireAction();
            return;
        }
        var move = Vector3.right * x + Vector3.forward *  z;
        Target.Move(move * (speed * Time.deltaTime));
        var rot = Mathf.Atan2(x, z)*180 / Mathf.PI;
        Target.transform.eulerAngles = new Vector3(0, rot, 0);
    }

    void FireAction()
    {
        lastBulletSpawn = DateTime.UtcNow;
        var bull = Instantiate(bullet, bulletSpawner.position, Target.transform.rotation, BulletPool);
        bull.Fire();
    }

    private void OnDisable()
    {
        Joystick.OnPointerUp(null);
    }
}

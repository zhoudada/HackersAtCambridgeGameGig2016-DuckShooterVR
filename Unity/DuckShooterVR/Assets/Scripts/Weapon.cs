using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

    protected float ShootingTime { get; set; }
    public bool IsShooting { get; protected set; }

    void Start()
    {
        ShootingTime = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    protected abstract IEnumerator ShootCoroutine();

    public virtual void Shoot()
    {
        if (!IsShooting)
        {
            StartCoroutine(ShootCoroutine());
        }
    }
}

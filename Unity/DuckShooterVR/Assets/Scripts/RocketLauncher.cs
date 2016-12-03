using UnityEngine;
using System.Collections;

public class RocketLauncher : Weapon
{
    [SerializeField]
    private GameObject _missile;
    [SerializeField]
    private Transform _shootingPosition;

    private float _shootingTime = 2f;
    private LaserController _laserController;

    void Start()
    {
    }

    void Update()
    {
    }

    protected override IEnumerator ShootCoroutine()
    {
        GameObject missile = Instantiate(_missile, _shootingPosition.position, Quaternion.identity)
            as GameObject;
        missile.transform.forward = transform.forward;
        IsShooting = true;
        SoundManager.Instance.PlayRocketSound();
        yield return new WaitForSeconds(_shootingTime);
        IsShooting = false;
    }
}

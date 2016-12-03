using UnityEngine;
using System.Collections;

public class Railgun : Weapon
{
    [SerializeField]
    private GameObject _laserLineObject;

    private float _shootingTime = 1f;
    private LaserController _laserController;

    void Start()
    {
        _laserController = _laserLineObject.GetComponentInParent<LaserController>();
    }

    void Update()
    {
        if (IsShooting)
        {
            _laserController.DetectTargetHit();
        }
    }

    protected override IEnumerator ShootCoroutine()
    {
        _laserLineObject.SetActive(true);
        IsShooting = true;
        SoundManager.Instance.PlayLaserSound();
        yield return new WaitForSeconds(_shootingTime);
        IsShooting = false;
        _laserLineObject.SetActive(false);
    }
}

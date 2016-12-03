using UnityEngine;
using System.Collections.Generic;

public enum WeaponType
{
    Laser = 0,
    RocketLauncher = 1
}

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField]
    private List<Transform> _weaponTransforms = new List<Transform>();
    [SerializeField]
    private GameObject Explosion;

    private List<Weapon> _weapons = new List<Weapon>();
    private Weapon _curWeapon;
    private WeaponType _weaponType = WeaponType.Laser;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            DestroyImmediate(gameObject);
        }
        int n = _weaponTransforms.Count;
        for (int i = 0; i < n; i++)
        {
            _weapons.Add(_weaponTransforms[i].GetComponent<Weapon>());
        }
        _curWeapon = _weapons[0];
    }

    private void Shoot()
    {
        _curWeapon.Shoot();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SwitchWeapon();
        }
    }

    public void OnTargetHit(List<GameObject> targets)
    {
        foreach (GameObject obj in targets)
        {
            Debug.Log(string.Format("{0} is hit", obj.name));
            GameObject exp = Instantiate(Explosion, obj.transform.position, Quaternion.identity) as GameObject;
            switch (_weaponType)
            {
                case WeaponType.Laser:
                    SoundManager.Instance.PlayExplosionSound();
                    break;

                case WeaponType.RocketLauncher:
                    SoundManager.Instance.PlayBigExplosionSound();
                    exp.GetComponent<Detonator>().size = 5;
                    break;
            }
            SoundManager.Instance.PlayExplosionSound();
            Destroy(obj);
            SoundManager.Instance.PlayRewardSound();
        }
    }

    private void SwitchWeapon()
    {
        int n = _weapons.Count;
        int curIndex = (int) _weaponType;
        curIndex = (curIndex + 1)%n;
        _curWeapon.gameObject.SetActive(false);
        _curWeapon = _weapons[curIndex];
        _curWeapon.gameObject.SetActive(true);
        _weaponType = (WeaponType) curIndex;
    }
}

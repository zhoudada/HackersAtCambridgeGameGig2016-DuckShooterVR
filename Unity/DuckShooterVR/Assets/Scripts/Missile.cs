using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class Missile : MonoBehaviour
{
    [SerializeField]
    private float _acceleration = 100f;

    private Rigidbody _rb;
    private float _lifeTime = 5f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Destroy(gameObject, _lifeTime);
    }

    void FixedUpdate()
    {
        _rb.AddForce(transform.forward * _acceleration, ForceMode.Acceleration);
    }

    void OnTriggerEnter(Collider collider)
    {
        // TODO: Put check of destroyable here
        GameController.Instance.OnTargetHit(new List<GameObject>() {collider.gameObject});
        Destroy(gameObject);
    }
}

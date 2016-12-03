using UnityEngine;
using System.Collections.Generic;
using VolumetricLines;

public class LaserController : MonoBehaviour
{
    [SerializeField]
    private VolumetricLineBehavior _laserLine;
    [SerializeField]
    private Transform _startPosition;
    [SerializeField]
    private Transform _endPosition;
    [SerializeField]
    private float _laserWidth = 0.1f;

    void Start()
    {
        _laserLine.LineWidth = _laserWidth;
    }

    void Update()
    {
        _laserLine.StartPos = _startPosition.position;
        _laserLine.EndPos = _endPosition.position;
    }

    public void DetectTargetHit()
    {
        Vector3 direction = _endPosition.position - _startPosition.position;
        float maxDistance = direction.magnitude;
        RaycastHit[] targetHits = Physics.SphereCastAll(
            _startPosition.position, _laserWidth/2, direction, maxDistance);
        List<GameObject> targets = new List<GameObject>();
        if (targetHits.Length > 0)
        {
            foreach (RaycastHit hit in targetHits)
            {
                IDestroyable destroyable = hit.collider.gameObject.GetComponentInParent<IDestroyable>();
                //if (destroyable != null)
                //{
                //    targets.Add(destroyable.GameObject);
                //}
                targets.Add(hit.collider.gameObject);
            }
            GameController.Instance.OnTargetHit(targets);
        }
    }
}

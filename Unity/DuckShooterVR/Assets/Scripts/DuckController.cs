using UnityEngine;
using System.Collections;

public class DuckController: BaseTarget
{
    public Transform CameraTransform;

    private Rigidbody rb;

    public float minRadius, maxRadius;
    public float maxHorAngle, maxEleAngle;
    public float fwdAngOffset;
    
    public Vector3 force;
    public float rate;
    public Vector3 rbPosition;
    public Vector3 forwardDir;
    public float horizForceRate;
    public float centralForceRate;
    public float downRate;

    private int fixedUpdateIter;

    public override void OnTargetHit() {
        Destroy(gameObject);
    }

    public override void OnTimeOut(float lifetime) {
        Destroy(gameObject, lifetime);
    }

    // Use this for initialization
    void Start() {
        // [To Do] Initialise position
        rb = GetComponent<Rigidbody>();
        forwardDir = CameraTransform.forward;
        fixedUpdateIter = 0;
    }

    // Update is called once per frame
    void FixedUpdate() {
        fixedUpdateIter++;
        if (fixedUpdateIter % 20 != 0)
            return;
        force = rate * (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
        force += ConstraintForce() * rate;
        rb.AddForce(force);
        rbPosition = rb.position;
    }

    // The drag
    Vector3 ConstraintForce() {
        Vector3 rb2DPos = new Vector3(rb.position.x, 0, rb.position.z);
        fwdAngOffset = Vector3.Angle(forwardDir, rb2DPos);
        Vector3 normPos = rb.position;
        normPos.y = 0;
        normPos = Vector3.Normalize(normPos);
        Vector3 horizUnitForce = Vector3.Normalize(Vector3.Cross(Vector3.Cross(normPos, forwardDir), normPos));
        float eleAng = 90 - Vector3.Angle(Vector3.up, rb.position);
        float radius = Vector3.Distance(Vector3.zero, rb.position);

        Vector3 height = new Vector3(0, rb.position.y, 0);
        Vector3 eleForce = Vector3.Normalize(Vector3.Cross(rb.position, Vector3.Cross(rb.position, height)));

        Vector3 result = Vector3.zero;
        if (fwdAngOffset > 0) {
            result += horizUnitForce * Mathf.Exp(fwdAngOffset / maxHorAngle) * horizForceRate;
        }
        if (eleAng > 0) {
            result +=  Mathf.Exp(eleAng / maxEleAngle) * eleForce * downRate;
        }
        if (radius > minRadius) {
            result -= rb.position * centralForceRate * Mathf.Exp(radius / maxRadius);
        }
        else if (radius < minRadius)
        {
            result += rb.position * centralForceRate * maxRadius / Mathf.Max(radius, 1);
        }
        

        return result;
    }
}

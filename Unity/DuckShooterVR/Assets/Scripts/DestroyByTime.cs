using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
    public float lifetime;
    private BaseTarget bt;

	// Use this for initialization
	void Start () {
        bt = GetComponent<BaseTarget>();
        bt.OnTimeOut(lifetime);
	}
	
}

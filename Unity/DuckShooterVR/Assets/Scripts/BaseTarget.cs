﻿using UnityEngine;
using System.Collections;

public class BaseTarget : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void OnTargetHit() {}
    public virtual void OnTimeOut(float lifetime) {}
}

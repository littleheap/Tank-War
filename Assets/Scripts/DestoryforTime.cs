using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryforTime : MonoBehaviour {

    public float time;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject,time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

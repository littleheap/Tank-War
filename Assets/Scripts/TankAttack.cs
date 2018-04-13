﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour {

    public GameObject shellPrefab;
    public KeyCode fireKey = KeyCode.Space;
    public int shellSpeed;
    public AudioClip shotAudio;

    private Transform firePosition;
    private float time1 = 0;
    private float time2 = 0;
    public static float delta = 0;

    // Use this for initialization
    void Start () {

        firePosition = transform.Find("FirePosition");
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(fireKey)) {

            AudioSource.PlayClipAtPoint(shotAudio,transform.position);

            //GameObject go = GameObject.Instantiate(shellPrefab, firePosition.position, firePosition.rotation) as GameObject;
            //go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellSpeed;

            time1 = Time.time;

        }
        if (Input.GetKeyUp(fireKey)) {

            time2 = Time.time;

            delta = time2 - time1;

            if (delta > 3) {
                delta = 3;
            }

            GameObject go = GameObject.Instantiate(shellPrefab, firePosition.position, firePosition.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * 10 * delta;

        }

    }
}

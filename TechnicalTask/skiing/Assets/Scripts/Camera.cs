using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public GameObject stellar;
    private Vector3 vect;
    public float speed = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        vect = stellar.transform.localPosition - gameObject.transform.localPosition;
        vect.z = vect.z - 1;
        vect.x = vect.x + 2;
        vect.y = vect.y - 2;
        gameObject.transform.Translate(vect * Time.deltaTime * speed);
	}
}

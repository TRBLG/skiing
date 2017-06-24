using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stellar : MonoBehaviour {
    Transform centerOfMass;
    Rigidbody2D rb;

    void Awake()
    {
        centerOfMass = transform.Find("center"); //получаем центр масс
        rb = GetComponent<Rigidbody2D>(); //получаем Rigidbody2D
        rb.centerOfMass = Vector3.down; //смещаем центр масс для полученного rigidbody2D вниз



    }


    void Start () {
		
	}
	

	void Update () {
		
	}
}

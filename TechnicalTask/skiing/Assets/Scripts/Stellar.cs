using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stellar : MonoBehaviour {
    Transform centerOfMass;
    Rigidbody2D rb;
    Vector3 vect;
    public float speed = 250; // множитель импульса
    

    void Awake()
    {
        centerOfMass = transform.Find("center"); //получаем центр масс
        rb = GetComponent<Rigidbody2D>(); //получаем Rigidbody2D
        rb.centerOfMass = Vector3.down; //смещаем центр масс для полученного rigidbody2D вниз
        vect = new Vector3(0.5f, 0.3f, 0);// вектор, определяющий направление импульса
    }

    void Start () {
		
	}

    private void OnMouseDown()
    {
        rb.AddForce(vect * speed);  //задаем неваляшке импульс при клике по ней
    }
}

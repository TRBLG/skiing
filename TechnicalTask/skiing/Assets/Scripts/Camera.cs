using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    private GameObject firstStellar;
    public GameObject[] stellars;
    private Vector3 vect;
    public float speed = 2;

	void FixedUpdate () {
        getFirstPlayer();

        vect = firstStellar.transform.localPosition 
            - gameObject.transform.localPosition;// вычитая координаты камеры из координат конечной
                //токи, получаем вектор, который определяет
                //направление к конечной точке и скорость движения

        //смещаю от наблюдаемой неваляшки немного в сторону, чтобы неваляшка не была по центру 
        vect.z = vect.z - 1;
        vect.x = vect.x + 2;
        vect.y = vect.y - 2;

        gameObject.transform.Translate(vect * Time.fixedDeltaTime * speed);//двигаю камеру
	}

    private void getFirstPlayer()//просто определяем, какая из неваляшек продвинулась по X дальше
    {
        float x = stellars[0].transform.position.x;
        firstStellar = stellars[0];

        for (int i = 1; i < stellars.Length; i++ )
        {
            if(x < stellars[i].transform.position.x)
            {
                x = stellars[i].transform.position.x;
                firstStellar = stellars[i];
            }          
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour {
    public EdgeCollider2D collider;
    public LineRenderer renderer;

	void Update () {
        Vector2[] mass = collider.points; //получаем все точки колайдера
        renderer.numPositions = collider.pointCount; //получаем колличество точек колайдера
                                                    //и определяем количество точек для LineRenderer
        for (int i = 0; i < mass.Length; i++)
        {
            renderer.SetPosition(i, new Vector3(mass[i].x, mass[i].y - renderer.startWidth/2, 0));
            // создаем точки для LineRenderer по координатам соответствующих точек колайдера 
        }
    }
}

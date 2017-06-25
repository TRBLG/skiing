using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {
    public EdgeCollider2D collider;
    private GameObject firstStellar;
    public GameObject[] stellars;
    Vector2[] points;
    Vector2 startPoint;
    int countPoints = 100; // колличество точек
    float countPi = 2;
    float downStep = 0.7f; //коофицент, на который уменьшаем y при создании каждой точки
                            //чем больше это число, тем более отвесным будет склон и тем меньше будут возвышения
    const float stepPi = 0.3f;
    int amplitude = 2; //чем больше число, тем больше перепады высот

    private void Start()
    {
        startPoint = collider.points[0];
        
        startGeneration();
    }


    private void FixedUpdate()
    {
        checkDistanse();
    }

    private void startGeneration()
    {
        points = new Vector2[countPoints];
        points[0] = startPoint;

        //проходимся по всему массиву создавая точки
        for (int i = 1; i < countPoints; i++) {
            addPoint(i);
        }

        collider.points = points;//задаем полученный массив векторов колайдеру
    }

    private void addPoint(int position)
    {
        points[position] = new Vector2(points[position - 1].x + 0.5f, points[position - 1].y - downStep 
                                                    + (Mathf.Sin(countPi) * Random.value * amplitude));
        //создаем Vector2

        countPi += stepPi;//увеличиваем Пи
        if (countPi > Mathf.PI * 2) { countPi -= Mathf.PI * 2; }// обнуляем для измежание переполнения
    }

    private void checkDistanse()
    {
        getFirstPlayer();
        if (firstStellar.transform.position.x - startPoint.x > 10) //проверяем расстоение от неваляшки до первой токи карты
        {
            startPoint = points[1];
            for (int i = 1; i < points.Length; i++ ) //смещаем массив точек на 1 затирая первую
            {
                points[i - 1] = points[i];
            }
            addPoint(points.Length - 1); //добавляем точку в конец массива
            collider.points = points;//задаем полученный массив векторов колайдеру
        }
    }

    private void getFirstPlayer()//просто определяем, какая из неваляшек продвинулась по X дальше
    {
        float x = stellars[0].transform.position.x;
        firstStellar = stellars[0];

        for (int i = 1; i < stellars.Length; i++)
        {
            if (x < stellars[i].transform.position.x)
            {
                x = stellars[i].transform.position.x;
                firstStellar = stellars[i];
            }
        }

    }
}

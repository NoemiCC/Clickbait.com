using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spwanPoints;
    public Transform[] towerPoints;
    public GameObject enemyPrefab;
    public GameObject ratPrefab;
    public GameObject towerPrefab;
    public int enemyCount = 3;
    public int ratCount = 1;
    public int towerCount = 4;
    private List<int> towrChosen = new List<int>();
    public float spwanTime = 0.5f;

    void SpwanEnemy()
    {
        for (int i=0; i < enemyCount; i++) {
            int random = Random.Range(0, spwanPoints.Length);
            Instantiate(enemyPrefab, spwanPoints[random].transform.position, Quaternion.identity);
        }
    }
    void SpwanRat()
    {
        for (int i=0; i < ratCount; i++) {
            int random = Random.Range(0, spwanPoints.Length);
            Instantiate(ratPrefab, spwanPoints[random].transform.position, Quaternion.identity);
        }
    }
    void SpwanTower()
    {
        for (int i=0; i < towerCount; i++) {
            int random = Random.Range(0, towerPoints.Length);
            while (towrChosen.Contains(random)) {
                random = Random.Range(0, towerPoints.Length);
            }

            towrChosen.Add(random);
            Instantiate(towerPrefab, towerPoints[random].transform.position, Quaternion.identity);
        }
    }

    void Start()
    {
        SpwanTower();
        InvokeRepeating("SpwanEnemy", 0f, spwanTime);
        InvokeRepeating("SpwanRat", 0f, spwanTime);
    }
}

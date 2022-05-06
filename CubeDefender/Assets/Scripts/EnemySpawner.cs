using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    EnemyStats[] enemy;

    Transform[] EnemySpawners;
    void Start()
    {
        EnemySpawners = GetComponentsInChildren<Transform>();

        StartCoroutine(Spawn(20f));
    }

    IEnumerator Spawn(float delay){
        while (true){
            yield return new WaitForSeconds(delay);
            int i = Random.Range(0, EnemySpawners.Length-1);
            Enemy.Create(enemy[0], EnemySpawners[i].position);
        }
    }
}

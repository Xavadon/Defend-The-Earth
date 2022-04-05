using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float valueX;
    [SerializeField] float valueY;
    public float time;
    [SerializeField] Transform SpawnPos;
    [SerializeField] GameObject[] EnemyPrefab;
    Vector3 range;
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    void Repeat()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(time);
        Vector3 Pos1 = new Vector3(Random.Range(-valueX, valueX), valueY);
        Vector3 Pos2 = new Vector3(Random.Range(-valueX, valueX), -valueY);
        Vector3 Pos3 = new Vector3(valueX, Random.Range(-valueY, valueY));
        Vector3 Pos4 = new Vector3(-valueX, Random.Range(-valueY, valueY));

        int VectorCount = Random.Range(0, 4);
        if (VectorCount == 0)
        {
            range = SpawnPos.position + Pos1;
        }
        if (VectorCount == 1)
        {
            range = SpawnPos.position + Pos2;
        }
        if (VectorCount == 2)
        {
            range = SpawnPos.position + Pos3;
        }
        if (VectorCount == 3)
        {
            range = SpawnPos.position + Pos4;
        }

        
        GameObject Asteroid = Instantiate(EnemyPrefab[Random.Range(0,5)], range, Quaternion.identity);
        Repeat();
    }
}

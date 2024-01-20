using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatrueManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objPrefab;
    [SerializeField]
    private Transform spawnPosition; // camera 앞으로 고정

    public List<GameObject> activeObj;
    public int score;

    public void SpawnObject()
    {
        int obj_index = Random.Range(0, objPrefab.Count);
        GameObject go = Instantiate(objPrefab[obj_index], spawnPosition);
        activeObj.Add(go);
    }

    public void DestroyObject(GameObject go)
    {
        if (activeObj.Contains(go))
        {
            activeObj.Remove(go);
            Destroy(go);
        }
        score++;
    }
}

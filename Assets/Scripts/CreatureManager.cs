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
    private float maxTime = 0f;

    public static CreatrueManager instance;

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {

        int obj_index = Random.Range(0, objPrefab.Count);
        GameObject go = Instantiate(objPrefab[obj_index], spawnPosition);
        activeObj.Add(go);
    }

    //public void SpawnObject()
    //{
    //    int obj_index = Random.Range(0, objPrefab.Count);

    //    float randomX = Random.Range(-1.0f, 1.0f);
    //    float randomZ = Random.Range(0.0f, 1.0f);

    //    Vector3 randomOffset = new Vector3(randomX, 0, randomZ);

    //    GameObject go = Instantiate(objPrefab[obj_index], spawnPosition.position + randomOffset, Quaternion.identity);
    //    activeObj.Add(go);
    //}

    public void DestroyObject(GameObject go)
    {
        if (activeObj.Contains(go))
        {
            activeObj.Remove(go);
            Destroy(go);
            Invoke("SpawnObject", 1.0f);
        }
        score++;
    }
}

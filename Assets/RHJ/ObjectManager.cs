using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    public bool respawnObject;
    public bool destroyObject;
    
    [SerializeField]
    private List<GameObject> obj;
    [SerializeField]
    private Transform spawnPosition;

    public GameObject activeObject;
    public int score;


    void Update()
    {
        if (respawnObject)
        {
            respawnObject = false;
            SpawnObject(Random.Range(0, obj.Count));
        }

        if (destroyObject)
        {
            destroyObject = false;
            DestroyObject(activeObject);
        }
    }


    void SpawnObject(int obj_index)
    {
        activeObject = Instantiate(obj[obj_index], spawnPosition);
    }

    void DestroyObject(GameObject Active_obj)
    {
        Destroy(Active_obj);
        score++;
    }

}

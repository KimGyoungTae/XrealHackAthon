using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    //[Serializefield]
    //private Gameobject particle;

    //and allocate prefab


    //particle.SetActive(); for use


    [SerializeField]
    private ParticleSystem particle;

    void Start()
    {
        particle.Play();
    }

}

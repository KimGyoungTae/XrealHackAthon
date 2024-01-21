using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    private void update()
    {
        StartCoroutine(SShake());
    }


    IEnumerator SShake()
    {
        if (gameObject)
        {
            yield return null;
        }


        float t = 1f;
        float shakePower = 100f;
        Vector3 origin = gameObject.transform.position;

        while (t > 0f && gameObject)
        {
            t -= 0.05f;
            gameObject.transform.position = origin + (Vector3)Random.insideUnitCircle * shakePower * t;

            yield return null;
        }

        if (gameObject)
        {
            gameObject.transform.position = origin;
        }
    }
}

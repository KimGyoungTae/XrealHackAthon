using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creatrue : MonoBehaviour
{
    [Header("Preset Fields")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject completeParticle;
    [SerializeField] private float destRadius = 10.0f;
    [SerializeField] private Type type = Type.None;

    [SerializeField]
    private TriggerInputDetector triggerInputDetector;

    enum Type
    {
        None,
        Taeyop,
        Mandoo,
        Profeller,
    }

    public enum State
    {
        None,
        Break,
        Moving,
        Ready,
        Idle,
    }

    [Header("Debug")]
    public State state = State.None;
    public bool completed = false;
    public Vector3 destPos;
    public float moveSpeed = 0.5f;
    public bool spawnReady = false;

    private void Start()
    {
        state = State.Break;


        //Vector3 randPos;

        //Vector3 randDir = Random.insideUnitSphere * Random.Range(0, destRadius);
        ////randDir.y = type == Type.Profeller ? 10.0f : 3.0f;
        //randDir.y = 0;
        //randPos = transform.position + randDir;

        //destPos = randPos;
        destPos = transform.position + new Vector3(0, 0, 10);

        triggerInputDetector = FindObjectOfType<TriggerInputDetector>();
    }

    private void Update()
    {
        if (completed && state == State.Break)
        {
            //state = State.Moving;
            //CreatrueManager.instance.SpawnObject();
            //state = State.Ready;
            GameObject particleObject = Instantiate(completeParticle, transform.position, Quaternion.identity);
            particleObject.SetActive(true);
            CreatrueManager.instance.DestroyObject(gameObject);
        }

        switch (state)
        {
            case State.Break:
                UpdateBreak();
                break;
            case State.Moving:
                UpdateMoving();
                break;
            case State.Idle:
                UpdateIdle();
                break;
            case State.Ready:
                UpdateReady();
                break;
        }
    
    }

    void UpdateBreak() { }

    void UpdateReady()
    {
        //if ((triggerInputDetector.GetLeftGripValue + triggerInputDetector.GetRightGripValue + triggerInputDetector.GetLeftTriggerValue + triggerInputDetector.GetRightTriggerValue) < 0.1f) ;
        //{
        //    spawnReady = true;
        //}
        //if (spawnReady)
        //{ 
        //    CreatrueManager.instance.SpawnObject();
        //    spawnReady = false;
        //}
    }

    void UpdateMoving()
    {
        Vector3 dir = destPos - transform.position;
        float distance = dir.magnitude;
        Debug.Log(distance);

        if (distance < 0.1f)
        {
            animator.ResetTrigger("walk");
            Destroy(gameObject);
     
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, destPos, Time.deltaTime * moveSpeed);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
            
            animator.SetTrigger("walk");
            
        }
    }

    void UpdateIdle()
    {
        animator.SetTrigger("idle");
    }
}

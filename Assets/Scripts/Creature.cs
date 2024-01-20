using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creatrue : MonoBehaviour
{
    [Header("Preset Fields")]
    [SerializeField] private Animator animator;
    //[SerializeField] private GameObject completeParticle;
    [SerializeField] private float destRadius = 10.0f;
    [SerializeField] private Type type = Type.None;

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
        Idle,
    }

    [Header("Debug")]
    public State state = State.None;
    public bool completed = false;
    public Vector3 destPos;
    public float moveSpeed = 0.5f;

    private void Start()
    {
        state = State.Break;


        Vector3 randPos;

        Vector3 randDir = Random.insideUnitSphere * Random.Range(0, destRadius);
        //randDir.y = type == Type.Profeller ? 10.0f : 3.0f;
        randDir.y = transform.position.y;
        randPos = destPos + randDir;

        destPos = randPos;
    }

    private void Update()
    {
        if (completed && state == State.Break)
        {
            state = State.Moving;
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
        }
    
    }

    void UpdateBreak() { }

    void UpdateMoving()
    {
        Vector3 dir = destPos - transform.position;
        float distance = dir.magnitude;

        if (distance < 0.1f)
        {
            animator.ResetTrigger("walk");
            state = State.Idle;
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

// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Threading;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCPatrol : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public Animator anima;
    public float waitMin = 0.5f;
    public float waitMax = 5;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anima.SetBool("Walking", false);

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.isStopped = false;
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
        anima.SetBool("Walking", true);
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < agent.stoppingDistance)
        {
            anima.SetBool("Walking", false);
            StartCoroutine(WaitForNext());
        }
    }

    IEnumerator WaitForNext()
    {
        //agent.destination = transform.position;
        agent.isStopped = true;
        float result = Random.Range(waitMin, waitMax);
        yield return new WaitForSeconds(result);
        GotoNextPoint();
        StopCoroutine(WaitForNext());
    }
}

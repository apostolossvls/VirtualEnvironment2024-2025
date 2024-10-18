using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HorrorEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public Transform target;
    public bool isInReach;
    public bool isAttacking;
    public float maxHealth = 300f;
    private float health = 300f;
    [Range(0f, 1f)] public float audioMasterVolume = 1;
    public AudioClip[] attackAudio;

    private Vector3 lastPositon;

    // Start is called before the first frame update
    void Start()
    {
        target = null;
        isInReach = false;
        isAttacking = false;

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        PathToTarget();
    }

    void PathToTarget()
    {
        if (target != null && !isInReach)
        {
            agent.SetDestination(target.position);
        }
	
	    bool running = lastPositon != transform.position;

        animator.SetBool("Walking", running);
        lastPositon = transform.position;
    }

    public void EnterReach(bool value)
    {
        isInReach = value;
        animator.SetBool("Attacking", isInReach);
        if (isInReach) isAttacking = true;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        animator.SetTrigger("Death");
        Destroy(agent);
        Destroy(GetComponent<Collider>());
        Destroy(this);

    }

    public void PlayAttackAudio()
    {
        int index = Random.Range(0, attackAudio.Length);
        AudioSource.PlayClipAtPoint(attackAudio[index], transform.position, audioMasterVolume);
    }

    public void AnimEndAttack()
    {
        isAttacking = false;
    }
}

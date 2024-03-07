using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Patrol,
    Chase,
    Shoot,
}

public class EnemyFSM : MonoBehaviour
{
    [SerializeField] EnemyState curState = EnemyState.Idle;
    [SerializeField] bool isDebug = false;
    void Start()
    {
       
    }

    //FSM Update
    void Update()
    {
        switch(curState)
        {
            case EnemyState.Idle: IdleUpdate(); break;
            case EnemyState.Patrol: PatrolUpdate(); break;
            case EnemyState.Chase: ChaseUpdate(); break;
            case EnemyState.Shoot: ShootUpdate(); break;
        }
    }


    float idleTick = 0; // what is the waiting the he needs to render
    float waitTime = 3f;
    float minWaitTime = 3f;
    float maxWaitTime = 5f;//3-5
    void IdleUpdate()
    {
        if (this.GetComponent<Enemy>().Target != null)
        {
            SwitchState(EnemyState.Chase);
			idleTick = 0;
			return;
		}

		idleTick += Time.deltaTime;

        if(waitTime < idleTick ) 
        {
            idleTick = 0;
			waitTime = Random.Range(minWaitTime, maxWaitTime);
            SwitchState(EnemyState.Patrol);
            return;
        }
    }

    Vector2 targetPoint = Vector2.zero;
    float patrolOffset = .5f;
    void PatrolUpdate()
    {
		if (this.GetComponent<Enemy>().Target != null)
		{
			SwitchState(EnemyState.Chase);
			targetPoint = Vector2.zero;
			return;
		}

		if (Vector2.zero == targetPoint)
        {
            targetPoint = RandomDestinationPoint();
        }

        this.transform.position = Vector2.MoveTowards(this.transform.position, targetPoint, Time.deltaTime);
        if(Vector2.Distance(this.transform.position, targetPoint) < patrolOffset)
        {
            SwitchState(EnemyState.Idle);
            targetPoint = Vector2.zero;
			return;
        }
    }

    Vector2 RandomDestinationPoint()
    {
        float pntX = (float)Random.Range(-20, 20);
        float pntY = (float)Random.Range(-20, 20);

        return new Vector2(pntX, pntY);
    }

	float attackDist = 4f;
	void ChaseUpdate()
    {
		if (this.GetComponent<Enemy>().Target == null)
		{
			SwitchState(EnemyState.Idle);
			return;
		}
        if (Vector2.Distance(this.transform.position, this.GetComponent<Enemy>().Target.position) < attackDist)
        {
            //SwitchState(EnemyState.Shoot);
            return;
        }
        else
        {
			this.transform.position = Vector2.MoveTowards(this.transform.position, this.GetComponent<Enemy>().Target.position, Time.deltaTime);
		}
	}

    void ShootUpdate()
    {
        //if the distance is greater  to the attack distance you should switch the state into chase again
        // if the distance satisfy the shooting update you can keep shooting using this state


    }

    void SwitchState(EnemyState state)
    {
        curState = state;
    }

    Transform GetTarget()
    {
        return this.GetComponent<Enemy>().Target;
	}
}

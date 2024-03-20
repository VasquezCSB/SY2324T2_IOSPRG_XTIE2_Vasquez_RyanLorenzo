using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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

    float idleTick = 0; // what is the waiting the he needs to render
    float waitTime = 3f;
    float minWaitTime = 3f;
    float maxWaitTime = 5f;//3-5

    float attackDist = 4f;

    public float rotateSpeed = 0.0025f;
    //public Transform target;
    public GameObject bulletPrefab;
    public Enemy enemy;

    public Transform firingPoint;
    public float fireRate;
    private float timeToFire;

    public int currentBullets;

    //shotgun
    public int pellets = 8; // Number of pellets per shot
    public float spreadAngle = 30f; // Spread angle of pellets

    //automatic
    public float shootInterval = 0.1f;
    public float projectileSpeed = 10f;
    public int maxBullets; // Adjust this as per your requirement
    private float shootTimer = 0f;
    private bool isFiring = false;

    float patrolOffset = .5f;
    Vector2 targetPoint = Vector2.zero;

    private void Start()
    {
        //if (enemy.GetComponent<Enemy>().enemyTypes == EnemyTypes.pistolEnemy)
        //{
        //    maxBullets = 15;
        //}
        //else if (enemy.GetComponent<Enemy>().enemyTypes == EnemyTypes.shotgunEnemy)
        //{
        //    maxBullets = 2;
        //}
        //else if (enemy.GetComponent<Enemy>().enemyTypes == EnemyTypes.automaticEnemy)
        //{
        //    maxBullets = 30;
        //}
        currentBullets = maxBullets;

    }

    //FSM Update
    void Update()
    {

        switch (curState)
        {
            case EnemyState.Idle: IdleUpdate(); break;
            case EnemyState.Patrol: PatrolUpdate(); break;
            case EnemyState.Chase: ChaseUpdate(); break;
            case EnemyState.Shoot: ShootUpdate(); break;
        }
    }

    void IdleUpdate()
    {
        if (this.GetComponent<Enemy>().Target != null)
        {
            SwitchState(EnemyState.Chase);
            idleTick = 0;
            return;
        }

        idleTick += Time.deltaTime;

        if (waitTime < idleTick)
        {
            idleTick = 0;
            waitTime = Random.Range(minWaitTime, maxWaitTime);
            SwitchState(EnemyState.Patrol);
            return;
        }
    }

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
        if (Vector2.Distance(this.transform.position, targetPoint) < patrolOffset)
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

    void ChaseUpdate()
    {
        if (this.GetComponent<Enemy>().Target == null)
        {
            SwitchState(EnemyState.Idle);
            return;
        }
        if (Vector2.Distance(this.transform.position, this.GetComponent<Enemy>().Target.position) < attackDist)
        {
            FaceTarget();
            SwitchState(EnemyState.Shoot);
            return;
        }
        else
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.GetComponent<Enemy>().Target.position, Time.deltaTime);
        }
    }

    void ShootUpdate()
    {
        if (enemy.GetComponent<Enemy>().enemyTypes == EnemyTypes.pistolEnemy)
        {
            Debug.Log("pistolBullets: " + currentBullets);

            //Debug.Log("Alfred+pistol");
            if (timeToFire <= 0f)
            {
                Debug.Log("inRange");
                Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
                timeToFire = fireRate;
            }
            else
            {
                timeToFire -= Time.deltaTime;
            }
        }

        if (enemy.GetComponent<Enemy>().enemyTypes == EnemyTypes.shotgunEnemy)
        {

            Debug.Log("shotgunBullets: " + currentBullets);

            Debug.Log("Alfred+shotgun");

            if (timeToFire <= 0f)
            {
                Debug.Log("inRange");
                shotgunEnemy(2);
                timeToFire = fireRate;

            }
            else
            {
                timeToFire -= Time.deltaTime;
            }
        }

        if (enemy.GetComponent<Enemy>().enemyTypes == EnemyTypes.automaticEnemy)
        {
            Debug.Log("automaticBullets: " + currentBullets);
            if (this.GetComponent<Enemy>().Target != null && currentBullets > 0)
            {
                // Aim towards the target
                Vector2 direction = (this.GetComponent<Enemy>().Target.position - transform.position).normalized;

                if (!isFiring)
                {
                    automaticShoot(direction);
                    isFiring = true;
                }

                // Shoot at intervals
                shootTimer -= Time.deltaTime;
                if (shootTimer <= 0f)
                {
                    isFiring = false;
                    shootTimer = shootInterval;
                }
            }
        }

    }

    private void FaceTarget()
    {
        if (this.GetComponent<Enemy>().Target != null)
        {

            Vector2 direction = this.GetComponent<Enemy>().Target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }

    void SwitchState(EnemyState state)
    {
        curState = state;
    }

    Transform GetTarget()
    {
        return this.GetComponent<Enemy>().Target;
    }



    private void shotgunEnemy(int shotgunCount)
    {
        if (shotgunCount > 0)
        {
            for (int i = 0; i < pellets; i++)
            {
                Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(-spreadAngle, spreadAngle));
                Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation * rotation);
            }
            shotgunCount--;
        }
    }
    
    private void automaticShoot(Vector2 direction)
    {
        GameObject projectile = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

        currentBullets--;

        if(currentBullets <= 0)
        {
            Debug.Log("automaticNoMore");
        }
    }
}

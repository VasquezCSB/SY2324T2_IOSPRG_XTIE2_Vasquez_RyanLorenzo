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

    //pistol
    public int pistolAmmoLeft;
    public float shootInterval_Pistol = 2.16f;

    //shotgun
    public int pellets = 8; // Number of pellets per shot
    public float spreadAngle = 30f; // Spread angle of pellets
    public int shotgunAmmoLeft;
    public float shootInterval_Shotgun = 0.5f;

    //automatic
    public float shootInterval_Automatic = 0.35f;
    public float projectileSpeed = 10f;
    public int automaticAmmoLeft;

    //Common
    private bool isReloading = false;
    private bool isFiring = false;

    private float shootTimer_Pistol = 2.16f;
    private float shootTimer_Shotgun = 0.6f;
    private float shootTimer_Automatic = 0.35f;

    //public HealthManager healthManager;
    float patrolOffset = .5f;
    Vector2 targetPoint = Vector2.zero;

    private void Start()
    {
        //healthManager = HealthManager.instance.gameObject.GetComponent<HealthManager>();
        pistolAmmoLeft = 15;
        shotgunAmmoLeft = 2;
        automaticAmmoLeft = 30;

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

            if (this.GetComponent<Enemy>().Target != null)
            {
                if (pistolAmmoLeft > 0 && !isReloading)
                {

                    // Aim towards the target
                    Vector2 direction = (this.GetComponent<Enemy>().Target.position - transform.position).normalized;

                    if (!isFiring)
                    {
                        pistolShoot();
                        isFiring = true;
                    }

                    // Shoot at intervals
                    shootTimer_Pistol -= Time.deltaTime;
                    if (shootTimer_Pistol <= 0f)
                    {
                        isFiring = false;
                        shootTimer_Pistol = shootInterval_Pistol;
                    }
                }
                else if (pistolAmmoLeft <= 0 && !isReloading)
                {
                    isReloading = true;
                    Invoke("PistolReload", 2.0f);
                }

            }
        }

        if (enemy.GetComponent<Enemy>().enemyTypes == EnemyTypes.shotgunEnemy)
        {

            if (this.GetComponent<Enemy>().Target != null)
            {

                // Check if reloading
                if (isReloading)
                    return;

                // Check if out of ammo
                if (shotgunAmmoLeft <= 0)
                {
                    ShotgunReload();
                    return;
                }

                // Check if shooting
                if (!isFiring)
                {
                    shotgunEnemy();
                    isFiring = true;
                }

                shootTimer_Shotgun -= Time.deltaTime;
                if (shootTimer_Shotgun <= 0f)
                {
                    isFiring = false;
                    shootTimer_Shotgun = shootInterval_Shotgun;
                }

            }
        }

        if (enemy.GetComponent<Enemy>().enemyTypes == EnemyTypes.automaticEnemy)
        {

            if (this.GetComponent<Enemy>().Target != null)
            {
                if (automaticAmmoLeft > 0 && !isReloading)
                {

                    // Aim towards the target
                    Vector2 direction = (this.GetComponent<Enemy>().Target.position - transform.position).normalized;

                    if (!isFiring)
                    {
                        automaticShoot(direction);
                        isFiring = true;
                    }

                    // Shoot at intervals
                    shootTimer_Automatic -= Time.deltaTime;
                    if (shootTimer_Automatic <= 0f)
                    {
                        isFiring = false;
                        shootTimer_Automatic = shootInterval_Automatic;
                    }
                }
                else if (automaticAmmoLeft <= 0 && !isReloading)
                {
                    isReloading = true;
                    Invoke("AutomaticReload", 2.3f);
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

    private void pistolShoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        bulletPrefab.GetComponent<BulletMovement>().damage = 10;
        pistolAmmoLeft--;
    }

    private void shotgunEnemy()
    {
        for (int i = 0; i < pellets; i++){
            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(-spreadAngle, spreadAngle));
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation * rotation);
        }
        bulletPrefab.GetComponent<BulletMovement>().damage = 10;
        shotgunAmmoLeft--;
    }
    
    private void automaticShoot(Vector2 direction)
    {
        GameObject projectile = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

        bulletPrefab.GetComponent<BulletMovement>().damage = 15;
        automaticAmmoLeft--;
    }

    private void PistolReload()
    {
        pistolAmmoLeft = 15;
        isReloading = false;
    }

    void AutomaticReload()
    {
        automaticAmmoLeft = 30;
        isReloading = false;
    }

    void ShotgunReload()
    {
        isReloading = true;
        Invoke("FinishShotgunReload", 2.7f);
    }

    void FinishShotgunReload()
    {
        shotgunAmmoLeft = 2;
        isReloading = false;

    }
}

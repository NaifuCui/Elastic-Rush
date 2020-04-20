using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Player : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float friction;
    [Range(0, 1)]
    public float runValue;

    public float rushForce;
    public float rushCoolDownTime;

    public float bouncingForce;
    [Range(0, 1)]
    public float verticalBouncingValue;

    [HideInInspector] public int weaponState = 0;

    public GameObject weaponPoint;
    public GameObject sonicGun;
    public GameObject freezeGun;
    public GameObject gravityGrenade;

    //public AudioSource defaultAudioSource;
    //public AudioSource weaponAudioSource;

    //public AudioClip sonicGunAudioClip;
    //public AudioClip freezeGunAudioClip;
    //public AudioClip dashAudioClip;

    public GameObject deathSoundPrefab;
    public GameObject freezedSoundPrefab;

    public float shootSpeed;
    public float throwSpeed;

    public float shootCoolDownTime;

    public int freezeGunBulletsCount;
    public GameObject freezeBulletPrefab;
    public float freezeTime;
    public GameObject freezeBall;

    public GameObject gravityGrenadePrefab;

    public int sonicGunBulletsCount;
    public GameObject sonicEffectPoint;
    public GameObject sonicEffectPrefab;
    public BoxCollider2D sonicBox;
    public float sonicForce;

    public GameObject deathEffect;

    public Animator animator;

    [HideInInspector] public bool isDead;
    [HideInInspector] public float movingDelta;

    private Rigidbody2D rb;
    private float movementVelocity;
    private bool isReadyRush;
    private bool isUsingRightHorizontal;
    private bool isReadyShoot;

    private int fBulletsCount;
    private int sBulletsCount;

    private bool isFreezed;

    //private Vector3 lastPosition;


    void Start()
    {
        isReadyRush = true;
        isReadyShoot = true;
        isUsingRightHorizontal = false;
        movementVelocity = 0;
        rb = GetComponent<Rigidbody2D>();
        fBulletsCount = 0;
        sBulletsCount = 0;
        isFreezed = false;
        isDead = false;
        freezeBall.SetActive(false);
        DeactiveAllWeapon();
    }

    
    void Update()
    {
        //if (lastPosition.y - transform.position.y > 0.1f) 
        //{
        //    RuntimeManager.PlayOneShot("event:/Sound Effects/Landing");
        //}
        //lastPosition = transform.position;
    }

    public void LookAt(float yRotation, float xDirection)
    {
        if (isFreezed || isDead || !this.gameObject.activeSelf)
        {
            return;
        }
        if (transform.localScale.x > 0)
        {
            weaponPoint.transform.rotation = Quaternion.Euler(0, 0, -yRotation * 90.0f);
        }
        else
        {
            weaponPoint.transform.rotation = Quaternion.Euler(0, 0, yRotation * 90.0f);
        }
        if(xDirection != 0)
        {
            isUsingRightHorizontal = true;
            if(xDirection > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            isUsingRightHorizontal = false;
        }
    }

    public void Move(float delta)
    {
        if (isDead || !this.gameObject.activeSelf)
        {
            return;
        }

        movingDelta = delta;
        if (delta == 0)
        {
            animator.SetBool("isWalking", false);
            movementVelocity = Mathf.Lerp(movementVelocity, 0, friction);
            if(rb != null)
            {
                rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, friction), rb.velocity.y);
            }
            return;
        }
        if (isFreezed)
        {
            movingDelta = 0;
            return;
        }
        

        //Play Footsteps sound


        animator.SetBool("isWalking", true);
        movementVelocity += acceleration * delta * Time.deltaTime;
        movementVelocity = Mathf.Clamp(movementVelocity, -speed, speed);
        rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, movementVelocity, friction), rb.velocity.y);
        if (delta > 0)
        {
            if (!isUsingRightHorizontal)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            if(delta > runValue)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }else if(delta < 0)
        {
            if (!isUsingRightHorizontal)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (delta < -runValue)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
    }

    public void Rush()
    {
        if (!isReadyRush || isFreezed || isDead)
        {
            return;
        }
        if (transform.localScale.x > 0)
        {
            rb.AddForce(new Vector2(rushForce, 0));
        }
        else
        {
            rb.AddForce(new Vector2(-rushForce, 0));
        }
        //defaultAudioSource.clip = dashAudioClip;
        //defaultAudioSource.Play();
        RuntimeManager.PlayOneShot("event:/Sound Effects/Dash");
        isReadyRush = false;
        StartCoroutine(RushTimer());
    }

    IEnumerator RushTimer()
    {
        yield return new WaitForSeconds(rushCoolDownTime);
        isReadyRush = true; 
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(shootCoolDownTime);
        isReadyShoot = true; 
    }

    void DeactiveAllWeapon()
    {
        weaponState = 0;
        sonicGun.SetActive(false);
        freezeGun.SetActive(false);
        gravityGrenade.SetActive(false);
    }

    public void PickUpSonicGun()
    {
        DeactiveAllWeapon();
        weaponState = 1;
        sonicGun.SetActive(true);
        sBulletsCount = sonicGunBulletsCount;
    }

    public void PickUpFreezeGun()
    {
        DeactiveAllWeapon();
        weaponState = 2;
        freezeGun.SetActive(true);
        fBulletsCount = freezeGunBulletsCount;
    }

    public void PickUpGravityGrenade()
    {
        DeactiveAllWeapon();
        weaponState = 3;
        gravityGrenade.SetActive(true);
    }

    public void UseWeapon()
    {
        if (isFreezed || isDead)
        {
            return;
        }
        switch (weaponState) {
            case 1: ShootSonicGun(); break;
            case 2: ShootFreezeGun(); break;
            case 3: ThrowGravityGrenade(); break;
            default: break;

        }

    }

    public void ShootSonicGun()
    {
        if (!isReadyShoot || weaponState != 1)
        {
            return;
        }
        GameObject go = Instantiate(sonicEffectPrefab, sonicEffectPoint.transform.position, sonicEffectPoint.transform.rotation);
        if (transform.localScale.x > 0)
        {
            go.transform.Rotate(0, 0, -45.0f);
        }
        else
        {
            go.transform.Rotate(0, 0, 135.0f);
        }
        SonicForce();
        //weaponAudioSource.clip = sonicGunAudioClip;
        //weaponAudioSource.Play();
        RuntimeManager.PlayOneShot("event:/Sound Effects/Sonic gun shooting");
        isReadyShoot = false;
        StartCoroutine(ShootTimer());
        sBulletsCount--;
        if (sBulletsCount == 0)
        {
            DeactiveAllWeapon();
        }
    }

    public void ShootFreezeGun()
    {
        if (!isReadyShoot || weaponState != 2)
        {
            return;
        }
        GameObject go = Instantiate(freezeBulletPrefab, sonicEffectPoint.transform.position, sonicEffectPoint.transform.rotation);
        foreach(var i in GetComponents<Collider2D>())
        {
            Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), i);
        }
        foreach (var i in GetComponentsInChildren<Collider2D>())
        {
            Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), i);
        }
        if(transform.localScale.x > 0)
        {
            go.GetComponent<Rigidbody2D>().velocity = sonicEffectPoint.transform.right * shootSpeed;
        }
        else
        {
            go.GetComponent<Rigidbody2D>().velocity = -sonicEffectPoint.transform.right * shootSpeed;

        }
        //weaponAudioSource.clip = freezeGunAudioClip;
        //weaponAudioSource.Play();
        RuntimeManager.PlayOneShot("event:/Sound Effects/Freeze gun shooting");
        isReadyShoot = false;
        StartCoroutine(ShootTimer());
        fBulletsCount--;
        if (fBulletsCount == 0)
        {
            DeactiveAllWeapon();
        }
    }

    public void ThrowGravityGrenade()
    {
        if(weaponState != 3)
        {
            return;
        }
        GameObject go = Instantiate(gravityGrenadePrefab, sonicEffectPoint.transform.position, sonicEffectPoint.transform.rotation);
        foreach (var i in GetComponents<Collider2D>())
        {
            Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), i);
        }
        foreach (var i in GetComponentsInChildren<Collider2D>())
        {
            Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), i);
        }
        if (transform.localScale.x > 0)
        {
            go.GetComponent<Rigidbody2D>().velocity = sonicEffectPoint.transform.right * throwSpeed;
        }
        else
        {
            go.GetComponent<Rigidbody2D>().velocity = -sonicEffectPoint.transform.right * throwSpeed;

        }

        RuntimeManager.PlayOneShot("event:/Sound Effects/Gravity grenade throwing");
        //add throwing sound

        DeactiveAllWeapon();
    }

    void SonicForce()
    {
        Collider2D[] cos = Physics2D.OverlapBoxAll(sonicBox.transform.position, sonicBox.size, 0);
        foreach (var i in cos)
        {
            RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, i.transform.position);
            bool isBlocked = false;
            foreach(var h in hits)
            {
                if (h.collider.tag.Equals("Obstacles"))
                {
                    isBlocked = true;
                }
            }
            if (isBlocked)
            {
                continue;
            }
            
            if (i.tag.Equals("Player") && i.GetComponent<Player>() != this)
            {
                if(transform.localScale.x > 0)
                {
                    i.GetComponent<Rigidbody2D>().AddForce(sonicBox.transform.right * sonicForce);
                }
                else
                {
                    i.GetComponent<Rigidbody2D>().AddForce(-sonicBox.transform.right * sonicForce);
                }
            }
        }
    }

    public void FreezeSelf()
    {
        freezeBall.SetActive(true);
        isFreezed = true;
        RuntimeManager.PlayOneShot("event:/Sound Effects/Freezed");
        //Instantiate(freezedSoundPrefab, transform.position, transform.rotation);
        Invoke("UnFreezeSelf", freezeTime);
    }

    public void UnFreezeSelf()
    {
        isFreezed = false;
        freezeBall.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Vector2 dir = (transform.position - collision.gameObject.transform.position).normalized;
            dir = new Vector2(dir.x, dir.y * verticalBouncingValue);
            rb.AddForce(dir * bouncingForce);
        }
        if (collision.gameObject.tag.Equals("DangerWall") && !isDead)
        {
            isDead = true;
            RuntimeManager.PlayOneShot("event:/Sound Effects/Death");
            //Play death sound

            Instantiate(deathSoundPrefab, transform.position, transform.rotation);
            if (Mathf.Abs(transform.position.y - 5) < Mathf.Abs(transform.position.y + 5))
            {
                Instantiate(deathEffect, new Vector3(transform.position.x, 5, 0), transform.rotation);
            }
            else
            {
                Instantiate(deathEffect, new Vector3(transform.position.x, -5, 0), transform.rotation);
            }
            this.gameObject.SetActive(false);
            GameManager.instance.CheckWin();
        }
        if (collision.gameObject.tag.Equals("Obstacles") && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            RuntimeManager.PlayOneShot("event:/Sound Effects/Landing");
            //Play Landing sound

        }
    }
}

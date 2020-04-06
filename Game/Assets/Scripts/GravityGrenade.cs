using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GravityGrenade : MonoBehaviour
{
    public GameObject gravityWaveEffect;
    public float range;
    public float force;
    public GameObject gravityFieldSoundPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = Instantiate(gravityWaveEffect, transform.position, transform.rotation);
        AttractObjects();
        Destroy(this.gameObject);
    }

    private void AttractObjects()
    {
        RuntimeManager.PlayOneShot("event:/Sound Effects/Gravity grenade explosion");
        //Instantiate(gravityFieldSoundPrefab, transform.position, transform.rotation);
        Collider2D[] cos = Physics2D.OverlapCircleAll(transform.position, range);
        foreach(var i in cos)
        {
            if (i.tag.Equals("Player"))
            {
                i.GetComponent<Rigidbody2D>().AddForce((transform.position - i.transform.position) * force);
            }
        }
    }
}

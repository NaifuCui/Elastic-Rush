using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        SonicGun,
        FreezeGun,
        GravityGrenade
    }

    public ItemType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Player player = collision.GetComponent<Player>();
            switch (type)
            {
                case ItemType.SonicGun: player.PickUpSonicGun();
                    RuntimeManager.PlayOneShot("event:/Sound Effects/Sonic gun pickup");
                    break;
                case ItemType.FreezeGun: player.PickUpFreezeGun();
                    RuntimeManager.PlayOneShot("event:/Sound Effects/Freeze gun pickup"); 
                    break;
                case ItemType.GravityGrenade: player.PickUpGravityGrenade();
                    RuntimeManager.PlayOneShot("event:/Sound Effects/Gravity grenade pickup"); 
                    break;
                default: break;
            }
            MapCreator.instance.platformerList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                case ItemType.SonicGun: player.PickUpSonicGun(); break;
                case ItemType.FreezeGun: player.PickUpFreezeGun(); break;
                case ItemType.GravityGrenade: player.PickUpGravityGrenade(); break;
                default: break;
            }
            MapCreator.instance.platformerList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPowers : MonoBehaviour
{
    public ItemType item;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ItemActivePlayer(collision);
        }
    }

    public void ItemActivePlayer(Collider2D other)
    {
        OrcShamanlv2 player = other.GetComponent<OrcShamanlv2>();
        switch (item)
        {
            case ItemType.InverterMechanics:
                player.InverterMechanic(true);
                Destroy(gameObject);
                break;
            case ItemType.Death:
                player.StartCoroutine(player.DeathPlayer());
                Destroy(gameObject);
                player.StopCoroutine(player.DeathPlayer());
                break;
            case ItemType.Reinicio:
                player.StartCoroutine(player.Reinicio());
                Destroy(gameObject);
                player.StopCoroutine(player.Reinicio());
                break;
            case ItemType.NextLv:
                player.StartCoroutine(player.FinalLv());
                Destroy(gameObject);
                player.StopCoroutine(player.FinalLv());
                break;
        }
    }

    public enum ItemType
    {
        Death,
        InverterMechanics,
        Reinicio,
        NextLv
    }

    

}

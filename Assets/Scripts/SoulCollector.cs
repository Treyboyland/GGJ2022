using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCollector : MonoBehaviour
{
    [SerializeField]
    Deity deity;

    PlayerAttack playerIn;



    private void OnTriggerStay2D(Collider2D other)
    {
        var player = other.GetComponentInChildren<PlayerAttack>();
        if (player != null)
        {
            playerIn = player;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponentInChildren<PlayerAttack>();
        if (player != null && player == playerIn)
        {
            playerIn = null;
        }
    }

    public void TestHit()
    {
        if (playerIn != null)
        {
            //Debug.LogWarning("hit");
            deity.HitsTaken += playerIn.Player.Damage;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponentInChildren<PlayerAttack>();
        if (player != null)
        {
            playerIn = player;
            if (player.IsAttacking)
            {
                Debug.LogWarning("hit");
                deity.HitsTaken += player.Player.Damage;
            }
            else
            {
                var soulCount = player.Player.CurrentSouls;
                if (soulCount != 0)
                {
                    deity.CurrentSouls += soulCount;
                    player.Player.CurrentSouls = 0;
                    GameManager.Manager.OnPlayerDonatedSouls.Invoke(deity);
                }
            }

        }
    }
}

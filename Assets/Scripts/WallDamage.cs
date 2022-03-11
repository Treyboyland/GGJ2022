using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDamage : MonoBehaviour
{
    [SerializeField]
    Wall wall;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponentInChildren<PlayerAttack>();
        //Debug.Log("Attack collision: " + other.gameObject.name);
        if (player != null && player.IsAttacking)
        {
            wall.SecondsAtacked -= Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        var player = other.gameObject.GetComponentInChildren<PlayerAttack>();
        //Debug.Log("Attack collision: " + other.gameObject.name);
        if (player != null && player.IsAttacking)
        {
            wall.SecondsAtacked -= Time.deltaTime;
        }
    }
}

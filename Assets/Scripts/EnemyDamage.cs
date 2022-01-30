using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponentInChildren<PlayerAttack>();
        //Debug.Log("Attack collision: " + other.gameObject.name);
        if (player != null)
        {
            enemy.Health -= player.Player.Damage;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        var player = other.gameObject.GetComponentInChildren<PlayerAttack>();
        //Debug.Log("Attack collision: " + other.gameObject.name);
        if (player != null)
        {
            enemy.Health -= player.Player.Damage;
        }
    }
}

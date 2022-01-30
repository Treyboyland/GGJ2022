using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    Animator animator;

    bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking && Input.GetButton("Attack"))
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetTrigger("Attack");
        GameManager.Manager.OnPlayerAttacked.Invoke();
        yield return null;
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Initial"))
        {
            yield return null;
        }

        yield return null;
        isAttacking = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        Debug.Log("Attack collision: " + other.gameObject.name);
        if (enemy != null)
        {
            enemy.Health -= player.Damage;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        Debug.Log("Attack collision: " + other.gameObject.name);
        if (enemy != null)
        {
            enemy.Health -= player.Damage;
        }
    }
}

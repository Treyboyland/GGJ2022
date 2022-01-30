using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int maxHealth;


    int health;



    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            CheckForDeath();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnEnable()
    {
        health = maxHealth;
    }

    void CheckForDeath()
    {
        if (health <= 0)
        {
            GameManager.Manager.OnEnemyDefeatedAtLocation.Invoke(transform.position);
            gameObject.SetActive(false);
        }
    }
}

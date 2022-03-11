using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    float maxSecondsAttacked;


    float secondsAttacked;



    public float SecondsAtacked
    {
        get { return secondsAttacked; }
        set
        {
            secondsAttacked = value;
            CheckForDeath();
        }
    }

    private void OnEnable()
    {
        secondsAttacked = maxSecondsAttacked;
    }

    void CheckForDeath()
    {
        if (secondsAttacked <= 0)
        {
            //GameManager.Manager.OnEnemyDefeatedAtLocation.Invoke(transform.position);
            gameObject.SetActive(false);
        }
    }
}

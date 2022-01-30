using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deity : MonoBehaviour
{
    [SerializeField]
    int hitsToKill;

    [SerializeField]
    int currentSouls;

    public int CurrentSouls { get { return currentSouls; } set { currentSouls = value; } }

    [SerializeField]
    int hitsTaken = 0;

    public int HitsTaken { get { return hitsTaken; } set { hitsTaken = value; CheckForDeath(); } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckForDeath()
    {
        if (hitsTaken >= hitsToKill)
        {
            gameObject.SetActive(false);
        }
    }
}

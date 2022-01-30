using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    int damage;

    public int Damage { get { return damage; } set { damage = value; } }

    [SerializeField]
    int currentSouls;

    public int CurrentSouls { get { return currentSouls; } set { currentSouls = value; } }

    public void AddSoul()
    {
        CurrentSouls++;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

}

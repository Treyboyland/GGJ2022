using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    int damage;

    public int Damage { get { return damage; } set { damage = value; } }

    // Start is called before the first frame update
    void Start()
    {

    }

}

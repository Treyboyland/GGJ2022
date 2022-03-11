using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColorSetter : MonoBehaviour
{
    [SerializeField]
    ParticleSystem ps;

    [SerializeField]
    SpriteRenderer sprite;

    // Update is called once per frame
    void Update()
    {
        var main = ps.main;
        main.startColor = sprite.color;
    }
}

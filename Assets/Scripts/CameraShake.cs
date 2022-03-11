using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    Vector3 shakeRange;

    Vector3 initalPosition;

    [SerializeField]
    bool shake = false;

    public bool Shake { get { return shake; } set { shake = value; } }

    // Start is called before the first frame update
    void Start()
    {
        initalPosition = transform.localPosition;
    }

    Vector3 GetRandomOffset()
    {
        float x, y, z;
        x = Random.Range(shakeRange.x, shakeRange.y);
        y = Random.Range(shakeRange.x, shakeRange.y);
        z = initalPosition.z;

        return new Vector3(x, y, z);
    }


    // Update is called once per frame
    void Update()
    {
        if (shake)
        {
            transform.localPosition = initalPosition + GetRandomOffset();
        }
        else
        {
            transform.localPosition = initalPosition;
        }
    }
}

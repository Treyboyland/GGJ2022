using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    public float Speed { get { return speed; } }

    public bool CanMove { get; set; } = true;

    [SerializeField]
    Rigidbody2D body;

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            MovePlayer();
        }
    }


    void MovePlayer()
    {
        Vector2 pos = transform.position;

        Vector2 delta = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        pos += Time.fixedDeltaTime * speed * delta;

        body.MovePosition(pos);
    }
}

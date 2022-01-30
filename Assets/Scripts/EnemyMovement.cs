using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    Vector2 secondsBetweenMoves;

    [SerializeField]
    Vector2 secondsForMove;

    [SerializeField]
    Vector2 velocityRange;

    [SerializeField]
    Rigidbody2D body;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(MovementCoroutine());
        }
    }

    IEnumerator MovementCoroutine()
    {
        while (true)
        {
            bool flipX = Random.Range(0.0f, 1.0f) > 0.5f;
            bool flipY = Random.Range(0.0f, 1.0f) > 0.5f;
            float x = Random.Range(velocityRange.x, velocityRange.y);
            x *= flipX ? -1 : 1;
            float y = Random.Range(velocityRange.x, velocityRange.y);
            y *= flipY ? -1 : 1;
            float secondsToWait = Random.Range(secondsBetweenMoves.x, secondsBetweenMoves.y);
            float secondsToMove = Random.Range(secondsForMove.x, secondsForMove.y);

            Vector2 velocity = new Vector2(x, y);
            body.velocity = velocity;

            yield return new WaitForSeconds(secondsToMove);

            body.velocity = Vector2.zero;

            yield return new WaitForSeconds(secondsToWait);
        }
    }
}

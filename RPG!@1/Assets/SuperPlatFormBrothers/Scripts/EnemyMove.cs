using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public int EnemySpeed;
    public int xMoveDirection;
    public float hitDistance;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0.0f));
        Vector2 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        velocity.x = xMoveDirection * EnemySpeed;
        gameObject.GetComponent<Rigidbody2D>().velocity = velocity;

        if (hit.distance < hitDistance)
            Flip();

    }

    void Flip()
    {
        if (xMoveDirection > 0)
            xMoveDirection = -1;
        else
            xMoveDirection = 1;
    }
}
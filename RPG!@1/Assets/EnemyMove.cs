using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public int EnemySpeed;
    public int xMoveDirection;

    private void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * EnemySpeed;
    }

}

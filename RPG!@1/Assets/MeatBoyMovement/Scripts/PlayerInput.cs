using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    
    private bool isOnGround()
    {
        float lengthToSearch = 0.1f;
        float colliderThreshold = 0.001f;

        //this is using the bottom of the sprite might cause error
        Vector2 linestart = new Vector2(this.transform.position.x, this.transform.position.y - this.renderer.bounds.extends.y - colliderThreshold);

        Vector2 vectorToSeach = new Vector2(this.transform.position.x, linestart.y - lengthToSearch);

    }

}

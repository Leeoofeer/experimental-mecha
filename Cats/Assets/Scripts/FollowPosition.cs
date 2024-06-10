using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public Transform Target;
    public bool FollowOnX, FollowOnY, FollowOnZ;
    public float OffsetX, OffsetY, OffsetZ;

    private void Update()
    {
        var posX = FollowOnX ? Target.position.x : this.transform.position.x;
        var posY = FollowOnY ? Target.position.y : this.transform.position.y;
        var posZ = FollowOnZ ? Target.position.z : this.transform.position.z;

        this.transform.position = new Vector3 (posX + OffsetX, posY + OffsetY, posZ + OffsetZ);
    }
}

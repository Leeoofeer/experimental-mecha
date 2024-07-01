using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPosition : MonoBehaviour
{
    public Transform Target;
    public Transform HumanTarget;
    public bool FollowOnX, FollowOnY, FollowOnZ;
    public float OffsetX, OffsetY, OffsetZ;
    public CharController CharController;
    public CatVisionPostProcessing Component;
    public GameObject go_camera;
    public Camera myCamera;
    public Transform catTransform;

    private void Update()
    {
        var posX = FollowOnX ? Target.position.x : this.transform.position.x;
        var posY = FollowOnY ? Target.position.y : this.transform.position.y;
        var posZ = FollowOnZ ? Target.position.z : this.transform.position.z;

        this.transform.position = new Vector3(posX + OffsetX, posY + OffsetY, posZ + OffsetZ);
        if (Input.GetKeyDown(KeyCode.G))
        {
            SetCatMode();
        }
    }

    public void SetCatMode()
    {        
            ChangeOffset();
            TurnOnVision();        
    }

    public void ChangeOffset()
    {
        FollowOnX = true;
        FollowOnY = true;
        FollowOnZ = true;
        transform.position = new Vector3(14.047f, -0.89f, 3.36f);
        transform.rotation = Quaternion.Euler(-8.5f, 90, 0);
        CharController.isHuman = false;
        Target = catTransform;

        go_camera.transform.localPosition = new Vector3(0, 1.32f, -3.66f);
        go_camera.transform.localRotation = Quaternion.Euler(15, 0, 0);
        myCamera.fieldOfView = 10.4f;
    }

    public void ChangeOffsetToHuman()
    {
        FollowOnX = false;
        FollowOnY = false;
        FollowOnZ = false;
        Target = HumanTarget; 
        transform.position = new Vector3(-0.457f, 0, 3.5f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        CharController.isHuman = true;
    }

    public void TurnOnVision()
    {
        Component.enabled = true;
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFXPlayer : MonoBehaviour
{
    public ThirdPersonCharacterController playerController;
    public KatanaScript playerKatana;

    public void jumpFX()
    {
        playerController.rb.AddForce(new Vector3(0, playerController.jumpHeight, 0));
        playerController.isGrounded = false;
        playerController.jumpDelay = 1;
    }

    public void ignoreInput()
    {
        //Debug.Log("Stop");
        playerController.ignoreInput = true;
    }

    public void resumeInput()
    {
        //Debug.Log("resume");
        playerController.ignoreInput = false;
    }

    public void katanaHitBoxOn()
    {
        playerKatana.hitBoxOn();
    }

    public void katanaHitBoxOff()
    {
        playerKatana.hitBoxOff();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFXTracker : MonoBehaviour
{
    public EnemyBasic eb;
    public KatanaScript trackerKatana;

    public void katanaHitBoxOn()
    {
        trackerKatana.hitBoxOn();
    }

    public void katanaHitBoxOff()
    {
        trackerKatana.hitBoxOff();
    }

    public void setStunned()
    {
        eb.setStunLock();
    }

    public void resetStunned()
    {
        eb.resetStunLock();
    }

    public void setAttacking()
    {
        eb.setAttacking();
    }

    public void resetAttacking()
    {
        Debug.Log("FUCK");
        eb.resetAttacking();
    }
}

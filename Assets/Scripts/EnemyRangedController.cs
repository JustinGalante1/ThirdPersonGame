using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedController : MonoBehaviour
{
    private EnemyBasic eb;
    public GameObject shurikenPrefab;
    private float shurikenDelay;
    public float shurikenDelayAmount;
    // Start is called before the first frame update
    void Start()
    {
        eb = this.GetComponent<EnemyBasic>();
        shurikenDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (eb.inRange && eb.seesPlayer)
        {
            throwShuriken();
        }
    }

    private void LateUpdate()
    {
        if (shurikenDelay > 0)
        {
            shurikenDelay -= Time.deltaTime;
        }
    }

    public void throwShuriken()
    {
        if (shurikenDelay <= 0)
        {
            GameObject shurikenObject = Instantiate(shurikenPrefab);
            shurikenObject.layer = 11;
            shurikenObject.transform.position = this.transform.position + transform.forward * 2 + transform.up * 2;
            shurikenObject.transform.rotation = this.transform.rotation;
            shurikenDelay = shurikenDelayAmount;
        }
    }
}

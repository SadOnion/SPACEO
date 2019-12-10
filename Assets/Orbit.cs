using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    bool isOrbiting;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            IOrbitable o = collision.gameObject.GetComponent<IOrbitable>();
            if (o != null)
            {
                if (!isOrbiting)
                {

                    isOrbiting = true;
                    o.Oribt(transform);
                }
                else
                {
                    isOrbiting = false;

                    o.Deorbit();
                }
            }
            

        }
    }
}

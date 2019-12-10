using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Collider2D col;
    [SerializeField]SpaceShip ship=null;
    // Start is called before the first frame update
    void Start()
    {
        col=GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D[] info = new RaycastHit2D[2];
            int res = col.Cast(Vector2.zero,info);
            if (res >= 1)
            {
                if (ship.IsOrbiting)
                {
                    ship.Deorbit();
                }else
                ship.Oribt(info[0].transform);
            }
        }
    }
}

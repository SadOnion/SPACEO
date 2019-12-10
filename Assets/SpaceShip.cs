using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour,IOrbitable
{
    Transform orbit;
    [SerializeField]MoveForward mover = null;

    public void Deorbit()
    {
        transform.parent = null;
        Vector3 dir = transform.position - orbit.position;
        float angle = Mathf.Atan2(dir.y, dir.x);
        transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg-90);
        mover.StartMoving();
        Debug.Log("d");
    }

    public void Oribt(Transform thing)
    {
        Vector3 dir =transform.position - thing.position;
        dir.Normalize();
        float angle = 0;
        if (dir.y < 0) angle += 180;
        angle+=Vector3.Angle(Vector3.right, dir.normalized);
        orbit = thing;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.parent = thing;
        mover.StopMoving();
        Debug.Log("o");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

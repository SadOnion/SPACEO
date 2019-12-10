using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpaceShip : MonoBehaviour,IOrbitable
{
    Transform orbit;
    [SerializeField]MoveForward mover = null;
    public OrbitEvent OnNewOrbit;
    public bool IsOrbiting{get;private set;}


    private void Start()
    {
        IsOrbiting=true;
        orbit=transform.parent;
    }
    public void Deorbit()
    {
        transform.parent = null;
        IsOrbiting=false;
        Vector3 dir = transform.position - orbit.position;
        float angle = Mathf.Atan2(dir.y, dir.x);
        transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg-90);
        mover.StartMoving();
    }

    public void Oribt(Transform thing)
    {
        IsOrbiting=true;
        Vector3 dir =transform.position - thing.position;
        dir.Normalize();
        float angle = 0;
        
        angle+=Vector3.Angle(Vector3.right, dir.normalized);
        orbit = thing;
        if (dir.y < 0) angle *= -1;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.parent = thing;
        
        transform.localPosition = transform.localPosition.normalized*2.85f;
        mover.StopMoving();
       OnNewOrbit?.Invoke(thing);
    }

  
}
[System.Serializable]
public class OrbitEvent:UnityEvent<Transform>{}
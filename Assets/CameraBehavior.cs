using System;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform  target;
    [Range(0,50)]
    public float smoothSpeed;
    public readonly float offset = 7;
    private Vector3 lastPosition;

    private void Start()
    {
        FindObjectOfType<SpaceShip>().OnNewOrbit.AddListener(ChangeTarget);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
            SmoothFollow();
        
    }
    public void ChangeTarget(Transform newTarget)
    {
        target=newTarget;
    }
    private void SmoothFollow()
    {
        Vector2 desiredPosition = target.transform.position + Vector3.right * offset ;
        Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = (Vector3)smoothedPosition + Vector3.forward * -10;
        transform.position = new Vector3(transform.position.x,0,-10);
    }

   
}

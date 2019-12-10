using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    [SerializeField]private Sprite[] randomSprite;
    SpriteRenderer sr;
    Rotate mv;
    // Start is called before the first frame update
    void Start()
    {
        mv = GetComponentInChildren<Rotate>();
        float n = Random.Range(0.3f,.6f);
        
        mv.transform.localScale = new Vector2(n,n);
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = randomSprite[Random.Range(0,randomSprite.Length)];
    }
    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,1f);
    }

}

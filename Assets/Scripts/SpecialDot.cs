using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDot : Dot
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Debug.Log("a");
        GameManager.Instance.ghostState = GameManager.GhostState.FRIGHTEN;
    }
}

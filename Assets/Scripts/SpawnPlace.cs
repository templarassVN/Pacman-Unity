using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlace : MonoBehaviour
{
    [SerializeField]
    Transform Gate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Ghost temp = collision.gameObject.GetComponent<Ghost>();
        if (temp != null)
        {
            if (temp.gameObject.transform.position.x == -2.205)
                temp.setDirection(Vector2.right);
            temp.changetarget(Gate);
            temp.isDead = false;  
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    bool _right;
    [SerializeField]
    Transform left;
    [SerializeField]
    Transform right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_right)
            collision.transform.position = left.position;
        else
            collision.transform.position =right.position;
    }
}

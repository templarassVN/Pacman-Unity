using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    float leng = 1f;
    CircleCollider2D mcollider2D;
    // Start is called before the first frame update
    void Start()
    {
        mcollider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool temp = Physics2D.BoxCast(mcollider2D.bounds.center, mcollider2D.bounds.size - new Vector3(0.15f, 0.15f, 0), 0f, Vector2.down, leng, 1 << 6);
        Debug.Log(temp);
        Debug.DrawRay(transform.position, Vector2.up*leng, Color.green);
    }
}

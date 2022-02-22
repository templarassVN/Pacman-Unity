using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour
{
    Rigidbody2D mRGbody;
    Animator mAnimator;
    CircleCollider2D mcollider2D;
    

    [SerializeField]
    float _speed = 5;
    [SerializeField]
    float cast_dis = 2f;
    
    float _X_dir = 1;
    float _Y_dir = 0;

    Vector2 nextDir = Vector2.right;
    Vector2 curDir = Vector2.right;
    // Start is called before the first frame update
    void Start()
    {
        mRGbody = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        mcollider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            _X_dir = 0; _Y_dir = 1;
        } else if (Input.GetKeyDown("s"))
        {
            _X_dir = 0; _Y_dir = -1;
        }
        else if (Input.GetKeyDown("a"))
        {
            _X_dir = -1; _Y_dir = 0;
        }
        else if (Input.GetKeyDown("d"))
        {
            _X_dir = 1; _Y_dir = 0;
        }
        
        mAnimator.SetFloat("X_dir", curDir.x);
        mAnimator.SetFloat("Y_dir", curDir.y);
        nextDir = new Vector2(_X_dir, _Y_dir);
        mRGbody.velocity = curDir * _speed ;

    }

    void FixedUpdate()
    {
        bool hit = Physics2D.BoxCast(mcollider2D.bounds.center, mcollider2D.bounds.size - new Vector3(0.1f,0.1f,0), 0f,nextDir, cast_dis, 1<<6);
        if (!hit)
        {
            if (!curDir.Equals( nextDir))
                curDir = nextDir;
        }
    }

    

}

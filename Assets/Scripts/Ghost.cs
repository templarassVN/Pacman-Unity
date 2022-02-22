using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    Rigidbody2D mRGbody;
    Animator mAnimator;
    CircleCollider2D mcollider2D;

    Vector2[] DIRECTION = new Vector2[] { Vector2.up, Vector2.left, Vector2.down, Vector2.right };
    [SerializeField]
    Transform tPacman;
    [SerializeField]
    Transform tWander;
    Transform target;
    [SerializeField]
    float _speed = 5f;

   
    Vector2 curDir = Vector2.right;
    Vector2 nextDir = Vector2.right;
    Vector2 preDir = Vector2.zero;
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
        mAnimator.SetFloat("x_Dir", curDir.x);
        mAnimator.SetFloat("y_Dir", curDir.y);
        mRGbody.velocity = curDir * _speed;
        if (Input.GetKeyDown("e"))
            mAnimator.speed = 2f;
    }

    private void FixedUpdate()
    {
        switch (GameManager.Instance.ghostState)
        {
            case GameManager.GhostState.SCATTER:
                mAnimator.SetBool("frighten", false);
                target = tWander;
                Normal();
                break;
            case GameManager.GhostState.CHASE:
                mAnimator.SetBool("frighten", false);
                target = tPacman;
                Normal();
                break;
            case GameManager.GhostState.FRIGHTEN:
                target = tPacman;
                mAnimator.SetBool("frighten", true);
                Flee();
                break;
        }
        
    }

    

    bool isDirOcupied(Vector2 dir)
    {
        if(dir == Vector2.down)
        {
            if ((transform.position.x > -1.5 && transform.position.x < 3.5) &&
                (transform.position.y > 8 && transform.position.y < 10.5))
                return true;
        }
        return Physics2D.BoxCast(mcollider2D.bounds.center, mcollider2D.bounds.size - new Vector3(0.1f, 0.1f, 0), 0f, dir, 2f, 1 << 6);
    }

    void Normal()
    {
        float min_distant = float.MaxValue;
        foreach (Vector2 dir in DIRECTION)
        {
            if (!dir.Equals(-1 * preDir) && !isDirOcupied(dir))
            {
                float temp = (transform.position + (Vector3)dir * 0.05f - target.position).sqrMagnitude;
                if (temp < min_distant)
                {
                    min_distant = temp;
                    nextDir = dir;
                }
            }
        }
        curDir = nextDir;
        preDir = curDir;
    }

    void Flee()
    {
        float max_distant = float.MinValue;
        foreach (Vector2 dir in DIRECTION)
        {
            if (!dir.Equals(-1 * preDir) && !isDirOcupied(dir))
            {
                float temp = (transform.position + (Vector3)dir * 0.05f - target.position).sqrMagnitude;
                if (temp > max_distant)
                {
                    max_distant = temp;
                    nextDir = dir;
                }
            }
        }
        curDir = nextDir;
        preDir = curDir;
    }
}

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
    [SerializeField]
    Transform tSpawn;
    [SerializeField]
    Transform target;
    [SerializeField]
    float _speed = 5f;

    Vector2 curDir = Vector2.right;
    Vector2 nextDir = Vector2.right;
    Vector2 preDir = Vector2.zero;
    // Start is called before the first frame update

    bool frighten = false;
    [SerializeField]
    bool dead = false;
    bool free = false;
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

    public bool isFrighten
    {
        get { return frighten; }
        set { frighten = value; }
    }

    public bool isDead
    {
        get { return dead; }
        set { dead = value; }
    }

    public bool isFree
    {
        get { return free; }
        set { free = value; }
    }
    
    private void FixedUpdate()
    {
        
        if (!isDead)
            {
                switch (GameManager.Instance.ghostState)
                {
                    case GameManager.GhostState.SCATTER:
                        frighten = false;
                        target = tWander;
                        Normal();
                        break;
                    case GameManager.GhostState.CHASE:
                        frighten = false;
                        target = tPacman;
                        Normal();
                        break;
                    case GameManager.GhostState.FRIGHTEN:
                        target = tPacman;
                        frighten = true;
                        Flee();
                        break;
                }
                mAnimator.SetBool("frighten", frighten);
                mAnimator.SetBool("Die", dead);
            
            }
            else
            {
                frighten = false;

                mAnimator.SetBool("Die", dead);
                BacktoSpawn();
            
        }
        
        
        
    }

    bool isDirOcupied(Vector2 dir)
    {
        if(!dead && dir == Vector2.down)
        {
            if ((transform.position.x > -1.5 && transform.position.x < 3.5) &&
                (transform.position.y > 8 && transform.position.y < 10.5))
                return true;
        }
        return Physics2D.BoxCast(mcollider2D.bounds.center, mcollider2D.bounds.size - new Vector3(0.15f, 0.15f, 0), 0f, dir, 1f, 1 << 6);
    }

    void Normal()
    {
        float min_distant = float.MaxValue;
        foreach (Vector2 dir in DIRECTION)
        {
           
            if (!dir.Equals(-preDir) && !isDirOcupied(dir))
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

    void BacktoSpawn()
    {
        target = tSpawn;
        Normal();
    }

    public void Refresh(float speed = 5)
    {
        preDir = Vector2.zero;
        _speed = speed;
    }

    public void setDirection(Vector2 dir)
    {
        curDir = dir;
    }

    public void changetarget(Transform tar)
    {
        target = tar;
    }
}

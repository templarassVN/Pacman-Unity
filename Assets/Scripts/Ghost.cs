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
        Debug.Log(preDir);
        mRGbody.velocity = curDir * _speed;
    }

    private void FixedUpdate()
    {
        float temp = (transform.position  - target.position).sqrMagnitude;
        if (temp > 0.1)
            BacktoSpawn();

    }

    bool isDirOcupied(Vector2 dir)
    {
        return Physics2D.BoxCast(mcollider2D.bounds.center, mcollider2D.bounds.size - new Vector3(0.1f, 0.1f, 0), 0f, dir, 2f, 1 << 6);
    }

    void BacktoSpawn()
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
}

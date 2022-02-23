using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int level = 1;
    [SerializeField]
    float _Chasetime = 7f;
    [SerializeField]
    float _Scattertime = 7f;
    [SerializeField]
    float _Frightnentime = 7f;
    [SerializeField]
    float _CD = 0f;
    public enum GhostState { FRIGHTEN, CHASE, SCATTER };
    GhostState _ghost_State;
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _ghost_State = GhostState.SCATTER;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ghostState);
    }
    private void FixedUpdate()
    {
        _CD += Time.fixedDeltaTime;
        switch (_ghost_State)
        {
            case GhostState.CHASE:
                if (_CD > _Chasetime)
                {
                    _ghost_State = GhostState.SCATTER;
                    _CD = 0f;
                }
                break;

            case GhostState.SCATTER:
                if (_CD > _Scattertime)
                {
                    _ghost_State = GhostState.CHASE;
                    _CD = 0f;
                }
                break;
            case GhostState.FRIGHTEN:
                if (_CD > _Frightnentime)
                {
                    _ghost_State = GhostState.CHASE;
                    _CD = 0f;
                }
                break;
        }
    }
    public GhostState ghostState
    {
        get { return _ghost_State; }
        set { _ghost_State = value; }
    }
}

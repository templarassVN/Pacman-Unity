using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int _level = 1;
    int _currScore = 0;
    [SerializeField]
    float _Chasetime = 7f;
    [SerializeField]
    float _Scattertime = 7f;
    [SerializeField]
    float _Frightnentime = 7f;
    [SerializeField]
    float _CD = 0f;

    [SerializeField]
    Text uCurrScore;
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

    public int currScore
    {
        get { return _currScore; }
        set { _currScore = value; }
    }

    public int Level
    {
        get { return _level; }
        set { _level = value; }
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
        uCurrScore.text = string.Format("{0:D6}", _currScore);
    }
    public GhostState ghostState
    {
        get { return _ghost_State; }
        set { _ghost_State = value; }
    }

    
}

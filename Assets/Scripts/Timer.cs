using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    int _duration = 80;
    int _remain;
    [SerializeField]
    Text uiDisplay;
    bool pause = false;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        SetDuration(80);
        Begin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetTimer()
    {
        _remain = _duration;
        uiDisplay.text = string.Format("{0:D2}:{1:D2}", _remain / 60, _remain % 60);
        
    }
    
    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    public void SetDuration(int dur)
    {
        _duration = _remain = dur;    
    }

    public void End()
    {
        ResetTimer();
    }

    public void Pause()
    {
        pause = true;
    }

    public void Resumse()
    {
        pause = false;
    }

    IEnumerator UpdateTimer()
    {
        Debug.Log(_remain);
        while (!pause &&_remain >= 0)
        {
            
            uiDisplay.text = string.Format("{0:D2}:{1:D2}", _remain / 60, _remain % 60);
            _remain--;
            yield return new WaitForSeconds(1);
        }
        End();
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int amount = 200;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("b");
        GameManager.Instance.currScore += amount;
        Destroy(gameObject);
    }
}

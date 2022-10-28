using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverThreshold : MonoBehaviour
{
    [SerializeField] bool isOverThreshold = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKey("q"))
        {
            isOverThreshold = true;
        }
        else 
        {
            isOverThreshold = false;
        }
        FindObjectOfType<RaceLakeController>().UpdatePosition(isOverThreshold);
        //FindObjectOfType<PacManMenagere>().UpdatePosition(isOverThreshold);
    }
}

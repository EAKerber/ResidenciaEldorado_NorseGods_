using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
    public GameObject arrow; 
    public float duration = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        arrow = GetComponent<ArrowDestroy>().gameObject;
        DestroyArrow(arrow, duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyArrow(GameObject arrow, float duration)
    {
        Destroy(arrow, duration);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(arrow);
    }
}

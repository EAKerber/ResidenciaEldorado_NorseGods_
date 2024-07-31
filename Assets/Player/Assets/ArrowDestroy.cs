using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
    public GameObject arrow; 
    public float duration = 5.0f;
    public int EnemyLayer;
    [SerializeField] public int baseDamage = 5;

    // Start is called before the first frame update
    void Start()
    {
        arrow = GetComponent<ArrowDestroy>().gameObject;
        DestroyArrow(arrow, duration);
        EnemyLayer = LayerMask.NameToLayer("Enemy");
    }

    public void DestroyArrow(GameObject arrow, float duration)
    {
        Destroy(arrow, duration);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == EnemyLayer)
        {
            collision.gameObject.GetComponent<Vida>().dano(baseDamage);
        }
        Destroy(arrow);
    }
}

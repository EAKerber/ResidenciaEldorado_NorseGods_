using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
   public Vida vida;

    [SerializeField] private int danoBase = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            vida = collision.gameObject.GetComponent<Vida>();
            vida.dano(danoBase);
        }
    }
}

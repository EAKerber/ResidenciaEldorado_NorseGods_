using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class Vida : MonoBehaviour
{
    private int vidaAtual;
    [SerializeField]private int vidaTotal = 100;

    public int VidaAtual
    {
        get
        {
            return vidaAtual;
        }
    }

    public int VidaTotal
    {
        get
        {
            return vidaTotal;
        }
    }

    [SerializeField] private UnityEvent evento_inicia_vida;
    [SerializeField] private UnityEvent evento_dano;
    [SerializeField] private UnityEvent evento_fim_vida;


    [SerializeField] private BarraVida barraVida;

    void Start()
    {
        vidaAtual = vidaTotal;
        evento_inicia_vida?.Invoke();

    }


    // Update is called once per frame
    void Update()
    {
      
    }

    public void dano(int i) { 
        vidaAtual -= i;
        evento_dano?.Invoke();

        if (vidaAtual <= 0)
        {
            evento_fim_vida?.Invoke();
        }
    }
}

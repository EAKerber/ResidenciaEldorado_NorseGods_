using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Vida : MonoBehaviour
{
    private int vidaAtual;
    private int vidaTotal = 100;

    [SerializeField] private BarraVida barraVida;
    void Start()
    {
        vidaAtual = vidaTotal;
        barraVida.AlterarBarraVida(vidaAtual, vidaTotal);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dano(10);
        }
    }

    private void dano(int i) { 
        vidaAtual -= 10;
        barraVida.AlterarBarraVida(vidaAtual, vidaTotal);
    }
}

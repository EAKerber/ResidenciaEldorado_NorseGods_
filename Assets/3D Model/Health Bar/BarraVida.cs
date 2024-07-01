using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [SerializeField] private Image barraVidaImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AlterarBarraVida(int vidaAtual, int vidaMaxima)
    {
        barraVidaImage.fillAmount = (float)vidaAtual / vidaMaxima;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [SerializeField] Vida vida;
    [SerializeField] private Image barraVidaImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AlterarBarraVida()
    {
        barraVidaImage.fillAmount = (float)vida.VidaAtual / vida.VidaTotal;
    }
}

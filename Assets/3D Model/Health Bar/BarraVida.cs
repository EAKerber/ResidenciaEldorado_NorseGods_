using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [SerializeField] Vida vida;
    [SerializeField] private Image barraVidaImage;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, 
                         Camera.main.transform.rotation * Vector3.up);
    }


    public void AlterarBarraVida()
    {
        barraVidaImage.fillAmount = ((float)vida.VidaAtual / (float)vida.VidaTotal);
    }
    
    public void MatarInimigo(GameObject objeto){
        scoreManager.instance.setEnemyCount();
         Destroy(objeto);
    }
}

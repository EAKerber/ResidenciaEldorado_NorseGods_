using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [SerializeField] Vida vida;
    [SerializeField] private Image barraVidaImage;
    [SerializeField] private Sprite barraVidaImageAmarelo;
    [SerializeField] private Sprite barraVidaImageVerde;

    private Sprite spriteVermelhoOriginal;

    [SerializeField] private bool isStatic = false; 
    [SerializeField] private bool canChangeColor = false; 

    private bool isFirstTime = true;

    private float lastTimeShown;
    private float cooldown;

    void Start(){
        cooldown = 1.5f;
        lastTimeShown = Time.time;
        spriteVermelhoOriginal = barraVidaImage.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, 
                         Camera.main.transform.rotation * Vector3.up);
        if(!isStatic){
            FadeDelay(cooldown);
        }
    }


    public void AlterarBarraVida()
    {
        gameObject.SetActive(true);
        lastTimeShown = Time.time;
        float fillAmount = ((float)vida.VidaAtual / (float)vida.VidaTotal);
        barraVidaImage.fillAmount = fillAmount;
        if(canChangeColor){
            AtualizarCorDaBarra(fillAmount);
        }
    }

    private void AtualizarCorDaBarra(float fillAmount)
    {
        if (fillAmount > 0.8f)
        {
            barraVidaImage.sprite = barraVidaImageVerde;
        }
        else if (fillAmount > 0.4f)
        {
            barraVidaImage.sprite = barraVidaImageAmarelo;
        }
        else
        {
            barraVidaImage.sprite = spriteVermelhoOriginal;
        }

        barraVidaImage.type = Image.Type.Filled;
    }

    public void FadeDelay(float delay){
        if((Time.time - lastTimeShown) >= delay){
            gameObject.SetActive(false);
        }
    }

    public void SetActiveToFalse(){
        gameObject.SetActive(false);
    }
    
    public void MatarInimigo(GameObject objeto){
        scoreManager.instance.setEnemyCountText();
        scoreManager.instance.setEnemiesKilledCount();
        Destroy(objeto);
    }
}

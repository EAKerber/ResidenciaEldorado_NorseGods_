using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [SerializeField] Vida vida;
    [SerializeField] private Image barraVidaImage;
    [SerializeField] private bool isStatic = false; 
    private bool isFirstTime = true;

    private float lastTimeShown;
    private float cooldown;

    void Start(){
        cooldown = 1.5f;
        lastTimeShown = Time.time;
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
        /*if(isFirstTime && !isStatic){
            gameObject.SetActive(false);
            isFirstTime = false;
        }else{
            gameObject.SetActive(true);
        }*/

        gameObject.SetActive(true);
        lastTimeShown = Time.time;
        barraVidaImage.fillAmount = ((float)vida.VidaAtual / (float)vida.VidaTotal);
    }

    public void FadeDelay(float delay){
        //Debug.Log((Time.time - lastTimeShown));
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public GameObject l_Inimigo; // Refer ncia ao prefab do inimigo
    public GameObject b_Inimigo; // Referencia ao prefab do boss
    public Transform spawnPoint;   // Refer ncia ao ponto de spawn
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 5f); // Spawna um inimigo a cada 2 segundos (ajuste conforme necess rio)
    }


    void SpawnEnemy()
    {

        //Checa se o numero de inimigos vivos é igual a zero
        if(scoreManager.instance.isAllEnemiesKilled()){
            CancelInvoke();
            SpawnBoss();
            return;
        }

        //checando se o numero de imigos spawnado é menor que o maximo
        if(!scoreManager.instance.isMaxEnemiesSpawned()){
            
            //Adiciona 1 ao numero de inimigos criados
            scoreManager.instance.setEnemiesSpawnedCount();

            // Instancia um inimigo no ponto de spawn com a posi  o e rota  o padr o
            Instantiate(l_Inimigo, transform.position, Quaternion.identity);
        }
        
    }

    //Controla se um boss já foi spawnado e spawna um se não
    void SpawnBoss(){
        if(!scoreManager.instance.wasBossSpawned()){
            scoreManager.instance.setBossSpawned();
            Instantiate(b_Inimigo, transform.position, Quaternion.identity);
        }   
    }

}
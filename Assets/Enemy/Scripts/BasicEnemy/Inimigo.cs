using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{

    public GameObject l_Inimigo; // Refer ncia ao prefab do inimigo
    public Transform spawnPoint;   // Refer ncia ao ponto de spawn
    [SerializeField] public float tempoDeSpawn = 10f;
    [SerializeField] public float loadSceneDelay = 10f;
    [SerializeField] private string bossLevel;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, tempoDeSpawn); // Spawna um inimigo a cada 2 segundos (ajuste conforme necess rio)
    }


    void SpawnEnemy()
    {

        //Checa se o numero de inimigos vivos é igual a zero
        if(scoreManager.instance.isAllEnemiesKilled()){
            CancelInvoke();
            GoToBossRoom();
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
    void GoToBossRoom(){
        if(!scoreManager.instance.wasBossSpawned()){
            scoreManager.instance.setBossSpawned();

            // Inicia a corrotina para carregar a cena após o atraso
            StartCoroutine(LoadSceneAfterDelay(loadSceneDelay, bossLevel));
        }   
    }

    private IEnumerator LoadSceneAfterDelay(float delay, string scene)
    {
        // Espera pelo tempo especificado
        yield return new WaitForSecondsRealtime(delay);

        //Volta o tempo do jogo ao normal
        Time.timeScale = 1f;

        //muda o texto para o encontro com o boss

        scoreManager.instance.setBossText();

        // Carrega a cena
        SceneManager.LoadScene(scene);
    }

}
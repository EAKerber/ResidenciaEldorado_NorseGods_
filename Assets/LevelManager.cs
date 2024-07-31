using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    

    [SerializeField] private string mainMenu;
    [SerializeField] private Canvas canvasDeDerrota;
    [SerializeField] private float loadSceneDelay = 5f;

    private void Awake() {
        // Verifica se já existe uma instância do LevelManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // Se já houver uma instância, destrua esta nova
            Destroy(gameObject);
        }
    }

    public void VoltarAoMenu(){

        //Congela o tempo do jogo
        Time.timeScale = 0f;

        //Torna visivel o texto de derrota
        canvasDeDerrota.gameObject.SetActive(true);

        // Inicia a corrotina para carregar a cena após o atraso
        StartCoroutine(LoadSceneAfterDelay(loadSceneDelay, mainMenu));
    }

    public void VitoriaVoltarMenu(){
        StartCoroutine(LoadSceneAfterDelay(loadSceneDelay, mainMenu));
    }

    private IEnumerator LoadSceneAfterDelay(float delay, string scene)
    {
        // Espera pelo tempo especificado
        yield return new WaitForSecondsRealtime(delay);

        //Volta o tempo do jogo ao normal
        Time.timeScale = 1f;

        //Destroi o scoremanager para poder reiniciar o jogo
        Destroy(scoreManager.instance.gameObject);

        // Carrega a cena
        SceneManager.LoadScene(scene);
    }
}
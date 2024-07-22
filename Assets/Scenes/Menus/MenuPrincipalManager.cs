using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevel;

    public void Jogar(){
        SceneManager.LoadScene(nomeDoLevel);
    }

    public void SairJogo(){
        Debug.Log("saindo do jogo");
        Application.Quit();
    }
}

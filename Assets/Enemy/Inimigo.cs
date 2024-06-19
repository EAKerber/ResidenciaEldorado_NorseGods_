using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public GameObject l_Inimigo; // Refer�ncia ao prefab do inimigo
    public Transform spawnPoint;   // Refer�ncia ao ponto de spawn
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 5f); // Spawna um inimigo a cada 2 segundos (ajuste conforme necess�rio)
    }


    void SpawnEnemy()
    {
        // Instancia um inimigo no ponto de spawn com a posi��o e rota��o padr�o
        Instantiate(l_Inimigo, transform.position, Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        if(scoreManager.instance.checkEnemyCount()){
            CancelInvoke();
        }
    }
}

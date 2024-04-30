using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public GameObject l_Inimigo; // Referência ao prefab do inimigo
    public Transform spawnPoint;   // Referência ao ponto de spawn
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 5f); // Spawna um inimigo a cada 2 segundos (ajuste conforme necessário)
    }


    void SpawnEnemy()
    {
        // Instancia um inimigo no ponto de spawn com a posição e rotação padrão
        Instantiate(l_Inimigo, transform.position, Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

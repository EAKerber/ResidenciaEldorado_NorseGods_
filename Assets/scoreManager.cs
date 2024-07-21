using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;
    
    public Text enemyCountText;

    [SerializeField] private int roundMaxEnemyCount = 20;
    private int enemyCount = 0;
    private int enemiesSpawned = 0;
    private int enemiesKilled = 0;

    bool bossSpawned = false;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = roundMaxEnemyCount;
        enemyCountText.text = "Inimigos restantes: " + enemyCount.ToString();
    }

    public void setEnemyCountText(){
        if(enemyCount > 1){
            enemyCount--;
            enemyCountText.text = "Inimigos restantes: " + enemyCount.ToString();
        }else{
            enemyCountText.text = "Vitória!!! Área Conquistada";
        }
    }

    public void setEnemiesSpawnedCount(){
        enemiesSpawned++;
    }

    public void setEnemiesKilledCount(){
        enemiesKilled++;
    }

    public void setBossSpawned(){
        bossSpawned = true;
    }

    public bool wasBossSpawned(){
        return bossSpawned;
    }

    public bool isAllEnemiesKilled(){
        bool isEnemiesKilledEqualMax = enemiesKilled == roundMaxEnemyCount;
        if (isEnemiesKilledEqualMax){
            return true;
        }

        return false;
    }

    public bool isMaxEnemiesSpawned(){
        bool isEnemiesSpawnedEqualMax = enemiesSpawned == roundMaxEnemyCount;
        if (isEnemiesSpawnedEqualMax){
            return true;
        }

        return false;
    }

}
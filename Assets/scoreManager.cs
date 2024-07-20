using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;
    
    public Text enemyCountText;

    [SerializeField] int roundMaxEnemyCount = 20;
    int enemyCount = 0;
    int currentEnemyCount = 0;

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

    public void setEnemyCount(){
        if(enemyCount > 1){
            enemyCount--;
            enemyCountText.text = "Inimigos restantes: " + enemyCount.ToString();
        }else{
            enemyCountText.text = "Vitória!!! Área Conquistada";
        }
    }

    public void setCurrentEnemyCount(){
        currentEnemyCount++;
    }

    public void setBossSpawned(){
        bossSpawned = true;
    }

    public bool wasBossSpawned(){
        return bossSpawned;
    }

    public bool checkEnemyCount(){
        if (enemyCount > 1){
            return false;
        }

        return true;
    }

    public bool checkEnemyMaxCount(){
        if (currentEnemyCount < roundMaxEnemyCount){
            return false;
        }

        return true;
    }

}
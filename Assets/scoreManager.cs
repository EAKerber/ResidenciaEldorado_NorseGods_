using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;
    
    public Text enemyCountText;

    int enemyCount = 20;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
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

    public bool checkEnemyCount(){
        if (enemyCount > 1){
            return false;
        }

        return true;
    }

}

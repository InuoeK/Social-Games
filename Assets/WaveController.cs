using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WaveController : MonoBehaviour
{

    Text enemiesLeft;

    int enemiesToKill;
    int enemiesInWave;
    int enemiesSpawned;
    int waveNumber;

    bool waveClear;

    float spawnDelay;

    // Use this for initialization
    void Start()
    {
        spawnDelay = 0.75f;
        enemiesToKill = enemiesInWave = waveNumber = 0;

        enemiesLeft = GameObject.Find("EnemiesLeft").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<GameState>().GetInBattle())
        {
            UpdateEnemiesLeftText();
            SpawnEnemy();
        }

        if (CheckIfWaveOver() && this.gameObject.GetComponent<GameState>().GetInBattle())
        {
            this.gameObject.GetComponent<GameState>().SetInBattle(false);
            GameObject.Find("GameController").GetComponent<ShowHideMenu>().ShowMenu("shop");
        }
        Debug.Log(spawnDelay);
    }

    void UpdateEnemiesLeftText()
    {
        enemiesLeft.text = "Enemies Left: " + enemiesToKill;
    }

    public void NewWave()
    {
        waveNumber++;
        enemiesInWave = waveNumber * 2;
        enemiesToKill = enemiesInWave;
        enemiesSpawned = 0;
    }

    void SpawnEnemy()
    {
        if (spawnDelay <= 0.0f)
        {
            if (Random.Range(1, 100) < 20)
                if (enemiesSpawned < enemiesToKill)
                {
                    this.gameObject.GetComponent<SpawnModule>().SpawnCircleEnemy();
                    enemiesSpawned++;
                    spawnDelay = Random.Range(10, 40) / 10.0f;
                    Debug.Log("EnemySpawned");
                }
        }
        else
            spawnDelay -= Time.deltaTime;
    }

    public void KilledEnemy()
    {
        enemiesToKill--;
    }

    bool CheckIfWaveOver()
    {
        if (enemiesToKill == 0)
            return true;
        else
            return false;
    }

}

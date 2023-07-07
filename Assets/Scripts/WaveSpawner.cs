using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float TimeBetweenWaves = 5f;
    private float countdown = 2f;

    [SerializeField] Text waveCountdownText;

    private int waveIndex = 1;

    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());           
            countdown = TimeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for(int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

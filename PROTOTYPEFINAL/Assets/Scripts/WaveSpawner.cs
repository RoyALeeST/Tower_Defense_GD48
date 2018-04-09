using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

public GameObject enemyPrefab;
public Transform spawnPoint;
private float countDownTimer = 2f;
public float timeBetweenWaves = 5f;

public Text waveCountText;

[SerializeField]
private float delayBetweenEnemies = 0.5f;
private int waveIndex = 0;
	void Update()
	{
		if(countDownTimer <= 0){
			StartCoroutine(SpawnWave());
			countDownTimer = timeBetweenWaves;
		}

		countDownTimer -= Time.deltaTime; //decrease each second
		//Round the number to cut decimals, then transform it to a string;
		countDownTimer = Mathf.Clamp(countDownTimer, 0f, Mathf.Infinity);
		waveCountText.text = string.Format("{0:00.00}",countDownTimer);
	}

	//Coroutine that executes this code outside of our main function time frame
	IEnumerator SpawnWave(){
		PlayerStats.rounds++;
		waveIndex++;
		for (int i = 0; i < waveIndex; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(delayBetweenEnemies);
		}
		

	}

	void SpawnEnemy(){
		GameObject enemy = Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
        enemy.gameObject.tag = "Enemy";
    }
}

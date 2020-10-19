using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> spawnPositions = new List<Transform>();
    public List<GameObject> enemyObjects = new List<GameObject>();

    public float spawnInternal;
    private float timePassed;
    public int poolSize;
    private int count;

    public Slider levelSlider;

    void Start()
    {
        for (int i = 0; i < enemyObjects.Count; i++)
        {
            for (int j = 0; j < poolSize; j++)
            {
                GameObject go = Instantiate(enemyObjects[i], Vector3.zero, Quaternion.identity);
                go.transform.SetParent(transform);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.SharedInstance.isGameStarted)
        {
            return;
        }

        if (timePassed >= spawnInternal)
        {
            count++;
            if (!SliderStepManager.SharedInstance.isSliderOneCompleted)
            {
                if (count <= 20)
                {
                    if (count == 20)
                    {
                        SliderStepManager.SharedInstance.isSliderOneCompleted = true;
                        Debug.Log("**** isSliderOneCompleted " + SliderStepManager.SharedInstance.isSliderOneCompleted);
                        Enemy.SharedInstance.speed = 250;
                        count = 0;
                        levelSlider.value = 30;
                    }
                    SpawnEnemy();
                }
            }
            
            if (!SliderStepManager.SharedInstance.isSliderTwoCompleted && SliderStepManager.SharedInstance.isSliderOneCompleted)
            {
                if (count <= 40)
                {
                    if (count == 40)
                    {
                        
                        SliderStepManager.SharedInstance.isSliderTwoCompleted = true;
                        Debug.Log("**** isSliderTwoCompleted " + SliderStepManager.SharedInstance.isSliderTwoCompleted);
                        Enemy.SharedInstance.speed = 450;
                        count = 0;
                        levelSlider.value = 60;
                    }
                    SpawnEnemy();
                }
            }

            if (!SliderStepManager.SharedInstance.isSliderThreeCompleted && SliderStepManager.SharedInstance.isSliderTwoCompleted)
            {
                if (count <= 60)
                {
                    if (count == 60)
                    {
                        SliderStepManager.SharedInstance.isSliderThreeCompleted = true;
                        Debug.Log("**** isSliderThreeCompleted " + SliderStepManager.SharedInstance.isSliderThreeCompleted);
                        count = 0;
                        levelSlider.value = 90;
                    }
                    SpawnEnemy();
                }
            }
            timePassed = 0;
        }
        else
        {
            timePassed += Time.deltaTime;

        }
    }

    private void SpawnEnemy()
    {
        Debug.Log("Spawn enemy çalıştı");
        GameObject enemy = GetAvailableEnemy();
        enemy.transform.position = spawnPositions[Random.Range(0, spawnPositions.Count)].position;
        enemy.SetActive(true);
    }

    private GameObject GetAvailableEnemy()
    {
        GameObject _enemy = null;

        foreach (Transform enemy in transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                _enemy = enemy.gameObject;
            }
        }

        return _enemy;
    }
}

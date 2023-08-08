using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject SpawnObj;
    private float _spawnTime;
    private bool isPause = true;

    private void OnEnable()
    {
        EventBus.startGame += Started;
        EventBus.finishGame += Finished;
    }

    private void OnDisable()
    {
        EventBus.startGame -= Started;
        EventBus.finishGame -= Finished;
    }

    void Start()
    {
        _spawnTime = Random.Range(2, 6);
    }

    
    void Update()
    {
        if (!isPause)
        {
            _spawnTime -= Time.deltaTime;
            if (_spawnTime <= 0)
            {
                Instantiate(SpawnObj, transform.position, Quaternion.identity);
                _spawnTime = Random.Range(2, 6);
            }
        }
    }

    public void Started()
    {
        isPause = false;
    }

    public void Finished()
    {

    }
}

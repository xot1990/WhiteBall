using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    public float spawnTime = 0.05f;
    public GameObject spawnObj;
    public Rigidbody2D body;
    public int currentNum;

    public bool isPresh;
    private bool isPause = true;

    public GuiPointerListener listener;

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

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

        listener.OnDown += data => { isPresh = true; };
        listener.OnUp += data => { isPresh = false; };

        if (Pool.CometPool.Count != 0)
            Pool.CometPool.Clear();

        for(int i = 0; i < 50; i++)
        {
            GameObject G = Instantiate(spawnObj, transform.position, Quaternion.identity);
            Pool.CometPool.Add(G);
            G.SetActive(false);
        }
    }

    void Update()
    {
        if (!isPause)
        {
            if (isPresh)
            {
                body.AddForce(Vector2.up * 10, ForceMode2D.Force);
            }

            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0)
            {
                if (currentNum >= Pool.CometPool.Count)
                    currentNum = 0;

                Pool.CometPool[currentNum].SetActive(true);
                Pool.CometPool[currentNum].transform.position = transform.position;
                spawnTime += 0.05f;
                currentNum++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Contains("Border") || collision.tag.Contains("Box"))
        {
            EventBus.GetFinished();
        }
    }

    public void Started()
    {
        body.gravityScale = 0.8f;
        isPause = false;
    }

    public void Finished()
    {

    }
}

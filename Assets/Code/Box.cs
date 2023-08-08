using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private List<int> dirs = new List<int> {-1,1 };

    public float dir;

    public bool isCanRewers = true;

    private bool isPause;

    private void OnEnable()
    {
        dir = dirs[Random.Range(0, 2)];
    }
    private void OnDisable()
    {
        
    }

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Contains("Border") && isCanRewers)
        {
            dir *= -1;
            isCanRewers = false;
            StartCoroutine(Rewers());
        }
    }

    public void Started()
    {

    }

    public void Finished()
    {

    }

    void Update()
    {
        if (!isPause)
        {
            transform.Translate(Vector2.up * dir * Time.deltaTime * 2);
            transform.Translate(Vector2.left * Time.deltaTime * 3);
        }
    }

    public IEnumerator Rewers()
    {
        yield return new WaitForSeconds(1);
        isCanRewers = true;
    }
}

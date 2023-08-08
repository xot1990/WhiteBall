using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    LayerMask mask;

    private void Awake()
    {
        mask = LayerMask.GetMask("Player");
    }

    void Start()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(-3, 3), transform.position.z);
    }

    
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * 3);
        CheckPlayer();
        Catch();
    }

    private void CheckPlayer()
    {
        if(Physics2D.OverlapCircle(transform.position,2,mask))
        {
            Transform player = Physics2D.OverlapCircle(transform.position, 2, mask).transform;

            transform.Translate((player.position - transform.position) * Time.deltaTime * 5);
        }
    }

    private void Catch()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.3f, mask))
        {
            EventBus.GetCatchPoint();
            Destroy(gameObject);
        }
    }
}

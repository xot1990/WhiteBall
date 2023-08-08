using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comet : MonoBehaviour
{
    public float lifeTime;
    SpriteRenderer Srenderer;
    public float scaleMulti;

    private void Awake()
    {
        Srenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(Deth());
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.localScale -= new Vector3(Time.deltaTime*scaleMulti, Time.deltaTime * scaleMulti, Time.deltaTime * scaleMulti);
        Srenderer.color -= new Color(0, 0, 0, Time.deltaTime * scaleMulti);

        transform.Translate(Vector2.left * Time.deltaTime*8);
    }

    public IEnumerator Deth()
    {
        yield return new WaitForSeconds(lifeTime);
        transform.localScale = Vector3.one;
        Srenderer.color = new Color(1, 1, 1, 1);
        gameObject.SetActive(false);
    }
}

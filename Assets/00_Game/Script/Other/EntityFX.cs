using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Material originMat;
    [SerializeField] private Material hitMat;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originMat = spriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator OnHitFx()
    {
        spriteRenderer.material = hitMat;
        yield return new WaitForSeconds(.2f);
        spriteRenderer.material = originMat;
    }

}

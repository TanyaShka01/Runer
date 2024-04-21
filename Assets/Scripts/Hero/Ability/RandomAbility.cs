
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAbility : MonoBehaviour
{
    public GameObject ModelRenderer;
    private void Awake()
    {
        float random = Random.Range(0f, 1f);
        switch (random)
        {
            case < 0.33f:
                gameObject.AddComponent<ShoesAbility>();
                break;
            case <= 0.66f:
                gameObject.AddComponent<JerkAbility>();
                break;
            case > 0.66f:
                gameObject.AddComponent<ShieldAbility>();
                break;
        }
        gameObject.GetComponent<BaseAbility>().ModelRenderer = ModelRenderer;
    }

}

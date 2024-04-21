using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseAbility : MonoBehaviour
{
    public GameObject ModelRenderer;
    public float Duration = 3;
    protected bool work = true;

    public event Action<BaseAbility> OnCollected;
    public event Action OnStoped;

    public virtual void Stop()
    {
        if (work == true)
        {
            work = false;
            OnStoped.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Activate(other.gameObject);
        }
    }
    
    protected virtual void Activate(GameObject Hero)
    {
        OnCollected.Invoke(this);
        ModelRenderer.SetActive(false);
    }
}

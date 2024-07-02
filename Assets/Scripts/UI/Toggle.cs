using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Toggle : MonoBehaviour, IPointerClickHandler
{
    public bool IsEnabled;
    public RectTransform Circle;
    public event Action<bool> OnSwitch;
    public void OnPointerClick(PointerEventData eventData)
    {
        IsEnabled = !IsEnabled;
        MoveCircle();
        OnSwitch?.Invoke(IsEnabled);
    }

    public void SwitchState(bool Enabled)
    {
        IsEnabled = Enabled;
        MoveCircle();
        OnSwitch?.Invoke(Enabled);
    }

    async void MoveCircle()
    {
        float FinishX = 0;
        if (IsEnabled == true)
        {
            FinishX = 60;
        }
        else 
        {
            FinishX = -60;
        }
        float Progres = 0;
        while (Progres < 1)
        {
            await UniTask.WaitForSeconds(0.03f);
            float CarentX = Mathf.Lerp(Circle.localPosition.x, FinishX, Progres);
            Circle.localPosition = new Vector2(CarentX, Circle.localPosition.y);
            Progres += 0.1f;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

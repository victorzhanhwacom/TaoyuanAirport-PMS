using System;
using UnityEngine;
using UnityEngine.Events;
using VzDev.ToolUtils;

public class PointTage_FocusBusManager : MonoBehaviour
{
    public PointTag_FocusBus[] pointTag_FocusBuses;
    public UnityEvent<Transform> OnFollowTarget;
    public UnityEvent CancelFollowTarget;

    
    public void GetAllPointTag_FocusBuses()
    {
        pointTag_FocusBuses = GetComponentsInChildren<PointTag_FocusBus>(true);
        foreach (var focusBus in pointTag_FocusBuses)
        {
            focusBus.OnToggleStateChanged += HandleToggleStateChanged;
        }
    }

    private void HandleToggleStateChanged(bool isOn, Transform targetModel)
    {
        if (isOn)
        {
            OnFollowTarget?.Invoke(targetModel.parent);
        }
        else
        {
            CancelFollowTarget?.Invoke();
        }
    }
}

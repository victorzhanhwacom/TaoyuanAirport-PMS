using System;
using UnityEngine;
using UnityEngine.Events;
using VzDev.ToolUtils;

public class PointTage_FocusBusManager : MonoBehaviour
{
    public PointTag_FocusBus[] pointTag_FocusBuses;
    public UnityEvent<Transform> OnFollowTarget;
    public UnityEvent<bool> OnToggleInfo;
    public UnityEvent CancelFollowTarget;

    
    public void GetAllPointTag_FocusBuses()
    {
        pointTag_FocusBuses = GetComponentsInChildren<PointTag_FocusBus>(true);
        foreach (var focusBus in pointTag_FocusBuses)
        {
            focusBus.OnToggleFollowTargetChanged += HandleToggleStateChanged;
            focusBus.OnToggleInfoChanged += HandleInfoToggleStateChanged;
        }
    }

    private void HandleInfoToggleStateChanged(bool isOn) => OnToggleInfo?.Invoke(isOn);

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

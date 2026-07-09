using System;
using UnityEngine;
using VzDev.ToolUtils;

public class PointTag_FocusBus : MonoBehaviour
{
    public event Action<bool, Transform> OnToggleFollowTargetChanged;
    public event Action<bool> OnToggleInfoChanged;
    public PointTag pointTag;
    public void SetFollowTargetToggleState(bool isOn)
    {
        OnToggleFollowTargetChanged?.Invoke(isOn, pointTag.FollowerTarget);
    }
    public void SetInfoToggleState(bool isOn)
    {
        OnToggleInfoChanged?.Invoke(isOn);
    }

    private void OnValidate()
    {
        if (pointTag == null)
            pointTag = GetComponent<PointTag>();
    }
}

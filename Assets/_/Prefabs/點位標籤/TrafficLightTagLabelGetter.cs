using UnityEngine;
using VzDev.ToolUtils;

public class TrafficLightTagLabelGetter : MonoBehaviour, IPointTagLabelGetter
{
    public string GetLabel(Transform targetModel)
    {
        if (targetModel == null)
        {
            Debug.LogWarning("Target model is null. Returning 'unknown' as label.", this);
            return "unknown";
        }
        if (targetModel.parent == null)
        {
            Debug.LogWarning($"Target model '{targetModel.name}' has no parent. Returning 'unknown' as label.", this);
            return "NoParent";
        }
        int index = Random.Range(1, 30);
        return $"交通號誌-{index:##}";
    }
}

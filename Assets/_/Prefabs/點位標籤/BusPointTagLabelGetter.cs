using UnityEngine;
using VzDev.ToolUtils;

public class BusPointTagLabelGetter : MonoBehaviour, IPointTagLabelGetter
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
        string parentName = targetModel.parent.name;
        int index = parentName.IndexOf("(");
        if (index != -1)
        {
            int roadNumber = Random.Range(1, 999);
            string roadType = Random.Range(0, 4) switch
            {
                0 => "綠",
                1 => "紅",
                2 => "藍",
                3 => "橘",
            };
            return $"{roadType}{roadNumber}";
            //return parentName.Substring(0, index) + $"-{roadType}{roadNumber}";
        }
        return parentName;
    }
}

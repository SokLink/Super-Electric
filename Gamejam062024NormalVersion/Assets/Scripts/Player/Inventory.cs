using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countProvodovText;

    public static int ProvodaCount { get; set; }

    private void Update()
    {
        countProvodovText.text = $"проводов: {ProvodaCount}";
    }
}

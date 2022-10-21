using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShootUI : MonoBehaviour
{
    [SerializeField] private Image shootProgressFilbar;
    [SerializeField] private TextMeshProUGUI shootIndexTxt;

    public void SetProgressFillbar(float progressVal)
    {
        shootProgressFilbar.fillAmount = 1f - progressVal;
    }
    public void SetShootIindex(int indexVal)
    {
        shootIndexTxt.SetText(indexVal.ToString());
    }
}
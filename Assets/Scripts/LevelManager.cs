using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("等級與經驗值介面")]
    public TextMeshProUGUI textLv;
    public TextMeshProUGUI textExp;
    public Image imgExp;
    [Header("等級上限"), Range(0, 500)]
    public int LvMax = 100;

    private int lv = 1;
    private float exp;

    public float[] expNeeds = { 100, 200, 300 };

    [ContextMenu("更新經驗值需求表")]
    private void UpdateExpNeeds()
    {
        expNeeds = new float[LvMax];

        for(int i = 0; i < LvMax; i++)
        {
            expNeeds[i] = (i + 1) * 100;
        }
    }

        /// <summary>
        /// 獲得經驗值
        /// </summary>
        /// <param name="getExp">取得經驗值浮點數</param>
    public void GetExp(float getExp)
    {
        exp += getExp;
        print($"<color=yellow>2; 當前經驗值:{ exp }</color>");

        if (exp >= expNeeds[lv - 1] && lv < LvMax)
        {
            exp -= expNeeds[lv - 1];
            lv++;
            textLv.text = $"Lv{lv}";
        }

        textExp.text = $"{exp} /{expNeeds[lv - 1]}";
        imgExp.fillAmount = exp / expNeeds[lv - 1];
    }
}

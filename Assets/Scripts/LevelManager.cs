using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("���ŻP�g��Ȥ���")]
    public TextMeshProUGUI textLv;
    public TextMeshProUGUI textExp;
    public Image imgExp;
    [Header("���ŤW��"), Range(0, 500)]
    public int LvMax = 100;

    private int lv = 1;
    private float exp;

    public float[] expNeeds = { 100, 200, 300 };

    [ContextMenu("��s�g��ȻݨD��")]
    private void UpdateExpNeeds()
    {
        expNeeds = new float[LvMax];

        for(int i = 0; i < LvMax; i++)
        {
            expNeeds[i] = (i + 1) * 100;
        }
    }

        /// <summary>
        /// ��o�g���
        /// </summary>
        /// <param name="getExp">���o�g��ȯB�I��</param>
    public void GetExp(float getExp)
    {
        exp += getExp;
        print($"<color=yellow>2; ��e�g���:{ exp }</color>");

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

using UnityEngine;

[CreateAssetMenu(menuName = "MASON/Data skill")]
public class DataSkill : ScriptableObject
{
    [Header("�ޯ�W��")]
    public string nameSkill;
    [Header("�ޯ�C�ӵ��żƭ�")]
    public float[] skillValues;
    [Header("�ޯ�ϥ�")]
    public Sprite iconSkill;
    [Header("�ޯ�y�z"), TextArea(3, 10)]
    public string description;

    public int lv = 1;
}

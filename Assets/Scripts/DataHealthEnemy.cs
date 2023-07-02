using UnityEngine;

[CreateAssetMenu(menuName = "ZMX/Data Health Enemy")]
public class DataHealthEnemy : DataHealth
{
    [Header("�����g��Ȫ���")]
    public GameObject prefabExp;
    [Header("�����g��Ⱦ��v"), Range(0, 1)]
    public float dropProbaility;
    [Header("�����O"), Range(0, 1000)]
    public float attack = 20;
    [Header("��������"),Range(0,5)]
    public float attackInterval = 2.5f;
    [Header("�����Z��"), Range(0, 10)]
    public float attackRange = 3;
}

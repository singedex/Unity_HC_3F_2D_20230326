using UnityEngine;

[CreateAssetMenu(menuName = "ZMX/Data Health Enemy")]
public class DataHealthEnemy : DataHealth
{
    [Header("�����g��Ȫ���")]
    public GameObject prefabExp;
    [Header("�����g��Ⱦ��v"), Range(0, 1)]
    public float dropProbaility;
}

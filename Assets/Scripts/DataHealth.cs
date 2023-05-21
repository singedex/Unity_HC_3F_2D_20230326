using UnityEngine;

[CreateAssetMenu(menuName = "ZMX/Data Health")]
public class DataHealth : ScriptableObject
{
    [Header("��q"), Range(1, 500)]
    public float hp = 50;
}

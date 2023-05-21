using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [Header("�ͦ�����"), Range(0, 10)]
    public float interval = 3.5f;
    [Header("�Z���w�m��")]
    public GameObject prefabWeapon;
    [Header("�Z���ͦ���m")]
    public Transform pointWeapon;

    private void SpwanWeapon()
    {
        Instantiate(prefabWeapon, pointWeapon.position, pointWeapon.rotation);
    }


    private void Awake()
    {
        InvokeRepeating("SpwanWeapon", 0, interval);
    }
}
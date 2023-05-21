using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [Header("生成間格"), Range(0, 10)]
    public float interval = 3.5f;
    [Header("武器預置物")]
    public GameObject prefabWeapon;
    [Header("武器生成位置")]
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
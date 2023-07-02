using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("����")]
    public Rigidbody2D rig;
    [Header("�Z���o�g�O�D")]
    public Vector2 power;
    [Header("�����O"), Range(0, 5000)]
    public float attack = 50;


    private void Awake()
    {

        rig.AddForce(power);
    }
}

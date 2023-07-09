using TMPro;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [Header("��q���")]
    public DataHealth data;
    [Header("�e���ˮ`��")]
    public GameObject prefabDamage;

    private float hp;


    private void Awake()
    {
        hp = data.hp;
    }
    public void GetDamage(float damage)
    {
        //print($"<color=ff6687>����ˮ` {damage}</color>");
        hp -= damage;
        GameObject tempDamage = Instantiate(prefabDamage, transform.position, transform.rotation);
        tempDamage.transform.Find("��r�ˮ`��").GetComponent<TextMeshProUGUI>().text = damage.ToString();
        Destroy(tempDamage, 1.5f);

        if (hp <= 0) Dead();
    }

    protected virtual void Dead()
    {
        
    }
}

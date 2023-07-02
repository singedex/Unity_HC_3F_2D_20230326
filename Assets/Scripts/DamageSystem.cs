using TMPro;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [Header("��q���")]
    public DataHealth data;
    [Header("�e���ˮ`��")]
    public GameObject prefabDamage;

    private float hp;

    private DataHealthEnemy dataEnemy;

    private void Awake()
    {
        hp = data.hp;
        dataEnemy = (DataHealthEnemy)data;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print(collision.gameObject);
        if(collision.gameObject.name.Contains("�Z��"))
        {
            float attack = collision.gameObject.GetComponent<Weapon>().attack;
            GetDamage(attack);
        }
    }

    private void GetDamage(float damage)
    {
        print($"<color=ff6687>����ˮ` {damage}</color>");
        hp -= damage;
        GameObject tempDamage = Instantiate(prefabDamage, transform.position, transform.rotation);
        tempDamage.transform.Find("��r�ˮ`��").GetComponent<TextMeshProUGUI>().text = damage.ToString();
        Destroy(tempDamage, 1.5f);

        if (hp <= 0) Dead();
    }

    private void Dead()
    {
        Destroy(gameObject);
        DropExp();
    }

    private void DropExp()
    {
        //print("�o���Ǫ��������g����v:" + dataEnemy.dropProbaility);
        if (Random.value <= dataEnemy.dropProbaility)
        {
            Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
        }
    }
}

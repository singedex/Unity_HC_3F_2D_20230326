using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [Header("��q���")]
    public DataHealth data;

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
            //print("PON!!");
            GetDamage();
        }
    }

    private void GetDamage()
    {
        hp -= 50;
        print("��q�ѤU:" + hp);

        if (hp <= 0) 
            Dead();
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

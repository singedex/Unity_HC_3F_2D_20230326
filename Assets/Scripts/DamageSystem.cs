using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [Header("血量資料")]
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
        if(collision.gameObject.name.Contains("武器"))
        {
            //print("PON!!");
            GetDamage();
        }
    }

    private void GetDamage()
    {
        hp -= 50;
        print("血量剩下:" + hp);

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
        //print("這隻怪物掉落的經驗機率:" + dataEnemy.dropProbaility);
        if (Random.value <= dataEnemy.dropProbaility)
        {
            Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
        }
    }
}

using UnityEngine;

public class DamageEnemy : DamageSystem
{
    private DataHealthEnemy dataEnemy;
    private void Start()
    {
        dataEnemy = (DataHealthEnemy)data;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print(collision.gameObject);
        if (collision.gameObject.name.Contains("武器"))
        {
            float attack = collision.gameObject.GetComponent<Weapon>().attack;
            GetDamage(attack);
        }
    }

    protected override void Dead()
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

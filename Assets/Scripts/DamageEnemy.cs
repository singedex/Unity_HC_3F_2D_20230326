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
        if (collision.gameObject.name.Contains("�Z��"))
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
        //print("�o���Ǫ��������g����v:" + dataEnemy.dropProbaility);
        if (Random.value <= dataEnemy.dropProbaility)
        {
            Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
        }
    }
}

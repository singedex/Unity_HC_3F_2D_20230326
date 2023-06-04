using UnityEngine;

public class ExpObject : MonoBehaviour
{
    [Header("可以吃這個物件名稱")]
    public string nameTarget = "犀牛";
    [Header("移動速度"), Range(0, 500)]
    public float moveSpeed = 3.5f;
    [Header("吃掉物件的距離"), Range(0, 5)]
    public float eatDistance = 1.5f;
    [Header("經驗值"), Range(0, 5000)]
    public float exp = 30;

    private Transform player;

    private bool playerInArea;

    private LevelManager levelManager;

    private void Awake()
    {
        player = GameObject.Find(nameTarget).transform;
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void Update()
    {
        if (playerInArea)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            float distance = Vector2.Distance(transform.position, player.position);
            if(distance < eatDistance)
            {
                levelManager.GetExp(exp);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print($"<color=#ff6699>{collision.name}</color");

        if (collision.name.Contains(nameTarget))
        {
            playerInArea = true;
        }
    }   
}

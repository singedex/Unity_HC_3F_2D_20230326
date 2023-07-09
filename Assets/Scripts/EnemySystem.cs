﻿using UnityEngine;

/// <summary>
/// 敵人系統
/// 1. 追蹤玩家
/// 2. 翻面
/// </summary>
public class EnemySystem : MonoBehaviour
{
    [Header("追蹤速度"), Range(0, 100)]
    public float moveSpeed = 3.5f;
    [Header("敵人資料")]
    public DataHealthEnemy data;

    public Transform player;
    private float timer;

	private void OnDrawGizmos()
	{
        Gizmos.color = new Color(1, 0.3f, 0.2f, 0.5f);
        Gizmos.DrawSphere(transform.position, data.attackRange);
	}

	private void Awake()
    {
        player = GameObject.Find("犀牛").transform;
    }

    // Update 一秒執行約 60 次
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        Attack();

        float distance = Vector3.Distance(transform.position, player.position);
        //print($"<=#ff9966>距離:{distance}</color>");

        if (distance < data.attackRange) Attack();

        if (transform.position.x > player.position.x) transform.eulerAngles = new Vector3(0, 0, 0);
        if (transform.position.x < player.position.x) transform.eulerAngles = new Vector3(0, 180, 0);
    }

    private void Attack()
    {
        timer += Time.deltaTime;
        //print($"<color=#99ff66>計時器 : {timer}</color");

        if (timer > data.attackInterval)
		{
            print("<color=#99ff66>攻擊玩家!</color>");
            timer = 0;
		}
	}
}

using UnityEngine;

public class playerui : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.Find("�R��").transform;
    }

    private void Update()
    {
        transform.position = player.position;
    }
}

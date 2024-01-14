using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private GameplaySettings gameplaySettings;
    [SerializeField] private Walls walls;
    [SerializeField] private TeamSide team;

    private Rigidbody2D _rb;

    public Rigidbody2D Rigidbody => _rb;

    public TeamSide Team => team;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, -walls.TopBotWalls / 2, walls.TopBotWalls / 2);

        if (team == TeamSide.Left)
            position.x = Mathf.Clamp(position.x, -walls.SideWalls / 2f,  -gameplaySettings.MidBarrierWidth / 2f);
        else
            position.x = Mathf.Clamp(position.x, gameplaySettings.MidBarrierWidth / 2f, walls.SideWalls / 2f);

        transform.position = position;
    }


    public enum TeamSide
    {
        Left,
        Right
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private float moveForce = 5;


    [SerializeField]
    public GameObject respawnStart;
    [SerializeField]
    public GameObject respawnRelay;

    private Rigidbody rb;
    private bool isRelayed;
    private enum Direction
    {
        left,
        right,
        up,
        down
    }
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isRelayed = false;

    }

    public void MoveUp() => Move(Direction.up);

    public void MoveLeft() => Move(Direction.left);

    public void MoveDown() => Move(Direction.down);

    public void MoveRight() => Move(Direction.right);

    private void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.up:
                rb.AddForce(new Vector3(0, 0, moveForce));
                break;

            case Direction.left:
                rb.AddForce(new Vector3(moveForce * -1, 0, 0));
                break;

            case Direction.down:
                rb.AddForce(new Vector3(0, 0, moveForce * -1));
                break;

            case Direction.right:
                rb.AddForce(new Vector3(moveForce, 0, 0));
                break;
        }
    }

    public bool GetIsRelayed()
    {
        return isRelayed;
    }

    public void SetIsRelayed(bool bl)
    {
        isRelayed = bl;
    }

    public void Goal()
    {
        SceneManager.LoadScene("ResultScene");
    }
}

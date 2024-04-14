using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerActionPresenter : MonoBehaviour
{
    private PlayerAction playerAction;
    private Player player;


    // Start is called before the first frame update
    public void Awake()
    {
        playerAction = new PlayerAction();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (playerAction.PlayerActionMaps.MoveUp.IsPressed()) player.MoveUp();
        if (playerAction.PlayerActionMaps.MoveLeft.IsPressed()) player.MoveLeft();
        if (playerAction.PlayerActionMaps.MoveDown.IsPressed()) player.MoveDown();
        if (playerAction.PlayerActionMaps.MoveRight.IsPressed()) player.MoveRight();
    }
    private void OnEnable() => playerAction.Enable();

    private void OnDestroy() => playerAction.Disable();

}

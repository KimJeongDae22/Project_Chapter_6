using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] private Player_Inventory _inventory;
    public Player_Inventory Inventory => _inventory;

    private void Awake()
    {
        _inventory = GetComponent<Player_Inventory>();
    }
}

using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] private Player_Inventory _inventory;
    public Player_Inventory Inventory => _inventory;

    private void Start()
    {
        _inventory = GetComponent<Player_Inventory>();
        if (_inventory == null)
        {
            this.gameObject.AddComponent<Player_Inventory>();
            _inventory = GetComponent<Player_Inventory>();
        }
    }
}

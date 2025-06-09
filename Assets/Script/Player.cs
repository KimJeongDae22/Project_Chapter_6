using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] private Player_Inventory _inventory;
    [SerializeField] private Player_Stat _stat;
    public Player_Inventory Inventory => _inventory;
    public Player_Stat Stat => _stat;

    private void Start()
    {
        _inventory = GetComponent<Player_Inventory>();
        _stat = GetComponent<Player_Stat>();
        if (_inventory == null)
        {
            this.gameObject.AddComponent<Player_Inventory>();
            _inventory = GetComponent<Player_Inventory>();
        }
        if (_stat == null)
        {
            this.gameObject.AddComponent<Player_Stat>();
            _stat = GetComponent<Player_Stat>();
        }
    }
}

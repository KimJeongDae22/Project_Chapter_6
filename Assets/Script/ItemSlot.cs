using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TextMeshProUGUI _itemQuantity;
    [SerializeField] private Outline _quipOutline;
    [SerializeField] private UI_Inventory _inventory;
    public Item Item => _item;
    public Image ItemIcon => _itemIcon;
    public Outline QuipOutline => _quipOutline;

    [SerializeField] private bool _emptySlot = false;
    void Awake()
    {
        _inventory = GetComponentInParent<UI_Inventory>();
        _itemIcon = this.transform.GetChild(0).GetComponent<Image>();
        _itemIcon.enabled = false;
        _itemQuantity = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _quipOutline = GetComponent<Outline>();
    }
    public void Set()
    {
        if (_item == null)
        {
            Clear();
        }
        else
        {
            _itemIcon.enabled = true;
            _itemIcon.sprite = _item.GetItemData().GetIconSprite();
            _quipOutline.enabled = _item.GetItemData().GetEquiped();

            int quantity = _item.GetItemQuantity();
            // 소지량이 1개면 미표시, 1000개 이상이면 "+999" 로 표시해주는 함수
            QuantityNumbering(quantity);
        }
    }
    public void Clear()
    {
        _item = null;
        _itemIcon.enabled = false;
        _itemQuantity.text = string.Empty;
    }
    void QuantityNumbering(int quantity)
    {
        // 소지량이 1개면 미표시, 1000개 이상이면 "+999" 로 표시해주는 함수
        if (quantity != 1)
        {
            _itemQuantity.text = quantity.ToString();
            if (quantity > 1000)
            {
                _itemQuantity.text = "+999";
            }
        }
        else
        {
            _itemQuantity.text = string.Empty;
        }
    }
    public void SetDataItemSlot(Item data)
    {
        if (data == null)
        {
            _item = null;
            _emptySlot = true;
        }
        else
        {
            _item = data;
        }
    }
}

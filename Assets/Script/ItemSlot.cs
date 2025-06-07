using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private Image _itemIcon;
    private Image _emptyIcon;
    [SerializeField] private TextMeshProUGUI _itemQuantity;
    [SerializeField] private Outline _quipOutline;
    [SerializeField] private UI_Inventory _inventory;
    public ItemData ItemData => _itemData;
    public Image ItemIcon => _itemIcon;
    public Outline QuipOutline => _quipOutline;

    [SerializeField] private bool _emptySlot = false;
    void Start()
    {
        _inventory = GetComponentInParent<UI_Inventory>();
        _itemIcon = this.transform.GetChild(0).GetComponent<Image>();
        _emptyIcon = this.transform.GetChild(0).GetComponent<Image>();
        _itemQuantity = GetComponent<TextMeshProUGUI>();
        _quipOutline = GetComponent<Outline>();
    }
    public void Set()
    {
        if (_itemData == null)
        {
            Clear();
            return;
        }
        _itemIcon.sprite = _itemData.GetIconSprite();
        _quipOutline.enabled = _itemData.GetEquiped();

        int quantity = _itemData.GetQuantity();
        _itemQuantity.text = quantity > 1 ? quantity.ToString() : string.Empty;
    }
    public void Clear()
    {
        _itemData = null;
        _itemIcon = _emptyIcon;
        _itemQuantity.text = string.Empty;
    }
    public void SetDataItemSlot(ItemData data)
    {
        if (data == null)
        {
            _emptySlot = true;
            return;
        }
        else
        {
            _itemData = data;
        }
    }
}

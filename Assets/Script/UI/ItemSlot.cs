using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] private int _itemIndex;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TextMeshProUGUI _itemQuantity;
    [SerializeField] private Outline _equipOutline;
    public Item Item { get { return _item; } set { _item = value; } }
    public int ItemIndex { get { return _itemIndex; } set { _itemIndex = value; } }
    public Image ItemIcon { get { return _itemIcon; } set { _itemIcon = value; } }
    public Outline QuipOutline { get { return _equipOutline; } set { _equipOutline = value; } }

    void Awake()
    {
        _itemIcon = this.transform.GetChild(0).GetComponent<Image>();
        _itemIcon.enabled = false;
        _itemQuantity = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _equipOutline = GetComponent<Outline>();
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
            _itemIcon.sprite = _item.ItemData.IconSprite;
            _equipOutline.enabled = _item.IsEquipped;

            int quantity = _item.ItemQuantity;
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
    public void SetDataItemSlot(Item data, int index)
    {
        if (data == null)
        {
            _item = null;
        }
        else
        {
            _item = data;
            _itemIndex = index;
        }
    }
    public void Btn_SlotClick()
    {
        var invenUI = Singleton<UIManager>.Instance.UIInventory;
        if (_item != null)
        {
            if (_item.ItemData != null)
            {
                // 아이템 설명창이 비활성화일 경우 설명창 업데이트(아이템 아이콘 활성화 여부로 판단)
                if (invenUI.SelectedItemIcon.enabled == false)
                {
                    invenUI.InfoUpdate(_item, _itemIndex);
                }
                else
                {
                    // 아이콘 활성화 중이어도 다른 아이템를 누를 경우 그 아이템 정보 출력
                    if (invenUI.SelectedItemIndex != _itemIndex)
                    {
                        invenUI.InfoUpdate(_item, _itemIndex);
                    }
                    // 같은 아이템을 두 번 클릭하면 출력되어 있는 정보창 내용 지우기
                    else
                    {
                        invenUI.InfoClear();
                    }
                }
            }
        }
        else
        {
            invenUI.InfoClear();
        }
    }
}

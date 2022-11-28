using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContentHandler : MonoBehaviour {

    [SerializeField]
    private Button _buyButton, _equipButton;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private TextMeshProUGUI _priceText, _nameText;
    private Content content;
    public Content Content { set => content = value; }
    public void InitializeContent() {
        _priceText.text = content.Price.ToString();
        _nameText.text = content.Name.ToString();
        SetButtons();
        _buyButton.onClick.AddListener(() => content.Buy());
        _buyButton.onClick.AddListener(() => SetButtons());
        _equipButton.onClick.AddListener(() => content.Equip());

        if (content is ItemBloomColor) {
            _image.color = (content as ItemBloomColor).Color;
        }

    }
    public void SetButtons() {
        if (content.IsBought) {
            _buyButton.gameObject.SetActive(false);
            return;
        }if (content.GetBought() == 1) {
            _buyButton.gameObject.SetActive(false);
            content.IsBought= true;
        }
    }
}

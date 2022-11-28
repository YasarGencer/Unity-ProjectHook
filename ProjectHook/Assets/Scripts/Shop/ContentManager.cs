using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ContentManager : MonoBehaviour
{
    public GameObject Content;
    //items
    public BloomColor BloomColor;
    //transform
    public Transform BloomColorTransform;
    public void Start() {
        foreach (var item in BloomColor.bloomColor) {
            GameObject init = Instantiate(Content,BloomColorTransform);
            ContentHandler contentHandler = init.GetComponent<ContentHandler>();
            contentHandler.Content = item;
            contentHandler.InitializeContent();
        }
    }
}

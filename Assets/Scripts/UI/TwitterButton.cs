using UnityEngine;
using UnityEngine.EventSystems;

public class TwitterButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject pController;

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerController pc = pController.GetComponent<PlayerController>();
        
        Application.OpenURL("https://twitter.com/home?status=I%27ve%20earned%20" + pc.money+"%20money%20by%20clicking%20mouse%20"+pc.clicks+"%20times%2C%20you%20should%20try%20it%20too%3A%20https%3A%2F%2Fglobalgamejam.org%2F2018%2Fgames%2Fgear-clicker%20..%20%23GearClicker%20%23FGJX");
    }

}
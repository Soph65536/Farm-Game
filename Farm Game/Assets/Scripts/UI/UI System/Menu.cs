using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string menuName; //we can find menus through their name, this should be all lowercase
    [SerializeField] public GameObject menuObject; //in hierarchy this should be their child object

    private void Start()
    {
        //if this isnt already in menus then add it to menus
        if(UIManager.Instance.FindMenuByName(menuName) == null)
        {
            UIManager.Instance.menus.Add(this);
            DontDestroyOnLoad(this);
        }

        Close();
    }

    public void Open(){ menuObject.SetActive(true); }
    public void Close() { menuObject.SetActive(false); }
}

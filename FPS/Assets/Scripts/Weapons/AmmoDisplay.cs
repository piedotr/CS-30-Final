using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{

    public GameObject ammoTextUI;
    public int pistolCount;

    // Update is called once per frame
    void Update()
    {
        string v = "AMMO: " + pistolCount;
        ammoTextUI.GetComponent<Text>().text = v;
    }
}

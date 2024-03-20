using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCatInteract :  MonoBehaviour, INteractable
{
    public void Interact(GameObject player)
    {
        print("Your friend, IM");
    }
   
}

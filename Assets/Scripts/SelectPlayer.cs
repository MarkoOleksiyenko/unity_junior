using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    private void OnMouseDown() {
        GameObject.Find("Canvas").GetComponent<MenuUIHandler>().selectedPlayer = gameObject;
    }
     private void Update() {
        GameObject selected = GameObject.Find("Canvas").GetComponent<MenuUIHandler>().selectedPlayer;
         if (gameObject.GetComponent<Outline>() == null &&  selected == gameObject) {
                var outline = gameObject.AddComponent<Outline>();

                outline.OutlineMode = Outline.Mode.OutlineAll;
                outline.OutlineColor = Color.red;
                outline.OutlineWidth = 10f;
            }
        if (selected != gameObject && gameObject.GetComponent<Outline>() != null) {
            Destroy(GetComponent<Outline>());
        }
     }
}

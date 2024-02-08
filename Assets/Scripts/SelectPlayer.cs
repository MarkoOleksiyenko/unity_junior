using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    private void OnMouseDown() {
        DataManager.Instance.selectedPlayer = gameObject.tag;
    }
     private void Update() {
        string selected = DataManager.Instance.selectedPlayer;
         if (gameObject.GetComponent<Outline>() == null &&  selected == gameObject.tag) {
                var outline = gameObject.AddComponent<Outline>();

                outline.OutlineMode = Outline.Mode.OutlineAll;
                outline.OutlineColor = Color.red;
                outline.OutlineWidth = 10f;
            }
        if (selected != gameObject.tag && gameObject.GetComponent<Outline>() != null) {
            Destroy(GetComponent<Outline>());
        }
     }
}

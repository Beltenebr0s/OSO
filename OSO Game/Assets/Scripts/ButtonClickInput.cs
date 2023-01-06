using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClickInput : MonoBehaviour, IPointerClickHandler
{


    public void OnPointerClick(PointerEventData eventData)
    {
        string[] name = this.gameObject.name.Split("-");
        int i = int.Parse(name[0]);
        int j = int.Parse(name[1]);
        if(GameManager.Instance.gameGrid.IsCellEmpty(i, j))
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                GameManager.Instance.gameGrid.SetCell(i, j, Grid.osoValues.SYMBOL_O);
                this.GetComponent<Image>().color = Color.red;
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                GameManager.Instance.gameGrid.SetCell(i, j, Grid.osoValues.SYMBOL_S);
                this.GetComponent<Image>().color = Color.green;
            }
        }
    }
}

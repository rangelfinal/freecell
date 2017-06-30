using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IDropHandler
{
    public enum CellType
    {
        FREE,
        HOME,
        TABLEAU
    }

    public Stack<Card> Cards;
    public CellType cellType;

    public Card StackCard
    {
        get
        {
            if (transform.childCount == 0) return null;
            return transform.GetChild(transform.childCount - 1).gameObject.GetComponent<Card>();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card playCard = eventData.pointerDrag.GetComponent<Card>();

        if (!playCard.CanDrag) return;

        if(playCard == null)
        {
            throw new NotSupportedException("Objeto arrastado não é uma carta.");
        }

        if(Table.IsPlayValid(cellType, playCard, StackCard))
            playCard.currentParent = this.transform;
    }
}

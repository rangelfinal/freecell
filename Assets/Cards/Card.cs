using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum CardSuit
{
    HEARTS,
    DIAMONDS,
    CLUBS,
    SPADES
}

public enum CardColor
{
    RED,
    BLACK
}

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public CardSuit Suit;

    public Text SuitText;
    public Text ValueText;

    public CardColor Color
    {
        get
        {
            if (Suit == CardSuit.HEARTS || Suit == CardSuit.DIAMONDS)
            {
                return CardColor.RED;
            }
            else
            {
                return CardColor.BLACK;
            }
        }
    }

    public int Value;

    public string ValueString
    {
        get
        {
            switch(Value)
            {
                case 0:
                    return "A";
                case 10:
                    return "J";
                case 11:
                    return "Q";
                case 12:
                    return "K";
                default:
                    return (Value+1).ToString();
            }
        }
    }

    public string SuitString
    {
        get
        {
            switch(Suit)
            {
                case CardSuit.CLUBS:
                    return "♣";
                case CardSuit.DIAMONDS:
                    return "♦";
                case CardSuit.HEARTS:
                    return "♥";
                case CardSuit.SPADES:
                    return "♠";
                default:
                    return "?";
            }
        }
    }

    public Transform currentParent;

    public void Start()
    {
        SuitText.text = SuitString;
        ValueText.text = ValueString;

        if (Color == CardColor.RED)
        {
            SuitText.color = UnityEngine.Color.red;
            ValueText.color = UnityEngine.Color.red;
        }
    }

    public bool CanDrag = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (transform.GetSiblingIndex() != transform.parent.childCount - 1) CanDrag = false; // Somente a ultima carta do monte pode ser arrastada
        else if (transform.parent.GetComponent<Cell>() && transform.parent.GetComponent<Cell>().cellType == Cell.CellType.HOME) CanDrag = false; // Cancela o arraste se for uma fundação
        else CanDrag = true;

        if (!CanDrag) return;

        currentParent = this.transform.parent;
        this.transform.SetParent(Table.table.transform);
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        Cell[] cells = FindObjectsOfType<Cell>();
        //TODO: Mudar a cor de células válidas
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!CanDrag) return;

        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!CanDrag) return;

        transform.SetParent(currentParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}

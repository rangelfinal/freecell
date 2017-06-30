using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour {

    private Stack<Card> deck = new Stack<Card>();

    public Card card;

    public void CreateDeck()
    {
        Card[] orderedDeck = new Card[52];

        for(int i=0; i<4; i++)
        {
            for(int j=0; j<13; j++)
            {
                Card newCard = Instantiate(card, Table.table.transform);
                newCard.Value = j;
                newCard.Suit = (CardSuit)i;
                orderedDeck[j + i * 13] = newCard;
            }
        }

        // Embaralhar
        System.Random rng = new System.Random();
        Card[] shuffledDeck = orderedDeck.OrderBy(x => rng.Next()).ToArray();

        // Finalmente colocar as cartas na pilha
        foreach (Card card in shuffledDeck)
        {
            deck.Push(card);
        }
    }

    public void DealCards()
    {
        while (!deck.Empty)
        {
            foreach (Transform cell in Table.tableau.transform)
            {
                if (deck.Empty) break; // Sempre vai ficar vazio no meio do foreach
                deck.Pop().transform.SetParent(cell); // Tira a carta do baralho e coloca na mesa
            }
        }
    }

    void Start()
    {
        CreateDeck();
        DealCards();
    }

}
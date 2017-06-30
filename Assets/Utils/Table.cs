using UnityEngine;

public class Table : ScriptableObject
{   
    public static GameObject table = GameObject.Find("Table");
    public static GameObject freeCells = GameObject.Find("FreeCells");
    public static GameObject homeCells = GameObject.Find("HomeCells");
    public static GameObject tableau = GameObject.Find("Tableau");

    /// <summary>
    /// Valida a jogada a partir do tipo de célula, carta jogada e carta na célula.
    /// </summary>
    /// <param name="cellType">Tipo de célula</param>
    /// <param name="playCard">Carta sendo jogada</param>
    /// <param name="stackCard">Carta na célula</param>
    /// <returns></returns>
    public static bool IsPlayValid(Cell.CellType cellType, Card playCard, Card stackCard)
    {
        if (stackCard == null)
        {
            if (cellType == Cell.CellType.FREE || cellType == Cell.CellType.TABLEAU) return true;
            if (cellType == Cell.CellType.HOME && playCard.Value == 0) return true;
            return false;
        }

        if (cellType == Cell.CellType.FREE) return false; // Não existe jogada válida se a célula livre está ocupada

        if (cellType == Cell.CellType.HOME )
        {
            return playCard.Suit == stackCard.Suit && playCard.Value == stackCard.Value + 1; // Válido se a carta jogada é do mesmo naipe e próxima da carta na célula
        }

        return playCard.Color != stackCard.Color && playCard.Value == stackCard.Value - 1; // Válido se a carta jogada é de cor diferente e anterior da carta na célula
    }
}
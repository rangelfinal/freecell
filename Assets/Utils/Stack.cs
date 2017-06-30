public class Stack<T>
{
    public readonly int size;
    private int pointer = 0;
    protected T[] items;

    public Stack():this(52) { } // Por padrão, stack deve ser grande o suficiente para conter todo o baralho
    public Stack(int size)
    {
        this.size = size;
        this.items = new T[this.size];
    }

    public void Push(T item)
    {
        if (pointer == size)
            throw new System.StackOverflowException();

        items[pointer] = item;
        pointer++;
    }

    public T Pop()
    {
        if (pointer == 0)
        {
            throw new System.InvalidOperationException("Pilha vazia");
        }
        pointer--;
        return items[pointer];
    }

    public int Lenght
    {
        get
        {
            return pointer;
        }
    }

    public bool Empty
    {
        get
        {
            return pointer == 0;
        }
    }
}
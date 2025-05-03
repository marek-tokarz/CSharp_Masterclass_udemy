var numbers = new ListOfInts();

numbers.Add(10);
numbers.Add(20);
numbers.Add(30);
numbers.Add(40);
numbers.Add(50);

Console.ReadKey();

class ListOfInts
{
    private int[] _items = new int[4];
    private int _size = 0;

    public void Add(int item)
    {
        if(_size >= _items.Length)
        {
            var newItems = new int[_items.Length * 2];

            for(int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }
        _items[_size] = item;
        ++_size;
    }
}
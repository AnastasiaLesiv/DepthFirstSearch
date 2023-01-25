namespace ConsoleApp1;

    public class DFS
  {
    private bool[,] visited;
    private char[,] matrixSymbol;
    private MyStack<Pos> stack;
  
    public DFS(char[,] matrixSymbol) 
    {
      this.matrixSymbol = matrixSymbol;
      visited = new bool[matrixSymbol.GetLength(0), matrixSymbol.GetLength(1)];
      stack = new MyStack<Pos>();
    }
  
    class Pos 
    {
      public int i;
      public int j;
      public Pos from;
  
      public Pos(int i, int j, Pos from)
      {
        this.i = i;
        this.j = j;
        this.from = from;
      }
    }
     //метод який шукає початковий вузол графа
    Pos FindStart() 
    {
      for (int i = 0; i < matrixSymbol.GetLength(0); i++) 
      {
        for (int j = 0; j < matrixSymbol.GetLength(1); j++) 
        {
          //за допомогою двох циклів обходимо граф в шукаємо точку входу 'S'
          if (matrixSymbol[i,j] == 'S') 
          {
            //якщо знайшли повертаємо її координати і відмічаємо що вона відввідана
            visited[i,j] = true;
            return new Pos(i, j, null);
          }
        }
      }
      //якщо ні повертаємо null
      return null;
    }
    //перевіряємо чи можна додати вузол
    bool IsAdd(int i, int j)
    {
      //перевіряємо чи не вийдемо ми за межі масиву
      if (i <= -1 || j <= -1 || i >= matrixSymbol.GetLength(0) || j >= matrixSymbol.GetLength(1)) 
      {
        return false;
      }
      //перевіряємо чи чи не '#' - заблокований хід
      if (matrixSymbol[i,j] == '#') 
      {
        return false;
      }
      //якщо все добре повертаємо true
      return !visited[i,j];
    }
      //додаємо елемент в стек
    void Add(int i, int j, Pos pos) 
    {
      Pos temp = new Pos(i, j, pos);
      //додаємо тимчасову змінну з координатами відповідного вузла
      stack.Push(temp);
      //помічаємо його як відвіданий
      visited[i,j] = true;
    }
  
    public void Dfs() 
    {
      //шукаємо та додаємо початковий вузол
      stack.Push(FindStart());
      //змінна, що зберігає значення вузла
      char currentValue = 's'; 
  
      //цикл для пошуку і заповнення стеку
      while (currentValue != 'F') //перевіряємо чи не кінець лабіринту
      {
        //передаємо дані поточного першого елементу
        Pos current = stack.Peek();
        //передаємо символ поточного топу в змінну currentValue
        currentValue = matrixSymbol[current.i,current.j];
        //проходимо по всіх сусідах вузла, якщо вони є - додаємо їх в стек
        CheckAndAdd(current.i + 1, current.j, current);
        CheckAndAdd(current.i, current.j + 1, current);
        CheckAndAdd(current.i - 1, current.j, current);
        CheckAndAdd(current.i, current.j - 1, current);
      }
  
      //Тут в циклі рисування (очищання stack)
      while (stack.top != null) {
        //дістаємо перший елемент 
        Pos p = stack.Pop();
        //та посилання на попередній елемент
        Pos from = p.from;
        //якщо є попередній елемент і він не дорівнює 'S' замінюємо його на 'x'
        if (from != null && matrixSymbol[from.i,from.j] != 'S') 
        {
          matrixSymbol[from.i,from.j] = 'x';
        }
      }
    }
    //перевіряємо та додаємо елемент
    private void CheckAndAdd(int i, int j, Pos current) {
      if (IsAdd(i, j)) {
        Add(i, j, current);
      }
    }
  }


namespace ConsoleApp1;
  public class MyStack<T> 
  {
      //клас в якому будемо зберігати дані про об'єкт та посилання на наступний об'єкт
        public class Node {
            public T data;
            public Node next;

            public Node(T data, Node next) 
            {
                this.data = data;
                this.next = next;
            }
        }

        public Node top;
        private int size;
        
        public MyStack() 
        {
            top = null;
            size = 0;
        }

        public void Push(T item) 
        {
            //додаємо елемент на місце попереднього топа і присвоюємо йому його посилання
            top = new Node(item, top);
            size++;
        }
        //отримуємо елемент з стека з його подальшим видаленням
        public T Pop() 
        {
            //отримуємо дані з першої позиціїї стеку
            T result = top.data;
            //переприсвоємо посилання на наступний елемент
            top = top.next;
            //зменшуємо розмір масиву
            size--;
            //повертаємо видалений елемент
            return result;
        }
        //отриуємо елемент стеку без видалення 
        public T Peek()
        {
            if (top != null) 
            {
                return top.data;
            }
            return default(T);
        }
        
        public int Size() //к-ть елементів в стекові
        {
            return size;
        }

        public void ShowContains() //виводить вміст стеку
        {
            
            Node tempTop = top;
            while (tempTop != null) {
                Console.Write(tempTop.data);
                //присвоює посилання на наступний елемент
                tempTop = tempTop.next;
            }
        }
    }

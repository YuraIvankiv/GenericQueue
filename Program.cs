
namespace ConsoleApp6;
using System;

//Метод Enqueue-Додає новий елемент до кінця черги
//Pike повертає 1 елемент черги (в завдані 2 1 по пріорітету)
//Dequeue вивільняє чергу (Завдання 2 по пріорітету Завдання 3 по колу)
//Cout- Повертає кількість елементів в черзі
//Clear- очищає чергу
public class Program
{
    // Завдання 1
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
    public static void Main()
    {
        Console.WriteLine("Тест Завдання 1: generic-версiя методу Swap");
        int a = 5;
        int b = 10;
        Swap(ref a, ref b);
        Console.WriteLine($"After swap: a = {a}, b = {b}");
        Console.WriteLine(" ");

        Console.WriteLine("Тест Завдання 2 «Черга» з прiоритетами.");
        PriorityQueue<int> queue = new PriorityQueue<int>();
        queue.Enqueue(11);
        queue.Enqueue(2);
        queue.Enqueue(4);
        Console.WriteLine($"Count: {queue.Count}");  
        Console.WriteLine($"Peek: {queue.Peek()}"); 
        int item1 = queue.Dequeue();  
        int item2 = queue.Dequeue(); 
        Console.WriteLine($"Знятi з черги елементи: {item1}, {item2}");  
        Console.WriteLine($"Count: {queue.Count}");  
        queue.Clear();

        Console.WriteLine(" ");
        Console.WriteLine("Тест Завдання 3 с «Кiльцева Черга».");
        CircularQueue<int> Cqueue = new CircularQueue<int>(5);
        Cqueue.Enqueue(1);
        Cqueue.Enqueue(2);
        Cqueue.Enqueue(3);
        Console.WriteLine($"Count: {Cqueue.Count}");  
        Console.WriteLine($"Peek: {Cqueue.Peek()}");  
        int One = Cqueue.Dequeue();  
        int Two = Cqueue.Dequeue(); 
        Console.WriteLine($"Знятi з черги елементи: {One},{Two}");   
    }
}



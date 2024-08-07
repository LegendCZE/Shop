using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Category produkty = new Category("Produkty");
        Category elektronika = new Category("Elektronika");
        Category phones = new Category("Mobilní Telefony");
        Category tv = new Category("Televize");
        Category obleceni = new Category("Oblečení");
        Category trika = new Category("Trička");
        Category kalhoty = new Category("Kalhoty");
        Category sport = new Category("Sport");
        Category fotbal = new Category("Fotbal");
        Category hokej = new Category("Hokej");

        produkty.AddSubCategory(elektronika);
        produkty.AddSubCategory(obleceni);
        produkty.AddSubCategory(sport);

        elektronika.AddSubCategory(phones);
        elektronika.AddSubCategory(tv);

        obleceni.AddSubCategory(trika);
        obleceni.AddSubCategory(kalhoty);

        sport.AddSubCategory(fotbal);
        sport.AddSubCategory(hokej);

        //PrintCategory(produkty);
        //PrintCategoriesBFS(produkty);
        //PrintCategoriesDFS(produkty);
    }

    static void PrintCategory(Category category)
    {
        Console.WriteLine(category.Name);

        foreach (Category i in category.subCategories)
        {
            PrintCategory(i);
        }
    }

    static void PrintCategoriesBFS(Category category)
    {
        Queue<Category> BFS = new Queue<Category>();
        BFS.Enqueue(category);

        while (BFS.Count != 0)
        {
            Category curr = BFS.Dequeue();
            Console.WriteLine(curr.Name);

            foreach (Category item in curr.subCategories)
            {
                BFS.Enqueue(item);
            }
        }
    }

    static void PrintCategoriesDFS(Category category)
    {
        Stack<Category> DFS = new Stack<Category>();
        DFS.Push(category);

        while (DFS.Count != 0)
        {
            Category curr = DFS.Pop();
            Console.WriteLine(curr.Name);

            for (int i = curr.subCategories.Count - 1; i >= 0; i--)
            {
                DFS.Push(curr.subCategories[i]);
            }
        }
    }
}

class Category
{
    public string Name;
    public List<Category> subCategories = new List<Category>();

    public Category(string name)
    {
        Name = name;
    }

    public void AddSubCategory(Category category)
    {
        subCategories.Add(category);
    }
}

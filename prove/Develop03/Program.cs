public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}
public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int? _endVerse;

    public Reference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = null;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        if (_endVerse.HasValue)
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        else
            return $"{_book} {_chapter}:{_startVerse}";
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        List<int> visibleIndexes = _words
            .Select((word, index) => new { word, index })
            .Where(x => !x.word.IsHidden())
            .Select(x => x.index)
            .ToList();

        for (int i = 0; i < count && visibleIndexes.Count > 0; i++)
        {
            int randomIndex = rand.Next(visibleIndexes.Count);
            _words[visibleIndexes[randomIndex]].Hide();
            visibleIndexes.RemoveAt(randomIndex);
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        Console.WriteLine();

        foreach (var word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }

        Console.WriteLine("\n");
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. "
                    + "In all thy ways acknowledge him, and he shall direct thy paths.";

        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("All words are hidden. Good job!");
                break;
            }

            Console.Write("Press Enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }
    }
}

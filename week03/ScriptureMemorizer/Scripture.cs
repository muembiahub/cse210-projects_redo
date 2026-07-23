using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitText = text.Split(' ');
        foreach (string wordStr in splitText)
        {
            _words.Add(new Word(wordStr));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        // SMART WORD HIDING: Count how many words are actually available to hide
        int availableWords = 0;
        foreach (Word w in _words)
        {
            if (!w.IsHidden()) availableWords++;
        }

        int targetToHide = Math.Min(numberToHide, availableWords);

        // Only pick from words that are not already hidden
        while (hiddenCount < targetToHide)
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public string GetDisplayText()
    {
        string textDisplay = "";
        foreach (Word word in _words)
        {
            textDisplay += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()} {textDisplay.TrimEnd()}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
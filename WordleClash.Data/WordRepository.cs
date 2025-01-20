using MySql.Data.MySqlClient;
using WordleClash.Core.Exceptions;
using WordleClash.Core.Interfaces;
using Exception = System.Exception;

namespace WordleClash.Data;

public class WordRepository: IWordRepository
{
    private readonly HashSet<string> _wordSet;
    private readonly List<string> _wordList;
    private readonly Random _random;
        
    public WordRepository(string[] wordList)
    {
        _wordSet = [..wordList];
        _wordList = [.._wordSet];
        _random = new Random();
    }

    public string GetRandom()
    {
        var randomIndex = _random.Next(0, _wordList.Count);
        return _wordList[randomIndex];
    }

    public string? Get(string word)
    {
        return _wordSet.Contains(word) ? word : null;
    }
}
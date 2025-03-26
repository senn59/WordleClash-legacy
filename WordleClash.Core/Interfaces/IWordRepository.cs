namespace WordleClash.Core.Interfaces;

public interface IWordRepository
{
    string GetRandom();
    string? Get(string word);
}
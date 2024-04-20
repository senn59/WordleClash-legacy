using System.Collections.Concurrent;
using WordleClash.Core.Interfaces;

namespace WordleClash.Core;

public class LobbyService
{
    private readonly ConcurrentDictionary<string, VersusLobby> _lobbies = new ConcurrentDictionary<string, VersusLobby>();
    private readonly IDataAccess _dataAccess;

    public LobbyService(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public string Create(Player creator)
    {
        var lobby = new VersusLobby(_dataAccess, creator);
        _lobbies.TryAdd(lobby.Code, lobby);
        return lobby.Code;
    }

    public VersusLobby Get(string id)
    {
        _lobbies.TryGetValue(id, out var lobby);
        if (lobby == null)
        {
            throw new Exception("Lobby does not exist");
        }
        return lobby;
    }

    public void DicardInstance(string id)
    {
        _lobbies.Remove(id, out _);
    }
}
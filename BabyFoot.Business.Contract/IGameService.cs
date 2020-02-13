namespace BabyFoot.Business.Contract
{
    public interface IGameService
    {
       void CreateGame(string name);
       
       void DeleteGame(string name);

       void GetGame(string name);
        
       void GetAllGames();
    }
}

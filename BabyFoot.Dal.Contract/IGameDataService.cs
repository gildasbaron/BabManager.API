namespace BabyFoot.Dal.Contract
{
    public interface IGameDataService
    {
        void Create(string name);

       void Delete(string name);

       void Ge(string name);

       void GetAll();
    }
}

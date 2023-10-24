namespace Data_Access_Layer.Contracts
{
    public interface IUnitOfWork
    {
        IAdminRepository AdminRepository { get; }
        IUserRepository UserRepository { get; }
        void Save();
    }
}

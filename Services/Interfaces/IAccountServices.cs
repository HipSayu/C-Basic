using AppMobileBackEnd.Dtos.Account;

namespace AppMobileBackEnd.Services.Interfaces
{
    public interface IAccountServices
    {
        List<AccountDto> GetAll();

        AccountDto getById (int IdAccount);

        AccountDto getByUserName (string UserName);

        AccountDto getByEmail (string Email);


        void Create(CreateAccountDto input);

        void Update(UpdateAccountDto input);

        void Delete (int IdAccount);

    }
}

using Silicon_WebApp.Models;
namespace Silicon_WebApp.ViewModels;

public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account Details";
    public AccountDetailsBasicInfoModel BasicInfo { get; set; } = new AccountDetailsBasicInfoModel()
    {
        ProfileImage = "/images/profile-image.svg",
        FirstName = "Dennis",
        LastName = "Mikaj",
        Email = "Mikaj@domain.com"
    };
    public AccountDetailsAddressInfoModel AddressInfo { get; set; } = new AccountDetailsAddressInfoModel();



}

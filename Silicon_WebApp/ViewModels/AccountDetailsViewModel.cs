using Silicon_WebApp.Models;
using System.ComponentModel.DataAnnotations;
namespace Silicon_WebApp.ViewModels;

public class AccountDetailsViewModel
{
    public ProfileInfoViewModel? ProfileInfo { get; set; }
    public string Title { get; set; } = "Account Details";
    public AccountDetailsBasicInfoModel? BasicInfo { get; set; }
    public AccountDetailsAddressInfoModel? AddressInfo { get; set; }



}

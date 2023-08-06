using System;
using Volo.Abp.Users;

namespace StokTakip.Web.Pages;

public class IndexModel : StokTakipPageModel
{
    private readonly ICurrentUser _currentUser;
    public IndexModel(ICurrentUser currentUser)
    {
        _currentUser = currentUser;
    }
    public Guid? UserId { get; set; }
    public void OnGet()
    {
        UserId = _currentUser.Id;
    }
}

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MovieTickets.Models;

public class ApplicationUserManager : UserManager<User>
{
    public ApplicationUserManager(IUserStore<User> store)
            : base(store)
    {
    }
    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
                                            IOwinContext context)
    {
        MovieTicketContext db = context.Get<MovieTicketContext>();
        ApplicationUserManager manager = new ApplicationUserManager(new UserStore<User>(db));
        return manager;
    }
}
using BazaarDAL.Data;
using BazaarDAL.Models;

using (var context = new BazaarDBContext())
{
    var users = context.User.ToList();

    foreach (var user in users)
    {
        Console.WriteLine($"User -> {user.ReviewerIn.Count()}");
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCForumApp.Data;
using System;
using System.Linq;

namespace MVCForumApp.Models;

public static class SeedData
{

    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MVCForumAppContext(
            serviceProvider.GetRequiredService<DbContextOptions<MVCForumAppContext>>()))
        {
            var testUser = await context.User.FirstOrDefaultAsync(u => u.Login == "Test");

            if (testUser == null)
            {
                testUser = new User
                {
                    Login = "Test",
                    Password = "Password123"
                };
                context.User.Add(testUser);
                await context.SaveChangesAsync();
            }

            if (!context.Topic.Any(t => t.OwnerId == testUser.Id))
            {
                context.Topic.AddRange(
                    new Topic
                    {
                        Title = "Welcome to the Forum!",
                        Description = "Have a good time with outher users!",
                        CreatedAt = DateTime.Now,
                        OwnerId = testUser.Id
                    },
                    new Topic
                    {
                        Title = "Lorem Ipsum",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Etiam dictum mauris ac fringilla iaculis. Vivamus dapibus ipsum eu iaculis tincidunt. " +
                        "Nullam volutpat nisi ut mollis blandit. Maecenas feugiat eget augue nec dictum. " +
                        "Ut ac arcu eu purus tincidunt pellentesque sit amet vel mi. Vivamus quis mauris diam. " +
                        "Nunc nulla felis, vestibulum sed quam et, laoreet gravida odio. " +
                        "Etiam euismod nulla vel vestibulum facilisis. Sed rhoncus augue ut dui maximus lacinia. " +
                        "Phasellus condimentum venenatis nibh sed auctor. Ut faucibus eros semper nunc venenatis elementum. " +
                        "Vestibulum vel condimentum ex, at blandit velit. " +
                        "Cras augue sapien, ullamcorper nec mi ac, scelerisque ornare mauris.",
                        CreatedAt = DateTime.Now,
                        OwnerId = testUser.Id
                    }
                );

                await context.SaveChangesAsync();
            }
        }
    }



}



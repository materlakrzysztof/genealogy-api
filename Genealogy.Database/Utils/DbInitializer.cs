using Microsoft.EntityFrameworkCore;

namespace Genealogy.Database.Utils;

public class DbInitializer(GenealogyDbContext context) : IDbInitializer
{

    public async Task Initialize()
    {
        await context.Database.MigrateAsync();

        if (await context.Users.AnyAsync())
            return;



        await context.Users.AddRangeAsync(new Models.UserDb
        {
            Active = true,
            UserName = "admin",
            PasswordHash = "AQAAAAIAAYagAAAAEKl2dA/IAkXkDqWzeD6RCkSk1ZsBLqtVGs5kyiDi72UZzTSCChJ/Z2WzmfVfYgQmkw==",
            Role = 3,
            CreateDate = DateTime.UtcNow

        }, new Models.UserDb
        {
            Active = true,
            UserName = "krzysztof",
            PasswordHash = "AQAAAAIAAYagAAAAEL0pyl90dQjoMXiTjjPIjKUhmwBevwkPVC4o3yceBH8zh8Ayd7v/nUqeXL80zOAINQ==",
            Role = 1,
            CreateDate = DateTime.UtcNow
        },
        new Models.UserDb
        {
            Active = true,
            UserName = "piotr",
            PasswordHash = "AQAAAAIAAYagAAAAEPKbBzQXdxUfK2x9txsmNV8l51pfXBp8p9EW7pF+sRX/PTGvKre11zNjcDCXPPB/aA==",
            Role = 1,
            CreateDate = DateTime.UtcNow
        });

        await context.SaveChangesAsync();
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuipVid.Core.Models;

namespace QuipVid.Core.Data
{
    public class DatabaseSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>();
            using var context = new AppDbContext(options);

            var now = DateTimeOffset.Now;

            var users = new List<User>
            {
                new User
                {
                    Id = Guid.Parse("427fc823-6cf1-4c7d-bea5-bbfc8558f285"),
                    UserName = "levizitting",
                    CreatedAt = now,
                    UpdatedAt = now,
                },
                new User
                {
                    Id = Guid.Parse("4af5dc71-fbcc-4fa2-afb1-898593fc36e2"),
                    UserName = "mykebates",
                    CreatedAt = now,
                    UpdatedAt = now,
                },
            };

            var media = new List<Media>
            {
                new Media
                {
                    Id = Guid.Parse("272a5db6-427d-4a5e-a74c-f0ddc036547d"),
                    Title = "Silicon Valley",
                    CreatedAt = now,
                    UpdatedAt = now,
                },
                new Media
                {
                    Id = Guid.Parse("8fb443d5-7d7f-4ae1-be2a-9bc6e2377782"),
                    Title = "Napoleon Dynamite",
                    CreatedAt = now,
                    UpdatedAt = now,
                },
                new Media
                {
                    Id = Guid.Parse("3d2a76e2-125f-4e88-8346-a2b93121115b"),
                    Title = "Seinfeld",
                    CreatedAt = now,
                    UpdatedAt = now,
                },
            };

            var quips = new List<Quip>
            {
                new Quip
                {
                    Id = Guid.Parse("ff733411-5bd2-47bf-ad0e-79dba967f1cb"),
                    Title = "Your Algorithm Is Solid",
                    VideoUrl = "https://s3.amazonaws.com/djquipvid/10P6jb7O.mp4",
                    ThumbnailUrl = "https://s3.amazonaws.com/djquipvid/BtoWWsnP_1.jpg",
                    UploaderId = users[1].Id,
                    MediaId = media[0].Id,
                    CreatedAt = now,
                    UpdatedAt = now,
                },
                new Quip
                {
                    Id = Guid.Parse("982b4bbb-591f-4d31-bd5b-8f35640ce9a8"),
                    Title = "Initial Release",
                    VideoUrl = "https://s3.amazonaws.com/djquipvid/7NYvYyfR.mp4",
                    ThumbnailUrl = "https://s3.amazonaws.com/djquipvid/7NYvYyfR_1.jpg",
                    UploaderId = users[1].Id,
                    MediaId = media[0].Id,
                    CreatedAt = now,
                    UpdatedAt = now,
                },
                new Quip
                {
                    Id = Guid.Parse("836023ed-6369-45e2-a28f-d598a30e2645"),
                    Title = "Seven Words",
                    VideoUrl = "https://s3.amazonaws.com/djquipvid/J4Sy633X.mp4",
                    ThumbnailUrl = "https://s3.amazonaws.com/djquipvid/J4Sy633X_1.jpg",
                    UploaderId = users[1].Id,
                    MediaId = media[0].Id,
                    CreatedAt = now,
                    UpdatedAt = now,
                },
                new Quip
                {
                    Id = Guid.Parse("6051cf71-66fc-4c7d-9bd3-afe8eced96ad"),
                    Title = "Worst day of my life",
                    VideoUrl = "https://s3.amazonaws.com/djquipvid/zPRXYN7e.mp4",
                    ThumbnailUrl = "https://s3.amazonaws.com/djquipvid/zPRXYN7e_1.jpg",
                    UploaderId = users[1].Id,
                    MediaId = media[1].Id,
                    CreatedAt = now,
                    UpdatedAt = now,
                },
                new Quip
                {
                    Id = Guid.Parse("b5c9e061-ef3f-4e09-9a02-8e2f02e886d4"),
                    Title = "Getting Pretty Serious",
                    VideoUrl = "https://s3.amazonaws.com/djquipvid/4Yk68Ssr.mp4",
                    ThumbnailUrl = "https://s3.amazonaws.com/djquipvid/4Yk68Ssr_1.jpg",
                    UploaderId = users[1].Id,
                    MediaId = media[1].Id,
                    CreatedAt = now,
                    UpdatedAt = now,
                },
                new Quip
                {
                    Id = Guid.Parse("65613676-343d-4672-b364-ee021f13b48c"),
                    Title = "Society",
                    VideoUrl = "https://s3.amazonaws.com/djquipvid/kAV6kmNE.mp4",
                    ThumbnailUrl = "https://s3.amazonaws.com/djquipvid/kAV6kmNE_1.jpg",
                    UploaderId = users[1].Id,
                    MediaId = media[2].Id,
                    CreatedAt = now,
                    UpdatedAt = now,
                },
                new Quip
                {
                    Id = Guid.Parse("5091fed0-ce6e-4ad8-83bb-27a1fd8ce383"),
                    Title = "Let's Not Get Into Panic Mode!",
                    VideoUrl = "https://s3.amazonaws.com/djquipvid/ugPZfKJk.mp4",
                    ThumbnailUrl = "https://s3.amazonaws.com/djquipvid/ugPZfKJk_1.jpg",
                    UploaderId = users[1].Id,
                    MediaId = media[2].Id,
                    CreatedAt = now,
                    UpdatedAt = now,
                },
            };

            context.Users.AddRange(users);
            context.Media.AddRange(media);
            context.Quips.AddRange(quips);
            context.SaveChanges();
        }
    }
}

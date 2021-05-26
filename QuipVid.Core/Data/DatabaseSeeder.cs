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
                    Id = Guid.NewGuid(),
                    UserName = "levizitting",
                    CreatedAt = now,
                    UpdatedAt = now,
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "mykebates",
                    CreatedAt = now,
                    UpdatedAt = now,
                },
            };

            var media = new List<Media>
            {
                new Media
                {
                    Id = Guid.NewGuid(),
                    Title = "Silicon Valley",
                    CreatedAt = now,
                    UpdatedAt = now,
                },
                new Media
                {
                    Id = Guid.NewGuid(),
                    Title = "Napoleon Dynamite",
                    CreatedAt = now,
                    UpdatedAt = now,
                },
                new Media
                {
                    Id = Guid.NewGuid(),
                    Title = "Seinfeld",
                    CreatedAt = now,
                    UpdatedAt = now,
                },
            };

            var quips = new List<Quip>
            {
                new Quip
                {
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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

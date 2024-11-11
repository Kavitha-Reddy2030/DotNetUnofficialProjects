using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookFilterAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookFilterAPI.Data
{
    public class BookFilterDbContext : DbContext
    {
        public BookFilterDbContext(DbContextOptions<BookFilterDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<BookSize> BookSizes { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define GUIDs for new Authors
            var newAuthorId1 = Guid.NewGuid();
            var newAuthorId2 = Guid.NewGuid();

            // Define GUIDs for new BookSizes
            var newSizeId1 = Guid.NewGuid();
            var newSizeId2 = Guid.NewGuid();

            // Seeding Authors
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = newAuthorId1,
                    Name = "New Author 1",
                    Bio = "Bio of New Author 1.",
                    Birthdate = new DateTime(1980, 1, 1),
                    ProfileImageUrl = "https://example.com/images/new_author_1.jpg"
                },
                new Author
                {
                    Id = newAuthorId2,
                    Name = "New Author 2",
                    Bio = "Bio of New Author 2.",
                    Birthdate = new DateTime(1985, 2, 2),
                    ProfileImageUrl = "https://example.com/images/new_author_2.jpg"
                }
            );

            // Seeding BookSizes
            modelBuilder.Entity<BookSize>().HasData(
                new BookSize
                {
                    Id = newSizeId1,
                    Size = "Extra Small"
                },
                new BookSize
                {
                    Id = newSizeId2,
                    Size = "Extra Large"
                }
            );

            // Seeding Books with new Authors and Book Sizes
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "New Book 1",
                    Description = "Description for New Book 1.",
                    PublicationDate = new DateTime(2024, 1, 1),
                    CoverImageUrl = "https://example.com/images/new_book_1.jpg",
                    AuthorId = newAuthorId1, // Newly seeded author
                    BookSizeId = newSizeId1  // Newly seeded book size
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "New Book 2",
                    Description = "Description for New Book 2.",
                    PublicationDate = new DateTime(2024, 2, 1),
                    CoverImageUrl = "https://example.com/images/new_book_2.jpg",
                    AuthorId = newAuthorId2, // Newly seeded author
                    BookSizeId = newSizeId2  // Newly seeded book size
                }
            );

            // Existing data seeding (if needed)
            var jkRowlingId = Guid.NewGuid();
            var georgeRRMartinId = Guid.NewGuid();
            var smallSizeId = Guid.NewGuid();
            var mediumSizeId = Guid.NewGuid();
            var largeSizeId = Guid.NewGuid();

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = jkRowlingId,
                    Name = "J.K. Rowling",
                    Bio = "British author, best known for the Harry Potter series.",
                    Birthdate = new DateTime(1965, 7, 31),
                    ProfileImageUrl = "https://example.com/images/jk_rowling.jpg"
                },
                new Author
                {
                    Id = georgeRRMartinId,
                    Name = "George R.R. Martin",
                    Bio = "American author, known for the 'A Song of Ice and Fire' series.",
                    Birthdate = new DateTime(1948, 9, 20),
                    ProfileImageUrl = "https://example.com/images/george_rr_martin.jpg"
                }
            );

            modelBuilder.Entity<BookSize>().HasData(
                new BookSize
                {
                    Id = smallSizeId,
                    Size = "Small"
                },
                new BookSize
                {
                    Id = mediumSizeId,
                    Size = "Medium"
                },
                new BookSize
                {
                    Id = largeSizeId,
                    Size = "Large"
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Harry Potter and the Philosopher's Stone",
                    Description = "First book in the Harry Potter series.",
                    PublicationDate = new DateTime(1997, 6, 26),
                    CoverImageUrl = "https://example.com/images/harry_potter_1.jpg",
                    AuthorId = jkRowlingId,
                    BookSizeId = mediumSizeId
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "A Game of Thrones",
                    Description = "First book in the A Song of Ice and Fire series.",
                    PublicationDate = new DateTime(1996, 8, 6),
                    CoverImageUrl = "https://example.com/images/game_of_thrones.jpg",
                    AuthorId = georgeRRMartinId,
                    BookSizeId = largeSizeId
                }
            );
        }


        }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReadersNetwork.Models;

namespace ReadersNetwork.DAL
{
    public class ReadersInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ReadersContext>
    {
        protected override void Seed(ReadersContext context)
        {
            var users = new List<User>
            {
                new User("user1", "user1", "user1", new DateTime(1993, 2, 25), Gender.Male, "", "User 1 Summary"),
                new User("user2", "user2", "user2", new DateTime(1993, 12, 5), Gender.Male, "", "User 2 Summary"),
                new User("user3", "user3", "user3", new DateTime(1991, 12, 2), Gender.Male, "", "User 3 Summary"),
                new User("user4", "user4", "user4", new DateTime(1990, 5, 1), Gender.Male, "", "User 4 Summary"),
                new User("user5", "user5", "user5", new DateTime(1989, 7, 18), Gender.Male, "", "User 5 Summary"),
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var book1 = new Book
            {
                Id = 1,
                Name = "Book 1",
                Author = "Author 1",
                Description = "Description 1",
                Genres = Genres.Romance,
                PhotoUrls = new String[] { "" },
            };

            var book2 = new Book
            {
                Id = 2,
                Name = "Book 2",
                Author = "Author 1",
                Description = "Description 2",
                Genres = Genres.Biographgy,
                PhotoUrls = new String[] { "" }
            };

            var books = new List<Book>
            {
                book1,
                book2
            };

            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

            var questions = new List<Question>
            {
                new Question {
                    BookId = 1,
                    QuesId = 1,
                    Text = "Ques 1",
                    UserId = "user1"
                },
                new Question {
                    BookId = 1,
                    QuesId = 1,
                    Text = "Ques 2",
                    UserId = "user2"
                }
            };

            questions.ForEach(q => context.Questions.Add(q));
            context.SaveChanges();

            var answers = new List<Answer>
            {
                new Answer { QuesId = 1, Text = "Ans 1", UserId = "user2" },
                new Answer { QuesId = 1, Text = "Ans 21", UserId = "user1" },
                new Answer { QuesId = 1, Text = "Ans 22", UserId = "user3" }
            };

            answers.ForEach(a => context.Answers.Add(a));
            context.SaveChanges();

            var reviews = new List<Review>
            {
                new Review { BookId = 1, UserId = "user1", Rating = 4, ReviewText = "Review text by user 1" },
                new Review { BookId = 2, UserId = "user4", Rating = 3, ReviewText = "Review text by user 4" }
            };

            reviews.ForEach(r => context.Reviews.Add(r));
            context.SaveChanges();

            var posts = new List<Post>
            {
                new Post { UserId = "user1", Description = "Post 1", PostId = 1 },
                new Post { UserId = "user3", Description = "Post 2", PostId = 2 }
            };

            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
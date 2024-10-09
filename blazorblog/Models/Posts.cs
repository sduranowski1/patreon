using System;

namespace blazorblog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? ImageFileName { get; set; }

        // public int AuthorId { get; set; }
    //     public User Author { get; set; } // Assuming User model is also defined
    // }

    // public class User
    // {
    //     public int Id { get; set; }
    //     public string Username { get; set; }
    //     public string Email { get; set; }
    //     public string Password { get; set; }
    //     public DateTime CreatedAt { get; set; }
    }
}

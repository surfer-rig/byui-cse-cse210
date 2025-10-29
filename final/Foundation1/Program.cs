using System;
using System.Collections.Generic;

// Comment class
class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

// Video class
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("C# Tutorial", "Alice", 600);
        Video video2 = new Video("Guitar Lessons", "Bob", 900);
        Video video3 = new Video("Travel Vlog", "Charlie", 1200);

        // Add comments to video1
        video1.AddComment(new Comment("John", "Great tutorial!"));
        video1.AddComment(new Comment("Emma", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Sam", "Can you make one on lists?"));

        // Add comments to video2
        video2.AddComment(new Comment("Liam", "Awesome lesson!"));
        video2.AddComment(new Comment("Olivia", "Loved the guitar tips."));
        video2.AddComment(new Comment("Noah", "Very clear instructions."));

        // Add comments to video3
        video3.AddComment(new Comment("Ava", "Beautiful scenery!"));
        video3.AddComment(new Comment("Mason", "I want to visit this place."));
        video3.AddComment(new Comment("Sophia", "Amazing video!"));

        // Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video information
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"  {comment.Name}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40)); // separator
        }
    }
}

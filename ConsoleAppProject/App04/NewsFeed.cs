using System;
using System.Collections.Generic;
namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The NewsFeed class stores news posts for the
    /// news feed in a social network application.
    /// 
    /// Display of the posts is currently simulated
    /// by printing the details to the terminal.
    /// (Later, this should display in a browser.)
    /// 
    /// This version does not save the data to disk,
    /// and it does not provide any search or ordering
    /// functions.
    ///</summary>
    ///<author>
    /// Nicoara Danci
    /// @version 03/04/22
    ///</author>

    public class NewsFeed
    {
        private readonly List<Post> posts;

        ///<summary>
        /// Construct an empty news feed.
        ///</summary>
        public NewsFeed()
        {
            posts = new List<Post>();

        }


        ///<summary>
        /// Add a text post to the news feed.
        /// 
        /// @param text  The text post to be added.
        ///</summary>
        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        ///<summary>
        /// Add a photo post to the news feed.
        /// 
        /// @param photo  The photo post to be added.
        ///</summary>
        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        ///<summary>
        /// Show the news feed. Currently: print the news feed details to the
        /// terminal. (To do: replace this later with display in web browser.)
        ///</summary>
        public void Display()
        {
            // display all text posts
            foreach (Post post in posts)
            {
                post.Display();
                Console.WriteLine();   // empty line between posts
            }
        }

        /// <summary>
        /// Finds and retruns a post given a matching ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Post FindPost(int id)
        {
            return posts[id - 1];
        }

        /// <summary>
        /// Removes a post given a matching ID
        /// </summary>
        /// <param name="id"></param>
        public void RemovePost(int id)
        {
            Post post = FindPost(id);
            posts.Remove(post);
        }

        /// <summary>
        /// Displays all post from a particular user line by line
        /// </summary>
        /// <param name="author"></param>
        public void DisplayUsersPost(string author)
        {
            foreach (Post post in posts)
            {
                if (post.Username == author)
                {
                    post.Display();
                    Console.WriteLine("----------------------------");   // space between posts
                }
            }
        }

        /// <summary>
        /// This function uses the timestamps given by
        /// the user to display all posts within the
        /// given time range
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void DisplayTimeRangePost(DateTime startDate, DateTime endDate)
        {
            foreach (Post post in posts)
            {
                if (post.Timestamp >= startDate && post.Timestamp <= endDate)
                {
                    post.Display();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("----------------------------");   // space between posts
                }
            }
        }
    }

}
using System;
using ConsoleAppProject.Helpers;
namespace ConsoleAppProject.App04
{
    public class NetworkApp
    {

        ///<summary>
        /// This class contains the functionality to run
        /// the app and lists the choices for the user. 
        ///</summary>
        /// <author>
        /// Nicoara Danci
        /// @version 03/04/22
        /// </author>

        private NewsFeed news = new NewsFeed();

        private String[] choices =
        {
                "Post Message",
                "Post Image",
                "Display All Posts",
                "Display User's Post",
                "Comment",
                "Like",
                "Unlike",
                "Remove Post",
                "Find Post in time range",
                "Quit",
        };


        private string user;
        private DateTime startDate;
        private DateTime endDate;
        private string message;
        private string filename;
        private string caption;

        private bool quit;

        /// <summary>
        /// Outputs the heading and menu choices for the user 
        /// </summary>
        public void Run()
        {
            quit = false;
            do
            {
                ConsoleHelper.OutputHeading("      Nick's Social App");
                int choice = ConsoleHelper.SelectChoice(choices);
                switch (choice)
                {
                    case 1: PostMessage(); break;
                    case 2: PostImage(); break;
                    case 3: DisplayAll(); break;
                    case 4: DisplayUsersPost(); break;
                    case 5: AddComment(); break;
                    case 6: LikePost(); break;
                    case 7: UnlikePost(); break;
                    case 8: RemovePost(); break;
                    case 9: DisplayTimeRangePost(); break;
                    case 10: quit = true; break;
                }
            } while (!quit);
        }

        /// <summary>
        /// The method allows a user to post a message.
        /// It asks the user to input a name and a message.
        /// </summary>
        private void PostMessage()
        {
            ConsoleHelper.OutputTitle(" Adding new message post");
            Console.Write(" Please enter your name > ");
            user = Console.ReadLine();

            Console.Write(" Please enter your message > ");
            message = Console.ReadLine();

            MessagePost messagePost = new MessagePost(user, message);
            news.AddMessagePost(messagePost);

            ConsoleHelper.OutputTitle(" Congratulation ! You've posted the following message: ");
            messagePost.Display();
        }

        /// <summary>
        /// The method allows a user to post a image.
        /// </summary>
        private void PostImage()
        {
            ConsoleHelper.OutputTitle(" Adding new image ");
            Console.Write(" Please enter your name > ");
            user = Console.ReadLine();

            Console.Write(" Please enter your photo filename > ");
            filename = Console.ReadLine();

            Console.Write(" Please enter your caption > ");
            caption = Console.ReadLine();

            PhotoPost post = new PhotoPost(user, filename, caption);
            news.AddPhotoPost(post);

            ConsoleHelper.OutputTitle(" Congratulation ! You've posted the following photo:");
            post.Display();
        }

        /// <summary>
        /// The method prints all the posts that are in the system.
        /// </summary>
        private void DisplayAll()
        {
            ConsoleHelper.OutputTitle(" Displaying all Posts:");
            news.Display();
        }

        /// <summary>
        /// The method allows the user to see posts made by a specific user.
        /// </summary>
        private void DisplayUsersPost()
        {
            ConsoleHelper.OutputTitle("Displaying a specific user posts");
            Console.Write(" Please enter a Username > ");
            user = Console.ReadLine();

            ConsoleHelper.OutputTitle($"Displaying {user}'s Post");
            news.DisplayUsersPost(user);
        }

        /// <summary>
        ///The method allows the user to post a coment to a specific post.
        ///The post can be selected using it's ID. 
        /// </summary>
        private void AddComment()
        {
            ConsoleHelper.OutputTitle(" Adding a comment ");
            int id = (int)ConsoleHelper.InputNumber(" Please enter " +
                "the ID of the Post you wish to Comment on > ");
            Post post = news.FindPost(id);

            if (post != null)
            {

                Console.Write(" Please Enter Your Comment > ");
                string comment = Console.ReadLine();
                post.AddComment(comment);

            }
            else
            {
                Console.WriteLine(" This post does not exist");
            }

            ConsoleHelper.OutputTitle(" Comment Added");
        }

        /// <summary>
        /// The method allows users to like a specific post. 
        /// The post can be selected using it's ID. 
        /// </summary>
        private void LikePost()
        {
            ConsoleHelper.OutputTitle(" Adding a like ");
            int id = (int)ConsoleHelper.InputNumber(" Please enter " +
                "the ID of the Post you wish to Like > ");
            Post post = news.FindPost(id);

            if (post != null)
            {
                post.Like();
            }
            else
            {
                Console.WriteLine(" This post does not exist");
            }

            ConsoleHelper.OutputTitle(" Post liked!");
        }

        /// <summary>
        /// The method allows users to unlike a specific post. 
        /// The post can be selected using it's ID. 
        /// </summary>
        private void UnlikePost()
        {
            ConsoleHelper.OutputTitle(" Removing a like ");
            int id = (int)ConsoleHelper.InputNumber(" Please enter " +
                "the ID of the post you wish to Unlike > ");
            Post post = news.FindPost(id);

            post.Unlike();

            ConsoleHelper.OutputTitle(" Post unliked");
        }

        /// <summary>
        ///  The method allows users to remove a specific post. 
        /// The post can be selected using it's ID. 
        /// </summary>
        private void RemovePost()
        {
            ConsoleHelper.OutputTitle("Removing a post");
            int id = (int)ConsoleHelper.InputNumber(" Please enter " +
                "the ID of the post you wish to remove > ");
            Post post = news.FindPost(id);

            if (post != null)
            {
                Console.WriteLine($" Removing Post number {post.PostID}");
                news.RemovePost(id);
            }
            else
            {
                Console.WriteLine(" This post does not exist");
            }

            ConsoleHelper.OutputTitle(" Post Removed");
        }

        /// <summary>
        /// The method allows the user to search for
        /// a post within a timeframe
        /// </summary>
        private void DisplayTimeRangePost()
        {
            ConsoleHelper.OutputTitle(" Search for a post within a timeframe");
            Console.Write(" Please enter a start date for the timeframe (ex. 31.01.22) > ");
            startDate = DateTime.Parse(Console.ReadLine());

            Console.Write(" Please enter a end date for the timeframe (ex. 31.01.22) > ");
            endDate = DateTime.Parse(Console.ReadLine());

            ConsoleHelper.OutputTitle($"Displaying {startDate} - {endDate} Post");
            news.DisplayTimeRangePost(startDate, endDate);
        }
    }
}
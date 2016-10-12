using RedditSharp;
using RedditSharp.Things;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace RedWipeReborn
{
	internal class RedWipeEngine
	{
        private class CredentialsWrapper
        {
            public string Username;

            public string Password;

            public CredentialsWrapper(string username, string password)
            {
                Username = username;
                Password = password;
            }
        }

        public const int MaximumHistory = 1000;

        public const string ExemptionURL = @"https://raw.githubusercontent.com/gsuberland/RedWipeReborn/master/EXEMPT";

        private Reddit _reddit;

		private bool _loggedIn = false;

		public bool IsLoggedIn
		{
			get
			{
				return _loggedIn;
			}
		}

		public RedWipeEngine()
		{
			_reddit = new Reddit(true);
		}

        public async Task<string[]> GetSubredditExceptionsAsync()
        {
            var exceptions = new List<string>();

            using (var wc = new WebClient())
            {
                string exemptionData = await wc.DownloadStringTaskAsync(new Uri(ExemptionURL));
                using (var reader = new StringReader(exemptionData))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        // ignore comment lines and blank lines
                        if (line.StartsWith("#") || string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }
                        else
                        {
                            exceptions.Add(line);
                        }
                    }
                }
            }

            return exceptions.ToArray();
        }

        private Comment[] DoGetAllComments()
		{
			if (!_loggedIn)
			{
				throw new InvalidOperationException("Must log in first!");
			}

            return _reddit.User.Comments.ToArray();
		}

        public Task<Comment[]> GetAllCommentsAsync()
        {
            return Task.Factory.StartNew<Comment[]>(() => DoGetAllComments());
        }

        private Post[] DoGetAllPosts()
        {
            if (!_loggedIn)
            {
                throw new InvalidOperationException("Must log in first!");
            }
            return _reddit.User.Posts.ToArray();
        }

        public Task<Post[]> GetAllPostsAsync()
        {
            return Task.Factory.StartNew<Post[]>(() => DoGetAllPosts());
        }

        private bool DoLogin(CredentialsWrapper creds)
		{
			bool flag;
			try
			{
				try
				{
					_loggedIn = false;
					_reddit.LogIn(creds.Username, creds.Password, true);
					_loggedIn = true;
					flag = true;
				}
				catch (TargetInvocationException targetInvocationException)
				{
					TargetInvocationException tiEx = targetInvocationException;
					if (tiEx.InnerException != null)
					{
						throw tiEx.InnerException;
					}
					throw;
				}
			}
			catch (AuthenticationException)
			{
				flag = false;
			}
			catch (RedditException)
			{
				flag = false;
			}
			return flag;
		}

		public Task<bool> LoginAsync(string username, string password)
		{
			Task<bool> task = Task.Factory.StartNew<bool>(
                (object o) => DoLogin((CredentialsWrapper)o),
                new CredentialsWrapper(username, password));

			return task;
		}

		public void Logout()
		{
			_loggedIn = false;
		}
	}
}
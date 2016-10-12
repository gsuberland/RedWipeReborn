using RedditSharp;
using RedditSharp.Things;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading.Tasks;

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
                this.Username = username;
                this.Password = password;
            }
        }

        public const int MaximumHistory = 1000;

		private Reddit _reddit;

		private bool _loggedIn = false;

		public bool IsLoggedIn
		{
			get
			{
				return this._loggedIn;
			}
		}

		public RedWipeEngine()
		{
			this._reddit = new Reddit(true);
		}

		private IEnumerable<Comment> DoGetAllComments()
		{
			if (!this._loggedIn)
			{
				throw new InvalidOperationException("Must log in first!");
			}
			Listing<Comment> comments = this._reddit.User.GetComments(Sort.New, MaximumHistory, FromTime.All);
			return comments.AsEnumerable<Comment>();
		}

		private bool DoLogin(CredentialsWrapper creds)
		{
			bool flag;
			try
			{
				try
				{
					this._loggedIn = false;
					this._reddit.LogIn(creds.Username, creds.Password, true);
					this._loggedIn = true;
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

		public Task<IEnumerable<Comment>> GetAllCommentsAsync()
		{
			return Task.Factory.StartNew<IEnumerable<Comment>>(() => this.DoGetAllComments());
		}

		public Task<bool> LoginAsync(string username, string password)
		{
			Task<bool> task = Task.Factory.StartNew<bool>(
                (object o) => this.DoLogin((CredentialsWrapper)o),
                new CredentialsWrapper(username, password));

			return task;
		}

		public void Logout()
		{
			this._loggedIn = false;
		}
	}
}
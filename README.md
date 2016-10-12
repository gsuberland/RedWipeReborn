# RedWipe Reborn

Erase your Reddit history.

RedWipe Reborn is a re-write and continuation of the [Red Wipe](https://github.com/crashcoredump/RedWipe) account wiper tool for Reddit.

Reddit has stated in the past that deleting your comments does not prevent a "ghost" copy of the final comment text from remaining saved on their servers, possibly even if you deactivate your account. This utility is designed to automatically remove your last 1000 Reddit posts, and all comments, permenantly.

## How it works

RedWipe Reborn uses the Reddit API to download a list of your comments and posts. After enumerating all content possible, it performs the following actions:

* Deletes your 1000 most recent posts (see below).
* Edits all of your comments to contain a deletion message.
* Deletes all of your comments.

The hope is that, in editing your comments before deletion, the final "ghost" copy of your comments are useless deletion messages, rather than your actual comments.

Note: Only your 1000 most recent posts can be deleted due to a restriction in the Reddit API.

## Caveats

The following caveats apply:

* Reddit comments can and will be indexed by third parties, including Google and Wayback. This tool cannot remove these copies.
* There are services designed to specifically "undelete" reddit threads by copying and publishing the contents elsewhere. This tool cannot remove these copies.
* Certain subreddits may reserve the right to being exempt from RedWipe Reborn. You can view this list [here](https://github.com/gsuberland/RedWipeReborn/blob/master/EXEMPT).

This tool is not a silver bullet. Once something is on the internet, it is very hard to ensure that it is really deleted. Think carefully before you post something you can't take back.

## Subreddit Exemption

If you moderate a subreddit and feel that RedWipe Reborn is disrupting your community, you may submit a request to be added to the [exemption list](https://github.com/gsuberland/RedWipeReborn/blob/master/EXEMPT).

To submit a request, send a PM to [/u/gsuberland](https://www.reddit.com/user/gsuberland/) explaining that you'd like to have your subreddit exempt. You **must** send this message from an acccount that is listed as a moderator on the subreddit in question.

Please keep in mind that RedWipe Reborn is open source software, and can be modified by anyone. This means that it is possible for users to bypass the exemption list if they change the code. This feature remains only as a courtesy to subreddit moderators.

## Contribution

Pull requests are welcomed. Please comment your code and try to stick to the same code style as the rest of the project.

## License

This project is licensed under the [MIT License](https://github.com/gsuberland/RedWipeReborn/blob/master/LICENSE).

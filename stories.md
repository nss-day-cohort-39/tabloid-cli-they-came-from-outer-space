# Tabloid CLI Stories

**NOTE TO SELF:** In the readme talk about the general structure of the program.
Command line, menu driven.

## Main Menu

### Application Background Color

As the application user, I get tired of boring black backgrounds, so I would like to have a more enjoyable background color.

As a non-technical person, however, I don't know what my options are. I would appreciate the team giving me some choices.



### Main Menu Header

As the application user, I would like to see a pleasant greeting when I start the application because I like pleasant greetings.

**Given** a user starts the program from the command line  
**When** the program starts  
**Then** a pleasant greeting should appear above the main menu



### Main Menu Options

As an application user, I would like to see a list of my options when I start the application.

**Given** the user has started the program
Or the user has returned to the main menu from a child menu  
**When** the maim menu appears  
**Then** the following options should be displayed

- My Journal Management
- Blog Management
- Author Management
- Post Management
- Tag Management
- Search by Tag
- Exit



Menu Selection

As an application user, I would like to easily navigate around the application by typing in the number of of a particular menu item in order to trigger that menu items functionality.

**Given** the following menu

```txt
Post Menu
 1) List Posts
 2) Add Post
 3) Edit Post
 4) Remove Post
 5) Note Management
 0) Return to Main Menu
```

**When** the user enters `2`  
**Then** they should be presented with the ability to add a new post.


## Journal Entries

### Add Journal Entry

As an introspective person I would like to record my thoughts so that I may revisit the later.

A Journal Entry should have:

- A title
- Text content
- A creation data

**Given** the user is viewing the Journal Management menu  
**When** they select the option to add a journal entry  
**Then** they should be prompted to enter the new entry's title and content
**Then** the new journal entry should be saved to the database with the current date and time saved as the creation date



### List Journal Entries

As an introspective person, I would like to see a list of my previous journal entires so that I can revisit my thoughts over time.

**Given** the user is viewing the Journal Management menu  
**When** they select the option to list journal entries  
**Then** they should be presented with a list of journal entries including title, creation date and text content


### Remove Journal Entry

As an introspective person, I would like the ability to remove a journal entry so that I can get something I regret writing out of my life.

**Given** the user is viewing the Journal Management menu  
**When** they select the option to remove a journal entry  
**Then** they should be presented with a list of entries to choose from  

**Given** the user chooses an entry  
**When** they enter the selection and hit enter  
**Then** the journal entry should be removed from the database



### Edit Journal Entry

As an introspective person, I would like the ability to edit my journal entries so that I can clarify my thoughts and/or fix spelling and grammatical errors.

**Given** the user is viewing the Journal Management menu  
**When** they select the option to edit a journal entry  
**Then** they should be presented with a list of entries to choose from  

**Given** the user chooses an entry  
**When** they enter the selection and hit enter  
**Then** the user should be given the ability to enter new information for the entry's title and content

**Given** the user has been prompted to enter a new value for a property  
**When** the user hits `enter` without typing anything  
**Or When** the user only enters spaces  
**Then** the property's value should NOT be changed  

> **NOTE:** the user should NOT be able to change the creation date



## Authors

### Add Author

As a blog connoisseur I would like to save blog authors so that I can keep track of my favorites.

An Author should have:

- A first name
- A last name
- A short bio

**Given** the user is viewing the Author Management menu  
**When** they select the option to add an author  
**Then** they should be prompted to enter the new author's first name, last name and bio  
**Then** the new author should be saved to the database  



### List Authors

As a blog connoisseur I would like to view a list of my blog authors so that I can refresh my memory as to my favorites.

**Given** the user is viewing the Author Management menu  
**When** they select the option to list authors  
**Then** they should see each Author's first and last name  



### Author Details

As a blog connoisseur I would like to view details of a blog author so that I can refresh my memory as to who they are.

**Given** the user is viewing the Author Management menu  
**When** they select the option to view author details  
**Then** they should be presented with a list of authors to choose from  

**Given** the user chooses an author  
**When** they enter the selection and hit enter  
**Then** the Author Details menu should be displayed

For Example:

```txt
Felienne Hermans Details
 1) View
 2) Add Tag
 3) Remove Tag
 4) View Posts
 0) Return
```

**Given** the user wishes to view the author details  
**When** they select "View"  
**Then** the author's first name, last name and bio should be displayed.  

> **NOTE:** The other menu options will be outlined in future stories.



### Remove Author

As a blog connoisseur I would like to remove a blog author from my list so that I can keep the list limited to my current favorites.

**Given** the user is viewing the Author Management menu  
**When** they select the option to remove an author  
**Then** they should be presented with a list of authors to choose from  

**Given** the user chooses an author  
**When** they enter the selection and hit enter  
**Then** the author should be removed from the database  



### Edit Author

As a blog connoisseur I would like to edit a blog author’s details so that I can ensure their information is up to date.

**Given** the user is viewing the Author Management menu  
**When** they select the option to edit an author  
**Then** they should be presented with a list of authors to choose from  

**Given** the user chooses an author  
**When** they enter the selection and hit enter  
**Then** the user should be given the ability to enter new information for the author's first name, last name and bio  

**Given** the user has been prompted to enter a new value for a property  
**When** the user hits `enter` without typing anything  
**Or When** the user only enters spaces  
**Then** the property's value should NOT be changed  



### View Author's Blog Posts

As a blog connoisseur I would like to see all blog posts written by a particular author so that I can more easily find a blog post I am searching for.

**Given** the user is viewing the Author Detail menu  
**When** they select the option to view blog posts  
**Then** they should be presented with a list of the author's blog posts



### Add Tag to Author

As a blog connoisseur I would like to tag a blog author with a keyword to make searching easier.

**Given** the user is viewing the Author Details menu  
**When** they select the option to add a tag  
**Then** they should be presented with a list of available tags to choose from  

**Given** the user chooses a tag  
**When** they enter the selection and hit enter  
**Then** the relationship between the tag and the author should be saved to the database  



### View Author's Tags

As a blog connoisseur I would like to see the tags for a particular blog author when viewing the author’s details, so I can quickly see keywords about the author.

**Given** the user is viewing the Author Details menu  
**When** they select the option to view details  
**Then** they should be presented with the list of the author's tags in addition to the author's other information  



### Remove Tag from Author

As a blog connoisseur I would like to be able to remove a tag/keyword from an author in the event that it no longer applies. 

**Given** the user is viewing the Author Details menu  
**When** they select the option to remove a tag  
**Then** they should be presented with the list of the author's tags in order to choose the tag to remove  

**Given** the user chooses a tag to remove
**When** they type in the selection and hit enter  
**Then** the relationship between the author and the tag should be removed from the database



## Blogs

## Add Blog

As a blog connoisseur I would like to add a blog to my list of favorites, so that I can keep track of new blogs I encounter.

An Blog should have:

- A Title
- A URL

**Given** the user is viewing the Blog Management menu  
**When** they select the option to add a blog  
**Then** they should be prompted to enter the new blog's title and url  
**Then** the new blog should be saved to the database  



### List Blogs

As a blog connoisseur I would like to view a list of my blogs so that I can pick a blog to read.

**Given** the user is viewing the Blog Management menu  
**When** they select the option to list blogs  
**Then** they should see each blog's title and url  



### Blog Details

As a blog connoisseur I would like to view details of a blog so that I can focus on a particular blog and not the entire list of blogs.

**Given** the user is viewing the Blog Management menu  
**When** they select the option to view blog details  
**Then** they should be presented with a list of blogs to choose from  

**Given** the user chooses an blog  
**When** they enter the selection and hit enter  
**Then** the Blog Details menu should be displayed

**Given** the user wishes to view the blog details  
**When** they select "View"  
**Then** the blog's title and url should be displayed  

The Blog Detail menu should have the following options:

- View
- Add Tag
- Remove Tag
- View Posts
- Return

> **NOTE:** The other menu options will be outlined in future stories.



### Edit Blog

As a blog connoisseur I would like to be able to edit blog’s details so that I can keep the information up to date. 

**Given** the user is viewing the Blog Management menu  
**When** they select the option to edit a blog  
**Then** they should be presented with a list of blogs to choose from  

**Given** the user chooses a blog  
**When** they enter the selection and hit enter  
**Then** the user should be given the ability to enter new information for the blog's title and url  

**Given** the user has been prompted to enter a new value for a property  
**When** the user hits `enter` without typing anything  
**Or When** the user only enters spaces  
**Then** the property's value should NOT be changed  



### Remove Blog

As a blog connoisseur I would like to be able to remove a blog from my list so that I can keep the list limited to my current favorites. 

**Given** the user is viewing the Blog Management menu  
**When** they select the option to remove a blog  
**Then** they should be presented with a list of blogs to choose from  

**Given** the user chooses an blog  
**When** they enter the selection and hit enter  
**Then** the blog should be removed from the database  



### View Blog's Posts

As a blog connoisseur I would like to be able to see all the blog posts for a particular blog so that I can more easily find a post I’m searching for.

**Given** the user is viewing the Blog Detail menu  
**When** they select the option to view blog posts  
**Then** they should be presented with a list of the blog's blog posts



### Add Tag to Blog

As a blog connoisseur I would like to tag a blog with a keyword to make searching easier.

**Given** the user is viewing the Blog Details menu  
**When** they select the option to add a tag  
**Then** they should be presented with a list of available tags to choose from  

**Given** the user chooses a tag  
**When** they enter the selection and hit enter  
**Then** the relationship between the tag and the blog should be saved to the database  



### View Blog's Tags

As a blog connoisseur I would like to see the tags for a particular blog when viewing the blog’s details, so I can quickly see keywords about the blog.

**Given** the user is viewing the Blog Details menu  
**When** they select the option to view details  
**Then** they should be presented with the list of the blog's tags in addition to the blog's other information  



### Remove Tag from Blog

As a blog connoisseur I would like to be able to remove a tag/keyword from a blog in the event that it no longer applies.

**Given** the user is viewing the Blog Details menu  
**When** they select the option to remove a tag  
**Then** they should be presented with the list of the blog's tags in order to choose the tag to remove  

**Given** the user chooses a tag to remove
**When** they type in the selection and hit enter  
**Then** the relationship between the blog and the tag should be removed from the database



## Posts

## Add Post

As a post connoisseur I would like to add a post to my list of favorites, so that I can keep track of new posts I encounter.

A Post should have:

- A title
- A URL
- A publication date
- An Author object
- A Blog object

**Given** the user is viewing the Post Management menu  
**When** they select the option to add a post  
**Then** they should be prompted to enter the new post's title, url and publish date  
**Then** they should be presented with a list of Authors to choose from (This should behave as other selection list do throughout the app)
**Then** they should be presented with a list of Blogs to choose from (This should behave as other selection list do throughout the app)
**Then** the new post should be saved to the database  



### List Posts

As a post connoisseur I would like to view a list of my posts so that I can pick a post to read.

**Given** the user is viewing the Post Management menu  
**When** they select the option to list posts  
**Then** they should see each post's title and url  



### Post Details

As a post connoisseur I would like to view details of a post so that I can focus on a particular post and not the entire list of posts.

**Given** the user is viewing the Post Management menu  
**When** they select the option to view post details  
**Then** they should be presented with a list of posts to choose from  

**Given** the user chooses a post  
**When** they enter the selection and hit enter  
**Then** the Post Details menu should be displayed

**Given** the user wishes to view the post details  
**When** they select "View"  
**Then** the post's title, url and publication date should be displayed  

The Post Detail menu should have the following options:

- View
- Add Tag
- Remove Tag
- Note Management
- Return

> **NOTE:** The other menu options will be outlined in future stories.



### Edit Post

As a post connoisseur I would like to be able to edit post’s details so that I can keep the information up to date. 

**Given** the user is viewing the Post Management menu  
**When** they select the option to edit a post  
**Then** they should be presented with a list of posts to choose from  

**Given** the user chooses a post  
**When** they enter the selection and hit enter  
**Then** the user should be given the ability to enter new information for the post's title, url, publication date, author and blog  

**Given** the user has been prompted to enter a new value for a property  
**When** the user hits `enter` without typing anything  
**Or When** the user only enters spaces  
**Then** the property's value should NOT be changed  

> **NOTE:** Use selection lists to provide the ability to change the Author and Blog



### Remove Post

As a post connoisseur I would like to be able to remove a post from my list so that I can keep the list limited to my current favorites.

**Given** the user is viewing the Post Management menu  
**When** they select the option to remove a post  
**Then** they should be presented with a list of posts to choose from  

**Given** the user chooses a post  
**When** they enter the selection and hit enter  
**Then** the post should be removed from the database  




### Add Tag to Post

As a post connoisseur I would like to tag a post with a keyword to make searching easier.

**Given** the user is viewing the Post Details menu  
**When** they select the option to add a tag  
**Then** they should be presented with a list of available tags to choose from  

**Given** the user chooses a tag  
**When** they enter the selection and hit enter  
**Then** the relationship between the tag and the post should be saved to the database  



### View Post's Tags

As a post connoisseur I would like to see the tags for a particular post when viewing the post’s details, so I can quickly see keywords about the post.

**Given** the user is viewing the Post Details menu  
**When** they select the option to view details  
**Then** they should be presented with the list of the post's tags in addition to the post's other information  



### Remove Tag from Post

As a post connoisseur I would like to be able to remove a tag/keyword from a post in the event that it no longer applies.

**Given** the user is viewing the Post Details menu  
**When** they select the option to remove a tag  
**Then** they should be presented with the list of the post's tags in order to choose the tag to remove  

**Given** the user chooses a tag to remove
**When** they type in the selection and hit enter  
**Then** the relationship between the post and the tag should be removed from the database



## Notes

### Note Management

As a blog connoisseur I would like to be able to manage my personal notes about a particular blog post so that I can keep track of my thoughts about the post.

**Given** the user is viewing the Post Detail menu  
**When** they select the option to manage notes
**Then** they should be presented with the Note Management menu

The menu should contain the following options:

- List Notes
- Add Note
- Remove Note
- Return



### Add Note

As a post connoisseur I would like to add a note to a blog post so that I can record my thoughts about the post.

A Note should have:

- A title
- Text content
- A creation date and time
- A related Post

**Given** the user is viewing the Note Management menu for a particular Post  
**When** they select the option to add a note  
**Then** they should be prompted to enter the new post's title and text content  
**Then** the new post should be saved to the database with the Note's Post set to the current Post and the Note's creation date set to Now  



### List Notes

As a post connoisseur I would like to view a list of my notes about a post so I can reread what I've written about the post.

**Given** the user is viewing the Note Management menu  
**When** they select the option to list notes  
**Then** they should see each note's title, creation date and text content



### Remove Note

As a post connoisseur I would like to be able to remove a Note associated with a Post so that I can sweep away any ridiculous thoughts I may have had in the past.

**Given** the user is viewing the Note Management menu  
**When** they select the option to remove a note  
**Then** they should be presented with a list of notes to choose from  

**Given** the user chooses a note  
**When** they enter the selection and hit enter  
**Then** the note should be removed from the database  



## Tags

### Add Tag

As an application user I would like to be able to add a new keyword that I can use to tag a blog, author or post throughout the application so that I can have access to the keywords I think are appropriate.

**Given** the user is viewing the Tag Management menu  
**When** they select the option to add a tag  
**Then** they should be prompted to enter the new tag's name  



### List Tags

As an application user I would like to be able to view a list of keywords that I might use to tag blogs, authors and posts so that I can determine if there are any missing or any that I no longer want.

**Given** the user is viewing the Tag Management menu  
**When** they select the option to list tags  
**Then** they should see each tag's name  



### Edit Tag

As a post connoisseur I would like to be able to edit tag so that I can use a more appropriate value.

**Given** the user is viewing the Tag Management menu  
**When** they select the option to edit a tag  
**Then** they should be presented with a list of tags to choose from  

**Given** the user chooses a tag  
**When** they enter the selection and hit enter  
**Then** the user should be given the ability to enter new information for the tag's name  

**Given** the user has been prompted to enter a new value for a property  
**When** the user hits `enter` without typing anything  
**Or When** the user only enters spaces  
**Then** the property's value should NOT be changed  



### Remove Tag

As a post connoisseur I would like to be able to remove a tag when I feel it is no longer needed.

**Given** the user is viewing the Tag Management menu  
**When** they select the option to remove a tag  
**Then** they should be presented with a list of tags to choose from  

**Given** the user chooses a post  
**When** they enter the selection and hit enter  
**Then** the tag should be removed from the database  



## Search

### Search Menu

As a blog connoisseur I would like the ability to search for blogs, authors anb posts by tagged keyword so that I can find wat I'm looking for more easily.

The search menu should have the following options:

- Search Blogs
- Search Authors
- Search Posts
- Search All
- Return to Main Menu

**Given** the user has is on the Main menu  
**When** they select the search by tag option  
**Then** they should be presented with the search menu


### Search Blogs

**Given** the user is on the search menu  
**When** they select the search blogs option  
**Then** they should be prompted to enter a tag name  

**Given** the suer enters a tag name
**When** there is no blog that matches the tag name
**Then** the user should be informed that no search results were found

**Given** the user enters a tag name  
**When** there is one or more blogs that match the tag name
**Then** the blogs should be displayed


### Search Authors

**Given** the user is on the search menu  
**When** they select the search authrs option  
**Then** they should be prompted to enter a tag name  

**Given** the suer enters a tag name
**When** there is no author that matches the tag name
**Then** the user should be informed that no search results were found

**Given** the user enters a tag name  
**When** there is one or more authors that match the tag name
**Then** the authors should be displayed


### Search Posts

**Given** the user is on the search menu  
**When** they select the search posts option  
**Then** they should be prompted to enter a tag name  

**Given** the suer enters a tag name
**When** there is no post that matches the tag name
**Then** the user should be informed that no search results were found

**Given** the user enters a tag name  
**When** there is one or more posts that match the tag name
**Then** the posts should be displayed



### Search All

**Given** the user is on the search menu  
**When** they select the search all option  
**Then** they should be prompted to enter a tag name  

**Given** the suer enters a tag name
**When** there is no blog, author or post that matches the tag name
**Then** the user should be informed that no search results were found

**Given** the user enters a tag name  
**When** there is one or more blogs that match the tag name
**Then** the blogs should be displayed
**When** there is one or more authors that match the tag name
**Then** the authors should be displayed
**When** there is one or more posts that match the tag name
**Then** the posts should be displayed

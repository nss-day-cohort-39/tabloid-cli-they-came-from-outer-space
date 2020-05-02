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
Or the user only enters spaces  
**Then** the property's value should NOT be change  

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

As a blog connoisseur I would like to view a list of my favorite blog authors so that I can refresh my memory as to my favorites. 

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
Or the user only enters spaces  
**Then** the property's value should NOT be change  



### View Author's Blog Posts

As a blog connoisseur I would like to see all blog posts written by a particular author so that I can more easily find a blog post I am searching for. 

**Given** the user is viewing the Author Management menu  
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

### List Blogs

As a blog connoisseur I would like to view a list of my favorite blogs so that I can pick a blog to read. 



## Add Blog

As a blog connoisseur I would like to add a blog to my list of favorites, so that I can keep track of new blogs I encounter.



### Edit Blog

As a blog connoisseur I would like to be able to edit blog’s details so that I can keep the information up to date. 



### Remove Blog

As a blog connoisseur I would like to be able to remove a blog from my list so that I can keep the list limited to my current favorites. 



### View Blog's Posts

As a blog connoisseur I would like to be able to see all the blog posts for a particular blog so that I can more easily find a post I’m searching for.



### A Tag to Blog

As a blog connoisseur I would like the ability tag a blog with a keyword to make searching easier. 



### View Blog's Tags

As a blog connoisseur I would like to see the tags for each blog when I view the list of blogs so that I can quickly see keywords about each blog. 



### Remove Tag from Blog

As a blog connoisseur I would like the ability to remove a tag/keyword from a blog in the event that it no longer applies. 



## Posts





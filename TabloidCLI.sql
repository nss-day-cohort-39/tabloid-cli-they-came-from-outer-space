USE [master]

IF db_id('TabloidCLI') IS NULl
BEGIN
    CREATE DATABASE [TabloidCLI]
END;
GO

use [TabloidCLI]
go

DROP TABLE IF EXISTS Journal;
DROP TABLE IF EXISTS BlogTag;
DROP TABLE IF EXISTS PostTag;
DROP TABLE IF EXISTS AuthorTag;
DROP TABLE IF EXISTS Tag;
DROP TABLE IF EXISTS Note;
DROP TABLE IF EXISTS Post;
DROP TABLE IF EXISTS Blog;
DROP TABLE IF EXISTS Author;


CREATE TABLE Author (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(55) NOT NULL,
    LastName NVARCHAR(55) NOT NULL,
    Bio TEXT
);

CREATE TABLE Blog (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Title NVARCHAR(55) NOT NULL,
    URL NVARCHAR(2000) NOT NULL
);

CREATE TABLE Post (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Title NVARCHAR(55) NOT NULL,
    URL NVARCHAR(2000) NOT NULL,
    PublishDateTime DATETIME NOT NULL,
    AuthorId INTEGER NOT NULL,
    BlogId INTEGER NOT NULL,

    CONSTRAINT FK_Post_Author FOREIGN KEY(AuthorId) REFERENCES Author(Id),
    CONSTRAINT FK_Post_Blog FOREIGN KEY(BlogId) REFERENCES Blog(Id)
);

CREATE TABLE Note (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Title NVARCHAR(55) NOT NULL,
    Content TEXT NOT NULL,
    CreateDateTime DATETIME NOT NULL,
    PostId INTEGER NOT NULL,
    
    CONSTRAINT FK_Note_Posti FOREIGN KEY(PostId) REFERENCES Post(Id)
);

CREATE TABLE Tag (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Name NVARCHAR(55) NOT NULL
);

CREATE TABLE AuthorTag (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    AuthorId INTEGER NOT NULL,
    TagId INTEGER NOT NULL,

    CONSTRAINT FK_AuthorTag_Author FOREIGN KEY(AuthorId) REFERENCES Author(Id),
    CONSTRAINT FK_AuthorTag_Tag FOREIGN KEY(TagId) REFERENCES Tag(Id)
);

CREATE TABLE PostTag (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    PostId INTEGER NOT NULL,
    TagId INTEGER NOT NULL,

    CONSTRAINT FK_PostTag_Post FOREIGN KEY(PostId) REFERENCES Post(Id),
    CONSTRAINT FK_PostTag_Tag FOREIGN KEY(TagId) REFERENCES Tag(Id)
);

CREATE TABLE BlogTag (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    BlogId INTEGER NOT NULL,
    TagId INTEGER NOT NULL,

    CONSTRAINT FK_BlogTag_Blog FOREIGN KEY(BlogId) REFERENCES Blog(Id),
    CONSTRAINT FK_BlogTag_Tag FOREIGN KEY(TagId) REFERENCES Tag(Id)
);

CREATE TABLE Journal (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Title NVARCHAR(55) NOT NULL,
    Content TEXT NOT NULL,
    CreateDateTime DATETIME NOT NULL
);


INSERT INTO Author ( FirstName, LastName, Bio) VALUES ( 'Scott', 'Hanselman', '.net advocate. Works at Micrsoft' );
INSERT INTO Author ( FirstName, LastName, Bio) VALUES ( 'Eric',  'Elliott', 'Opinionated javascript developer' );
INSERT INTO Author ( FirstName, LastName, Bio) VALUES ( 'Felienne', 'Hermans', ' associate professor at the Leiden Institute of Advanced Computer Science at Leiden University, where head the PERL group that researches programming education');
INSERT INTO Author ( FirstName, LastName, Bio) VALUES ( 'Jake', 'Archibald', 'Javascript dev, developer relations at Google' );
INSERT INTO Author ( FirstName, LastName, Bio) VALUES ( 'Julie', 'Lerman', 'Entity Framework expert' );

INSERT INTO Blog (Title, URL) VALUES ( 'The Data Farm', 'https://thedatafarm.com/blog/' );
INSERT INTO Blog (Title, URL) VALUES ( '.NET Blog', 'https://devblogs.microsoft.com/dotnet/' );
INSERT INTO Blog (Title, URL) VALUES ( 'felienne.com', 'https://www.felienne.com/' );
INSERT INTO Blog (Title, URL) VALUES ( 'NETFLIX Tech Blog', 'https://netflixtechblog.com/' );
INSERT INTO Blog (Title, URL) VALUES ( 'jakearchibald.com', 'https://jakearchibald.com/' );
INSERT INTO Blog (Title, URL) VALUES ( 'Develop Together', 'https://dev.to/' );
INSERT INTO Blog (Title, URL) VALUES ( 'Scott Hanselman Blog', 'https://www.hanselman.com/blog/' );
INSERT INTO Post ( Title, URL, PublishDateTime, AuthorId, BlogId ) VALUES ('Forms of notional machines', 'https://www.felienne.com/archives/6392', '2019-07-12', 3, 3);

--INSERT INTO Note ( Title, Content, CreateDateTime, PostId ) VALUES ();

INSERT INTO Tag ( Name ) VALUES ( 'nerdy' );

--INSERT INTO AuthorTag ( AuthorId, TagId) VALUES ( );

--INSERT INTO PostTag ( PostId, TagId ) VALUES ( );

--INSERT INTO BlogTag ( BlogId, TagId ) VALUES ( );

INSERT INTO Journal ( Title, Content, CreateDateTime ) VALUES ( 'My Big Day', 'I had a big day today. Would you believe I saw a dog????', '2020-04-30' ) ;


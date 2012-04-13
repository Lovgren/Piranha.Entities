﻿CREATE TABLE [Users] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[GroupId] UNIQUEIDENTIFIER NULL,
	[Login] NVARCHAR(64) NOT NULL,
	[Password] NVARCHAR(64) NULL,
	[Firstname] NVARCHAR(128) NULL,
	[Surname] NVARCHAR(128) NULL,
	[Email] NVARCHAR(128) NULL,
	[Culture] NVARCHAR(5) NULL,
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL,
	[CreatedById] UNIQUEIDENTIFIER NULL,
	[UpdatedById] UNIQUEIDENTIFIER NULL,
	CONSTRAINT PK_UserId PRIMARY KEY ([Id]),
	CONSTRAINT FK_UserGroup FOREIGN KEY ([GroupId]) REFERENCES [Groups] ([Id])
);

CREATE TABLE [Groups] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[ParentId] UNIQUEIDENTIFIER NULL,
	[Name] NVARCHAR(64) NOT NULL,
	[Description] NVARCHAR(255) NULL,
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL,
	[CreatedById] UNIQUEIDENTIFIER NULL,
	[UpdatedById] UNIQUEIDENTIFIER NULL,
	CONSTRAINT PK_GroupId PRIMARY KEY ([Id]),
	CONSTRAINT FK_GroupCreatedBy FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]),
	CONSTRAINT FK_GroupUpdatedBy FOREIGN KEY ([UpdatedById]) REFERENCES [Users] ([Id])
);

CREATE TABLE [Permissions] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[GroupId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(64) NOT NULL,
	[Description] NVARCHAR(255) NULL,
	[IsLocked] BIT NOT NULL default(0),
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL,
	[CreatedById] UNIQUEIDENTIFIER NULL,
	[UpdatedById] UNIQUEIDENTIFIER NULL,
	CONSTRAINT PK_PermissionId PRIMARY KEY ([Id]),
	CONSTRAINT FK_PermissionCreatedBy FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]),
	CONSTRAINT FK_PermissionUpdatedBy FOREIGN KEY ([UpdatedById]) REFERENCES [Users] ([Id])
);

CREATE TABLE [Params] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(64) NOT NULL,
	[Value] NVARCHAR(128) NULL,
	[Description] NVARCHAR(255) NULL,
	[IsLocked] BIT NOT NULL default(0),
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL,
	[CreatedById] UNIQUEIDENTIFIER NULL,
	[UpdatedById] UNIQUEIDENTIFIER NULL,
	CONSTRAINT PK_ParamId PRIMARY KEY ([Id]),
	CONSTRAINT FK_ParamCreatedBy FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]),
	CONSTRAINT FK_ParamUpdatedBy FOREIGN KEY ([UpdatedById]) REFERENCES [Users] ([Id])
);

CREATE TABLE [PageTemplates] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(64) NOT NULL,
	[Description] NVARCHAR(255) NULL,
	[Preview] NTEXT NULL,
	[Regions] NTEXT NULL,
	[ViewTemplate] NVARCHAR(128) NULL,
	[ShowViewTemplate] BIT NOT NULL default(0),
	[ViewRedirect] NVARCHAR(128) NULL,
	[ShowViewRedirect] BIT NOT NULL default(0),
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL,
	[CreatedById] UNIQUEIDENTIFIER NOT NULL,
	[UpdatedById] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_PageTemplateId PRIMARY KEY ([Id]),
	CONSTRAINT FK_PageTemplateCreatedBy FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]),
	CONSTRAINT FK_PageTemplateUpdatedBy FOREIGN KEY ([UpdatedById]) REFERENCES [Users] ([Id])
);

CREATE TABLE [PostTemplates] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(64) NOT NULL,
	[Description] NVARCHAR(255) NULL,
	[Preview] NTEXT NULL,
	[ViewTemplate] NVARCHAR(128) NULL,
	[ShowViewTemplate] BIT NOT NULL default(0),
	[ArchiveTemplate] NVARCHAR(128) NULL,	
	[ShowArchiveTemplate] BIT NOT NULL default(0),
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL,
	[CreatedById] UNIQUEIDENTIFIER NOT NULL,
	[UpdatedById] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_PostTemplateId PRIMARY KEY ([Id]),
	CONSTRAINT FK_PostTemplateCreatedBy FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]),
	CONSTRAINT FK_PostTemplateUpdatedBy FOREIGN KEY ([UpdatedById]) REFERENCES [Users] ([Id])
);

CREATE TABLE [PropertyTemplates] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[TemplateId] UNIQUEIDENTIFIER NOT NULL,
	[Type] NVARCHAR(128) NOT NULL,
	[Name] NVARCHAR(64) NOT NULL
);

CREATE TABLE [Categories] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[ParentId] UNIQUEIDENTIFIER NULL,
	[Name] NVARCHAR(64) NOT NULL,
	[Description] NVARCHAR(255) NULL,
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL,
	[CreatedById] UNIQUEIDENTIFIER NOT NULL,
	[UpdatedById] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_CategoryId PRIMARY KEY ([Id]),
	CONSTRAINT FK_CategoryCreatedBy FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]),
	CONSTRAINT FK_CategoryUpdatedBy FOREIGN KEY ([UpdatedById]) REFERENCES [Users] ([Id])
);

CREATE TABLE [Permalinks] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Type] NVARCHAR(16) NOT NULL,
	[Name] NVARCHAR(128) NOT NULL,
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL,
	[CreatedById] UNIQUEIDENTIFIER NOT NULL,
	[UpdatedById] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_PermalinkId PRIMARY KEY ([Id]),
	CONSTRAINT FK_PermalinkCreatedBy FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]),
	CONSTRAINT FK_PermalinkUpdatedBy FOREIGN KEY ([UpdatedById]) REFERENCES [Users] ([Id])
);
CREATE UNIQUE INDEX INDEX_PermalinkName ON [Permalinks] ([Name]);

CREATE TABLE [Pages] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[IsDraft] BIT NOT NULL default(1),
	[TemplateId] UNIQUEIDENTIFIER NOT NULL,
	[GroupId] UNIQUEIDENTIFIER NULL,
	[PermalinkId] UNIQUEIDENTIFIER NOT NULL,
	[ParentId] UNIQUEIDENTIFIER NULL,
	[Seqno] INT NOT NULL DEFAULT(1),
	[Title] NVARCHAR(128) NOT NULL,
	[NavigationTitle] NVARCHAR(128) NULL,
	[IsHidden] BIT NOT NULL DEFAULT(0),
	[Keywords] NVARCHAR(128) NULL,
	[Description] NVARCHAR(255) NULL,
	[Attachments] NTEXT NULL,
	[ViewTemplate] NVARCHAR(128) NULL,
	[ViewRedirect] NVARCHAR(128) NULL,
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL,
	[Published] DATETIME NULL,
	[LastPublished] DATETIME NULL,
	[CreatedById] UNIQUEIDENTIFIER NOT NULL,
	[UpdatedById] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_PageId PRIMARY KEY ([Id], [IsDraft]),
	CONSTRAINT FK_PageTemplate FOREIGN KEY ([TemplateId]) REFERENCES [PageTemplates] ([Id]),
	CONSTRAINT FK_PageCreatedBy FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]),
	CONSTRAINT FK_PageUpdatedBy FOREIGN KEY ([UpdatedById]) REFERENCES [Users] ([Id])
);

CREATE TABLE [Regions] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[IsDraft] BIT NOT NULL default(1),
	[PageId] UNIQUEIDENTIFIER NOT NULL,
	[PageIsDraft] BIT NOT NULL default(1),
	[Name] NVARCHAR(64) NOT NULL,
	[Body] NTEXT NULL,
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL,
	[CreatedById] UNIQUEIDENTIFIER NOT NULL,
	[UpdatedById] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_RegionId PRIMARY KEY ([Id], [IsDraft]),
	CONSTRAINT FK_RegionPageId FOREIGN KEY ([PageId], [PageIsDraft]) REFERENCES [Pages] ([Id], [IsDraft]),
	CONSTRAINT FK_RegionCreatedBy FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]),
	CONSTRAINT FK_RegionUpdatedBy FOREIGN KEY ([UpdatedById]) REFERENCES [Users] ([Id])
);

CREATE TABLE [Properties] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[IsDraft] BIT NOT NULL default(1),
	[ParentId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(64) NOT NULL,
	[Value] NTEXT NULL,
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL,
	[CreatedById] UNIQUEIDENTIFIER NOT NULL,
	[UpdatedById] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_PropertyId PRIMARY KEY ([Id], [IsDraft]),
	CONSTRAINT FK_PropertyCreatedBy FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]),
	CONSTRAINT FK_PropertyUpdatedBy FOREIGN KEY ([UpdatedById]) REFERENCES [Users] ([Id])
);

CREATE TABLE [Posts] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[IsDraft] BIT NOT NULL default(1),
	[TemplateId] UNIQUEIDENTIFIER NOT NULL,
	[PermalinkId] UNIQUEIDENTIFIER NOT NULL,
	[Title] NVARCHAR(128) NOT NULL,
	[Excerpt] NVARCHAR(255) NULL,
	[Body] NTEXT NULL,
	[Attachments] NTEXT NULL,
	[ViewTemplate] NVARCHAR(128) NULL,
	[ArchiveTemplate] NVARCHAR(128) NULL,
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL,
	[Published] DATETIME NULL,
	[LastPublished] DATETIME NULL,
	[CreatedById] UNIQUEIDENTIFIER NOT NULL,
	[UpdatedById] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_PostId PRIMARY KEY ([Id], [IsDraft]),
	CONSTRAINT FK_PostTemplateId FOREIGN KEY ([TemplateId]) REFERENCES [PostTemplates] ([Id]),
	CONSTRAINT FK_PostCreatedById FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]),
	CONSTRAINT FK_PostUpdatedById FOREIGN KEY ([UpdatedById]) REFERENCES [Users] ([Id])
);

-- EXEC sp_rename 'content', 'content_old';
CREATE TABLE [Content] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(64) NOT NULL,
	[Filename] NVARCHAR(128) NOT NULL,
	[Type] NVARCHAR(64) NOT NULL,
	[Size] INT NOT NULL default(0),
	[IsImage] BIT NOT NULL default(0),
	[Width] INT NULL,
	[Height] INT NULL,
	[AltText] NVARCHAR(128) NULL,
	[Description] NVARCHAR(255) NULL,
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL,
	[CreatedById] UNIQUEIDENTIFIER NOT NULL,
	[UpdatedById] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_ContentId PRIMARY KEY ([Id]),
	CONSTRAINT FK_ContentCreatedById FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]),
	CONSTRAINT FK_ContentUpdatedById FOREIGN KEY ([UpdatedById]) REFERENCES [Users] ([Id])
);

CREATE TABLE [Attachments] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[ParentId] UNIQUEIDENTIFIER NOT NULL,
	[ContentId] UNIQUEIDENTIFIER NOT NULL,
	[Seqno] INT NOT NULL default(1),
	CONSTRAINT PK_AttachmentId PRIMARY KEY ([Id]),
	CONSTRAINT FK_AttachmentContentId FOREIGN KEY ([ContentId]) REFERENCES [Content] ([Id])
);

CREATE TABLE [Uploads] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[ParentId] UNIQUEIDENTIFIER NULL,
	[Filename] NVARCHAR(128) NOT NULL,
	[Type] NVARCHAR(64) NOT NULL,
	[Created] DATETIME NOT NULL,
	[CreatedById] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_UploadId PRIMARY KEY (upload_id),
	CONSTRAINT FK_UploadCreatedById FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id])
);
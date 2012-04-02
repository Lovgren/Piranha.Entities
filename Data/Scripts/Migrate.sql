ALTER TABLE [Users] NOCHECK CONSTRAINT FK_UserGroup;
ALTER TABLE [Groups] NOCHECK CONSTRAINT FK_GroupCreatedBy;
ALTER TABLE [Groups] NOCHECK CONSTRAINT FK_GroupUpdatedBy;

INSERT INTO [Users] ([Id], [GroupId], [Login], [Password], [Firstname], [Surname], [Email], [Culture], [Created], [Updated], [CreatedById], [UpdatedById])
	SELECT sysuser_id, sysuser_group_id, sysuser_login, sysuser_password, sysuser_firstname, sysuser_surname, sysuser_email, sysuser_culture, 
		sysuser_created, sysuser_updated, sysuser_created_by, sysuser_updated_by
	FROM sysuser;

INSERT INTO [Groups] ([Id], [ParentId], [Name], [Description], [Created], [Updated], [CreatedById], [UpdatedById])
	SELECT sysgroup_id, sysgroup_parent_id, sysgroup_name, sysgroup_description, sysgroup_created, sysgroup_updated, sysgroup_created_by, sysgroup_updated_by
	FROM sysgroup;
UPDATE [Groups] SET [CreatedById] = [UpdatedById] WHERE [CreatedById] IS NULL;

ALTER TABLE [Groups] CHECK CONSTRAINT FK_GroupUpdatedBy;
ALTER TABLE [Groups] CHECK CONSTRAINT FK_GroupCreatedBy;
ALTER TABLE [Users] CHECK CONSTRAINT FK_UserGroup;

INSERT INTO [Permissions] ([Id], [GroupId], [Name], [Description], [IsLocked], [Created], [Updated], [CreatedById], [UpdatedById])
	SELECT sysaccess_id, sysaccess_group_id, sysaccess_function, sysaccess_description, sysaccess_locked, sysaccess_created, sysaccess_updated, sysaccess_created_by, sysaccess_updated_by
	FROM sysaccess;

INSERT INTO [Params] ([Id], [Name], [Value], [Description], [IsLocked], [Created], [Updated], [CreatedById], [UpdatedById])
	SELECT sysparam_id, sysparam_name, sysparam_value, sysparam_description, sysparam_locked, sysparam_created, sysparam_updated, sysparam_created_by, sysparam_updated_by
	FROM sysparam;

INSERT INTO [PageTemplates] ([Id], [Name], [Description], [Preview], [Regions], [Properties], [ViewTemplate], [ShowViewTemplate], [ViewRedirect], [ShowViewRedirect],
		[Created], [Updated], [CreatedById], [UpdatedById])
	SELECT pagetemplate_id, pagetemplate_name, pagetemplate_description, pagetemplate_preview, pagetemplate_page_regions, pagetemplate_properties, pagetemplate_controller,
		pagetemplate_controller_show, pagetemplate_redirect, pagetemplate_redirect_show, pagetemplate_created, pagetemplate_updated, pagetemplate_created_by, pagetemplate_updated_by
	FROM pagetemplate;

INSERT INTO [PostTemplates] ([Id], [Name], [Description], [Preview], [Properties], [ViewTemplate], [ShowViewTemplate], [ArchiveTemplate], [ShowArchiveTemplate],
		[Created], [Updated], [CreatedById], [UpdatedById])
	SELECT posttemplate_id, posttemplate_name, posttemplate_description, posttemplate_preview, posttemplate_properties, posttemplate_controller, posttemplate_controller_show,
		posttemplate_archive_controller, posttemplate_archive_controller_show, posttemplate_created, posttemplate_updated, posttemplate_created_by, posttemplate_updated_by
	FROM posttemplate;

INSERT INTO [Categories] ([Id], [ParentId], [Name], [Description], [Created], [Updated], [CreatedById], [UpdatedById])
	SELECT category_id, category_parent_id, category_name, category_description, category_created, category_updated, category_created_by, category_updated_by
	FROM category;

INSERT INTO [Permalinks] ([Id], [Type], [Name], [Created], [Updated], [CreatedById], [UpdatedById])
	SELECT permalink_id, permalink_type, permalink_name, permalink_created, permalink_updated, permalink_created_by, permalink_updated_by
	FROM permalink;

INSERT INTO [Pages] ([Id], [IsDraft], [TemplateId], [GroupId], [PermalinkId], [ParentId], [Seqno], [Title], [NavigationTitle], [IsHidden], [Keywords], [Description],
		[Attachments], [ViewTemplate], [ViewRedirect], [Created], [Updated], [Published], [LastPublished], [CreatedById], [UpdatedById])
	SELECT page_id, page_draft, page_template_id, page_group_id, (SELECT permalink_id FROM permalink WHERE permalink_parent_id = page_id), page_parent_id, 
		page_seqno, page_title, page_navigation_title, page_is_hidden, page_keywords, page_description, page_attachments, page_controller, page_redirect, page_created, 
		page_updated, page_published, page_last_published, page_created_by, page_updated_by
	FROM page;

INSERT INTO [Regions] ([Id], [IsDraft], [PageId], [PageIsDraft], [Name], [Body], [Created], [Updated], [CreatedById], [UpdatedById])
	SELECT region_id, region_draft, region_page_id, region_page_draft, region_name, region_body, region_created, region_updated, region_created_by, region_updated_by
	FROM region;

INSERT INTO [Properties] ([Id], [IsDraft], [ParentId], [Name], [Value], [Created], [Updated], [CreatedById], [UpdatedById])
	SELECT property_id, property_draft, property_parent_id, property_name, property_value, property_created, property_updated, 
		property_created_by, property_updated_by
	FROM property;

INSERT INTO [Posts] ([Id], [IsDraft], [TemplateId], [PermalinkId], [Title], [Excerpt], [Body], [Attachments], [ViewTemplate], [ArchiveTemplate], 
		[Created], [Updated], [Published], [LastPublished], [CreatedById], [UpdatedById])
	SELECT post_id, post_draft, post_template_id, (SELECT permalink_id FROM permalink WHERE permalink_parent_id = post_id), post_title, post_excerpt, post_body, 
		post_attachments, post_controller, post_archive_controller, post_created, post_updated, post_published, post_last_published, post_created_by, post_updated_by
	FROM post;

-- TODO: Add migration scripts for Content & Upload
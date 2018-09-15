
--laguage
INSERT [dbo].[LANGUAGES] ([NAME]) VALUES (N'Vietnamese')
INSERT [dbo].[LANGUAGES] ([NAME]) VALUES (N'English')
INSERT [dbo].[LANGUAGES] ([NAME]) VALUES (N'China')
INSERT [dbo].[LANGUAGES] ([NAME]) VALUES (N'France')
INSERT [dbo].[LANGUAGES] ([NAME]) VALUES (N'German')

-- publisher
INSERT [dbo].[PUBLISHER] ([NAME], [EMAIL],Phone,[ADDRESS])
 VALUES (N'Kim Đồng', N'kd@gmail.com','0909545874', N'167 Le Trong Tan, Son Ky, Tan Phu')
INSERT [dbo].[PUBLISHER] ([NAME], [EMAIL],Phone,[ADDRESS])
 VALUES (N'Alpha Books', N'alpha@yahoo.com','0903333444', N'229 Tan Ky Tan Quy, Son Ky, Tan Phu')
INSERT [dbo].[PUBLISHER] ([NAME], [EMAIL],Phone,[ADDRESS])
 VALUES (N'Tuổi Trẻ', N'tuoitre@gmail.com','0904444555', N'78 Tran Hung Dao, Da Khao, Quan 1')
 INSERT [dbo].[PUBLISHER] ([NAME], [EMAIL],Phone,[ADDRESS])
 VALUES (N'Phụ Nữ', N'tuoitre@gmail.com','0904444555', N'123 Nguyễn Đình Chiểu, Quận 3')
 INSERT [dbo].[PUBLISHER] ([NAME], [EMAIL],Phone,[ADDRESS])
 VALUES (N'Thiếu Nhi', N'tuoitre@gmail.com','0904444555', N'71 Trần Bá Giao, Quận Gò Vấp')


-- title
INSERT
 [dbo].[TITLES] (LanguageID, PublisherID,Code,[NAME],
  [TABLEOFCONTENT], [DESCRIPTION], Edition, [ISBN], [IMAGE],Price,PublishingDate)
 VALUES
  (1,3,N'TXCT', N'Thanh Xuân Của Tôi',  N'Chưa Cập Nhật', N'Chưa có mô tả','1', NULL, NULL, 10000, getdate())
 INSERT 
 [dbo].[TITLES] (LanguageID, PublisherID,Code,[NAME],
  [TABLEOFCONTENT], [DESCRIPTION], Edition, [ISBN], [IMAGE],Price,PublishingDate)
 VALUES (2, 3,N'TLA', N'Tôi là ai ?',  N'Chưa Cập Nhật', N'Chưa có mô tả','1',NULL, NULL, 10000, getdate())
 INSERT
  [dbo].[TITLES] 
 VALUES (1, 3,N'&TQHQ', N'7 Thói Quen Hiệu Quả', N'Chưa Cập Nhật', N'Chưa có mô tả','1',NULL, NULL, 10000, getdate())
 INSERT
  [dbo].[TITLES] 
 VALUES (2, 3,N'TTCX', N'Trí Tuệ Cảm Xúc',   N'Chưa Cập Nhật', N'Chưa có mô tả','1',NULL, NULL, 10000, getdate())
 INSERT 
 [dbo].[TITLES]  
 VALUES (3, 1,N'CTCQTB', N'Chiến Thắng Con Quỷ Trong Bạn',N'Chưa Cập Nhật', N'Chưa có mô tả','1',NULL, NULL, 10000, getdate())
 INSERT
  [dbo].[TITLES]  
 VALUES (4, 1,N'TTI', N'Tiềm Thức Isarel', N'Chưa Cập Nhật', N'Chưa có mô tả','1',NULL, NULL, 10000, getdate())
 INSERT
  [dbo].[TITLES]  
 VALUES (1, 1,N'KNCOCN', N'Kinh Nghiêm Của Ông Chủ Nhỏ',  N'Chưa Cập Nhật', N'Chưa có mô tả','1',NULL, NULL, 10000, getdate())
 INSERT
  [dbo].[TITLES]  
 VALUES (2, 2,N'GTBKA', N'Giao Tiếp Bất Kì Ai', N'Chưa Cập Nhật', N'Chưa có mô tả','1',NULL, NULL, 10000, getdate())
 INSERT
  [dbo].[TITLES]
 VALUES (3, 2,N'DVBKA', N'Đọc Vị Bất Kì Ai',N'Chưa Cập Nhật', N'Chưa có mô tả','1',NULL, NULL, 10000, getdate())
 INSERT  [dbo].[TITLES]  
 VALUES (1, 2,N'BG', N'Bố Già',N'Chưa Cập Nhật', N'Chưa có mô tả','1',NULL, NULL, 10000, getdate())
 
 
 --category
 INSERT [dbo].[CATEGORIES] ([NAME], [DESCRIPTION]) VALUES (N'Trinh Thám', NULL)
INSERT [dbo].[CATEGORIES] ([NAME], [DESCRIPTION]) VALUES (N'Tiểu Thuyết', NULL)
INSERT [dbo].[CATEGORIES] ([NAME], [DESCRIPTION]) VALUES (N'Truyện Tranh', NULL)
INSERT [dbo].[CATEGORIES] ( [NAME], [DESCRIPTION]) VALUES (N'Ngụ Ngôn', NULL)
INSERT [dbo].[CATEGORIES] ( [NAME], [DESCRIPTION]) VALUES (N'Phiêu Lưu', NULL)
INSERT [dbo].[CATEGORIES] ( [NAME], [DESCRIPTION]) VALUES (N'Dân Gian', NULL)


--category-title
insert into CategoryTitles values (4,1)
insert into CategoryTitles values (4,2)
insert into CategoryTitles values (4,3)
insert into CategoryTitles values (4,4)
insert into CategoryTitles values (4,5)

insert into CategoryTitles values (5,2)
insert into CategoryTitles values (5,3)
insert into CategoryTitles values (5,4)


insert into CategoryTitles values (6,1)
insert into CategoryTitles values (6,2)
insert into CategoryTitles values (6,5)

insert into CategoryTitles values (6,4)

insert into CategoryTitles values (7,5)
insert into CategoryTitles values (7,1)
insert into CategoryTitles values (7,2)
insert into CategoryTitles values (7,3)


insert into CategoryTitles values (8,4)
insert into CategoryTitles values (9,3)


insert into CategoryTitles values (10,5)

insert into CategoryTitles values (11,1)

insert into CategoryTitles values (12,2)

insert into CategoryTitles values (13,4)

insert into CategoryTitles values (11,5)
insert into CategoryTitles values (10,4)
insert into CategoryTitles values (13,1)


 --librarian
 INSERT INTO [Librarian] ([Email], [FirstName], [Gender], [LastName],[Status],Phone,[Image])
      VALUES ( N'nguyenvanteo@gmail.com', N'To', 1, N'Nguyễn Trần',1,'0909999888',NULL)
INSERT INTO [Librarian] ( [Email], [FirstName], [Gender], [LastName],[Status],Phone,[Image])
      VALUES( N'nguyenvanty@gmail.com', N'Tý', 1, N'Nguyễn Văn',0,'0909999888',NULL)
INSERT INTO [Librarian] ( [Email], [FirstName], [Gender], [LastName],[Status],Phone,[Image])
      VALUES( N'nguyenvanthuong@gmail.com', N'Thương', 0, N'Phan Thị',1,'0909999888',NULL)
INSERT INTO [Librarian] ( [Email], [FirstName], [Gender], [LastName],[Status],Phone,[Image])
      VALUES( N'nguyenvanthnh@gmail.com', N'Thanh', 0, N'Nguyễn Thị',1,'0909999888',NULL)
INSERT INTO [Librarian] ( [Email], [FirstName], [Gender], [LastName],[Status],Phone,[Image])
      VALUES( N'nguyenvanha@gmail.com', N'Hà', 1, N'Nguyễn Thanh',1,'0909999888',NULL);
      
--- author
insert into Author values(N'Steven',N'Covey')
insert into Author values(N'Lão',N'Mạc')
insert into Author values(N'Goleman',N'Daniel')
insert into Author values(N'J. Lieberman',N'David')
insert into Author values(N'Richard',N'Precht')
insert into Author values(N'Hill',N'Napoleon')
insert into Author values(N'Alon',N'Gratch')
insert into Author values(N'Bennie',N'Boughn')
insert into Author values(N'Jon',N'Condrill')
insert into Author values(N'Puzo',N'Mrio')
insert into Author values(N'',N'Unknow')


--author--title

insert into AuthorTitle
values(1,4)
insert into AuthorTitle
values(2,4)

insert into AuthorTitle
values(3,5)
insert into AuthorTitle
values(4,6)
insert into AuthorTitle
values(5,7)
insert into AuthorTitle
values(6,8)
insert into AuthorTitle
values(7,9)
insert into AuthorTitle
values(8,10)
insert into AuthorTitle
values(9,11)
insert into AuthorTitle
values(10,12)
insert into AuthorTitle
values(11,13)
insert into AuthorTitle
values(1,13)
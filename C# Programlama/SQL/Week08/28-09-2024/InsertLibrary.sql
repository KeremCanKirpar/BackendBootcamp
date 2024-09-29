--********************************************************--
-- TABLOLARA VERİ GİRME ADIMI
--********************************************************--

-- LibraryItems tablosuna 80 kitap ekle
INSERT INTO LibraryItems
    (Title, PublishedDate, ItemType)
VALUES
    -- 80 kitap
    ('Savaş ve Barış', '1869-01-01', 'Book'),
    ('Bülbülü Öldürmek', '1960-07-11', 'Book'),
    ('Küçük Prens', '1943-04-06', 'Book'),
    ('Suç ve Ceza', '1866-01-01', 'Book'),
    ('Kırmızı ve Siyah', '1830-01-01', 'Book'),
    ('Gurur ve Önyargı', '1813-01-01', 'Book'),
    ('1984', '1949-06-08', 'Book'),
    ('Yüz Yıllık Yalnızlık', '1967-05-30', 'Book'),
    ('Hayvan Çiftliği', '1945-08-17', 'Book'),
    ('Açlık Oyunları', '2008-09-14', 'Book'),
    ('Beyaz Diş', '1906-05-01', 'Book'),
    ('Denizler Altında Yirmi Bin Fersah', '1870-01-01', 'Book'),
    ('Moby Dick', '1851-10-18', 'Book'),
    ('Bütün Zamanların En İyi Romanları', '2020-01-01', 'Book'),
    ('Fahrenheit 451', '1953-10-19', 'Book'),
    ('Zorba', '1946-01-01', 'Book'),
    ('Yalnızız', '1969-01-01', 'Book'),
    ('Çocuk Kalbi', '1886-01-01', 'Book'),
    ('İki Şehrin Hikayesi', '1859-01-01', 'Book'),
    ('Gizli Bahçe', '1911-01-01', 'Book'),
    ('Simyacı', '1988-01-01', 'Book'),
    ('Küçük Kadınlar', '1868-01-01', 'Book'),
    ('Uçurtma Avcısı', '2003-05-29', 'Book'),
    ('Zaman Makinesi', '1895-01-01', 'Book'),
    ('Bütün İnsanların Tarihi', '2019-01-01', 'Book'),
    ('Yolda', '1957-01-01', 'Book'),
    ('Akıllı Kız', '2007-09-01', 'Book'),
    ('Yalnızlık', '2010-02-01', 'Book'),
    ('Kayıp Zamanın İzinde', '1913-01-01', 'Book'),
    ('Su Uyanınca', '1998-01-01', 'Book'),
    ('Benim Adım Kırmızı', '1998-01-01', 'Book'),
    ('Açlık', '1899-01-01', 'Book'),
    ('Beni Kandırma', '2015-01-01', 'Book'),
    ('Küçük Hayaller', '2021-01-01', 'Book'),
    ('Her Şeyin Sonu', '2023-01-01', 'Book'),
    ('Son Perde', '2022-05-01', 'Book'),
    ('İnsana Dair', '2001-01-01', 'Book'),
    ('Gün Doğmadan', '2020-01-01', 'Book'),
    ('Aylak Adam', '1961-01-01', 'Book'),
    ('Seyahatname', '1660-01-01', 'Book'),
    ('Yalnızlık Çığlığı', '2019-01-01', 'Book'),
    ('Aşk ve Zaman', '1995-01-01', 'Book'),
    ('Da Vinci Şifresi', '2003-01-01', 'Book'),
    ('Kayıp Şehir Z', '2009-01-01', 'Book'),
    ('Zamanın Kısa Tarihi', '1988-01-01', 'Book'),
    ('Asya’nın Gözyaşları', '2012-01-01', 'Book'),
    ('İşgal', '1998-01-01', 'Book'),
    ('Hayatın Anlamı', '2020-01-01', 'Book'),
    ('Şeker Portakalı', '1968-01-01', 'Book'),
    ('Küçük Mucizeler', '2005-01-01', 'Book'),
    ('Kırmızı Şemsiye', '2018-01-01', 'Book'),
    ('Otomatik Portakal', '1962-01-01', 'Book'),
    ('Karanlıkta Dans', '2015-01-01', 'Book'),
    ('Çocuklar İçin Felsefe', '2002-01-01', 'Book'),
    ('Mavi Sakal', '2017-01-01', 'Book'),
    ('Hayat Bazen', '2019-01-01', 'Book'),
    ('Güzel ve Çirkin', '2022-01-01', 'Book'),
    ('Alacakaranlık', '2005-01-01', 'Book'),
    ('Göçebe Kalp', '2018-01-01', 'Book'),
    ('Kütüphane Gecesi', '2011-01-01', 'Book'),
    ('Kütüphaneler ve Düşler', '2023-01-01', 'Book')
GO


-- Magazines tablosuna 15 dergi ekle
INSERT INTO LibraryItems
    (Title, PublishedDate, ItemType)
VALUES
    ('National Geographic', '2024-01-01', 'Magazine'),
    ('National Geographic Türkiye', '2024-02-01', 'Magazine'),
    ('Time', '2024-03-01', 'Magazine'),
    ('Vogue', '2024-04-01', 'Magazine'),
    ('Elle', '2024-05-01', 'Magazine'),
    ('GQ', '2024-06-01', 'Magazine'),
    ('Forbes', '2024-07-01', 'Magazine'),
    ('Cosmopolitan', '2024-08-01', 'Magazine'),
    ('Yüzde Yüz Futbol', '2024-09-01', 'Magazine'),
    ('Eviniz için Tasarım', '2024-10-01', 'Magazine'),
    ('Tatlılar', '2024-11-01', 'Magazine'),
    ('Sağlıklı Yaşam', '2024-12-01', 'Magazine'),
    ('İş Dünyası', '2024-01-01', 'Magazine'),
    ('Çocuk Gelişimi', '2024-02-01', 'Magazine'),
    ('Seyahat Rehberi', '2024-03-01', 'Magazine')
GO



-- DVDs tablosuna 5 DVD ekle
INSERT INTO LibraryItems
    (Title, PublishedDate, ItemType)
VALUES
    ('Yıldız Savaşları', '1977-05-25', 'DVD'),
    ('Dövüş Kulübü', '1999-10-15', 'DVD'),
    ('Esaretin Bedeli', '1994-09-23', 'DVD'),
    ('Kara Şövalye', '2008-07-18', 'DVD'),
    ('Gladyatör', '2000-05-05', 'DVD')
GO


-- Books tablosuna 61 kitap ekle
INSERT INTO Books
    (ItemId, Author)
VALUES
    (1, 'Lev Tolstoy'),
    (2, 'Harper Lee'),
    (3, 'Antoine de Saint-Exupéry'),
    (4, 'Fyodor Dostoyevsky'),
    (5, 'Stendhal'),
    (6, 'Jane Austen'),
    (7, 'George Orwell'),
    (8, 'Gabriel García Márquez'),
    (9, 'George Orwell'),
    (10, 'Suzanne Collins'),
    (11, 'Jack London'),
    (12, 'Jules Verne'),
    (13, 'Various Authors'),
    (14, 'Ray Bradbury'),
    (15, 'Nikos Kazantzakis'),
    (16, 'Khaled Hosseini'),
    (17, 'Marcel Proust'),
    (18, 'Ken Follett'),
    (19, 'Charles Dickens'),
    (20, 'Frances Hodgson Burnett'),
    (21, 'Paulo Coelho'),
    (22, 'Stephen King'),
    (23, 'Aldous Huxley'),
    (24, 'Orhan Pamuk'),
    (25, 'Mark Twain'),
    (26, 'F. Scott Fitzgerald'),
    (27, 'Tess Gerritsen'),
    (28, 'Agatha Christie'),
    (29, 'Stephen Hawking'),
    (30, 'Barbara Kingsolver'),
    (31, 'Albert Camus'),
    (32, 'J.K. Rowling'),
    (33, 'Kurt Vonnegut'),
    (34, 'Murakami Haruki'),
    (35, 'Victor Hugo'),
    (36, 'Isaac Asimov'),
    (37, 'Emily Brontë'),
    (38, 'John Steinbeck'),
    (39, 'J.D. Salinger'),
    (40, 'James Joyce'),
    (41, 'Margaret Atwood'),
    (42, 'Leo Tolstoy'),
    (43, 'C.S. Lewis'),
    (44, 'Richard Adams'),
    (45, 'Philip Pullman'),
    (46, 'H.G. Wells'),
    (47, 'Jules Claretie'),
    (48, 'Oscar Wilde'),
    (49, 'Rainer Maria Rilke'),
    (50, 'Louisa May Alcott'),
    (51, 'Friedrich Nietzsche'),
    (52, 'Henry Miller'),
    (53, 'Walt Whitman'),
    (54, 'Virginia Woolf'),
    (55, 'Philip K. Dick'),
    (56, 'Raymond Chandler'),
    (57, 'Ernest Hemingway'),
    (58, 'Kurt Vonnegut'),
    (59, 'Mikhail Bulgakov'),
    (60, 'Truman Capote'),
    (61, 'Salman Rushdie')
GO

-- Magazines tablosuna 15 dergi ekle
INSERT INTO Magazines
    (ItemId, IssueNumber)
VALUES
    (62, '2024-01'),
    (63, '2024-02'),
    (64, '2024-03'),
    (65, '2024-04'),
    (66, '2024-05'),
    (67, '2024-06'),
    (68, '2024-07'),
    (69, '2024-08'),
    (70, '2024-09'),
    (71, '2024-10'),
    (72, '2024-11'),
    (73, '2024-12'),
    (74, '2025-01'),
    (75, '2025-02'),
    (76, '2025-03')
GO

-- DVDs tablosuna 5 DVD ekle
INSERT INTO DVDs
    (ItemId, Director)
VALUES
    (77, 'George Lucas'),
    (78, 'DavItemId Fincher'),
    (79, 'Frank Darabont'),
    (80, 'Christopher Nolan'),
    (81, 'RItemIdley Scott')
GO


-- Members tablosuna 20 üye ekle
INSERT INTO Members
    (FullName, MembershipStatus)
VALUES
    ('Ahmet Yılmaz', 'Active'),
    ('Ayşe Demir', 'Active'),
    ('Mehmet Öz', 'Active'),
    ('Elif Çelik', 'Active'),
    ('Ali Koç', 'Active'),
    ('Fatma Yıldız', 'Inactive'),
    ('Emre Akman', 'Active'),
    ('Seda Aydın', 'Active'),
    ('Burak Tekin', 'Inactive'),
    ('Derya Korkmaz', 'Active'),
    ('Oğuzhan Ceylan', 'Active'),
    ('Zeynep Usta', 'Inactive'),
    ('Merve Güler', 'Active'),
    ('Hüseyin Çetin', 'Active'),
    ('Cemre Kılıç', 'Active'),
    ('Gizem Sönmez', 'Active'),
    ('Selin Yıldırım', 'Inactive'),
    ('Kaan Kara', 'Active'),
    ('Büşra Sönmez', 'Active'),
    ('Deniz Kızıl', 'Active')
GO



-- ContactInfos tablosuna 20 iletişim bilgisi ekle
INSERT INTO ContactInfos
    (MemberItemId, ContactInfo)
VALUES
    (1, 'ahmet@example.com'),
    (2, 'ayse@example.com'),
    (3, 'mehmet@example.com'),
    (4, 'elif@example.com'),
    (5, 'ali@example.com'),
    (6, 'fatma@example.com'),
    (7, 'emre@example.com'),
    (8, 'seda@example.com'),
    (9, 'burak@example.com'),
    (10, 'derya@example.com'),
    (11, 'oguzhan@example.com'),
    (12, 'zeynep@example.com'),
    (13, 'merve@example.com'),
    (14, 'huseyin@example.com'),
    (15, 'cemre@example.com'),
    (16, 'gizem@example.com'),
    (17, 'selin@example.com'),
    (18, 'kaan@example.com'),
    (19, 'busra@example.com'),
    (20, 'deniz@example.com')
GO



-- Borrowings tablosuna örnek veriler ekle
INSERT INTO Borrowings
    (MemberItemId, ItemItemId, BorrowedDate, ReturnDate)
VALUES
    (1, 1, '2024-01-10', '2024-01-20'),
    (1, 2, '2024-01-15', NULL),
    (2, 3, '2024-01-12', '2024-01-19'),
    (3, 4, '2024-01-14', '2024-01-28'),
    (4, 5, '2024-01-18', NULL),
    (5, 6, '2024-01-20', '2024-02-05')
GO



-- Ratings tablosuna örnek 9 puan ekle (5 üyeye 1’er, 4 üyeye 2’şer)
INSERT INTO Ratings
    (MemberItemId, ItemItemId, RatingValue)
VALUES
    (1, 1, 5),
    (1, 2, 4),
    (2, 3, 5),
    (2, 4, 3),
    (3, 5, 4),
    (3, 6, 5),
    (4, 7, 3),
    (4, 8, 4),
    (5, 9, 5),
    (5, 10, 4),
    (6, 11, 5),
    (6, 12, 4),
    (7, 13, 3),
    (7, 14, 5),
    (8, 15, 4)
GO

select * from Account;
alter table Account add [name] nvarchar(200)
alter table Product alter column pimage	nvarchar(200) null
update Account set [name] = N'Nguyễn Duy Hùng' where aid = 1;

select * from ProductCategory
insert into ProductCategory(cname) values(N'Áo')
insert into ProductCategory(cname) values(N'Quần')
insert into ProductCategory(cname) values(N'Giày')
insert into ProductCategory(cname) values(N'Cặp, Túi')

select * from Product
insert into Product(pname, price, cid) values(N'Áo thun', 150, 1)
insert into Product(pname, price, cid) values(N'Áo hoodie', 300, 1)
insert into Product(pname, price, cid) values(N'Áo ba lỗ', 100, 1)
insert into Product(pname, price, cid) values(N'Quần âu', 490, 2)
insert into Product(pname, price, cid) values(N'Quần đùi', 80, 2)
insert into Product(pname, price, cid) values(N'Quần baggy', 350, 2)
insert into Product(pname, price, cid) values(N'Giày Adidas', 550, 3)
insert into Product(pname, price, cid) values(N'Giày Nike', 620, 3)
insert into Product(pname, price, cid) values(N'Giày Vans', 375, 3)
insert into Product(pname, price, cid) values(N'Túi đeo chéo', 180, 4)
insert into Product(pname, price, cid) values(N'Balo laptop', 700, 4)
insert into Product(pname, price, cid) values(N'Balo du lịch', 400, 4)
--------------------
update Product set pimage = N'Đât là ảnh' where pid = 37;
update Product set pimage = N'Đât là ảnh' where pid = 38;
update Product set pimage = N'Đât là ảnh' where pid = 39;
update Product set pimage = N'Đât là ảnh' where pid = 40;
update Product set pimage = N'Đât là ảnh' where pid = 41;
update Product set pimage = N'Đât là ảnh' where pid = 42;
update Product set pimage = N'Đât là ảnh' where pid = 43;
update Product set pimage = N'Đât là ảnh' where pid = 44;
update Product set pimage = N'Đât là ảnh' where pid = 45;
update Product set pimage = N'Đât là ảnh' where pid = 46;
update Product set pimage = N'Đât là ảnh' where pid = 47;
update Product set pimage = N'Đât là ảnh' where pid = 48;

select p.pname, p.price, c.cname from Product p inner join ProductCategory c on p.cid = c.cid
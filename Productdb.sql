CREATE TABLE Product3(
[pid] [int] IDENTITY(1,1) NOT NULL,
[pname] [varchar](50) NULL,
[catid] [int] NULL,
[subcatid] [int] NULL,
[price] [numeric](8, 2) NULL,
[pqty] [int] NULL
) ON [PRIMARY]
GO




CREATE TABLE Category3(
[catid] [int] IDENTITY(1,1) NOT NULL,
[catname] [varchar](50) NULL
) ON [PRIMARY]
GO



CREATE TABLE SubCategory3(
[subcatid] [int] IDENTITY(1,1) NOT NULL,
[catid] [int] NULL,
[subcatname] [varchar](50) NULL
) ON [PRIMARY]
GO



create proc sp_psc
(
@pid int=0,
@pname varchar(50)=null,
@catid int=0,
@subcatid int=0,
@price numeric(8,2)=0.0,
@pqty int=0,
@catname varchar(50)=null,
@subcatname varchar(50)=null,
@action varchar(50)
)
as
begin
if(@action='Insert')
 begin
    if(@pid=0)
   Insert into Product3 values(@pname,@catid,@subcatid,@price,@pqty)
    else
  Update Product3 set pname=@pname,catid=@catid,subcatid=@subcatid,price=@price,pqty=@pqty where pid=@pid


 end

else if(@action='Delete')
Delete from Product3 where pid=@pid
else if(@action='SelectOne')
Select pid,pname,catname,subcatname,price,pqty,c.catid,s.subcatid from Product3 p,Category3 c,SubCategory3 s 
where p.catid=c.catid and p.subcatid=s.subcatid and pid=@pid

else if(@action='Fillcat')
Select * from Category3
else if(@action='Fillsubcat')
Select * from SubCategory3 where catid=@catid
else if(@action='Fillsubcatall')
Select * from SubCategory3

else if(@action='FillTable')
Select pid,pname,catname,subcatname,price,pqty from Product3 p,Category3 c,SubCategory3 s where p.catid=c.catid and p.subcatid=s.subcatid

end
GO


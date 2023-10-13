use DAPM 

create table GIAMGIA(
STT int identity(1,1),
Magiamgia nvarchar (50) not null unique, 
Luonggiamgia float,
Sogiamgia as Luonggiamgia * 100,
constraint PK_GIAMGIA primary key (STT, MaGiamGia)
)
alter table DONDATHANG add constraint FK_DONHANG_GIAMGIA foreign key (MaGiamGia) references GIAMGIA(Magiamgia)

create table TINNHAN(
Id_tnhan int identity(1,1),
MaKH int, 
mess_text text, 
timestamp timestamp
constraint PK_TINNHAN primary key (Id_tnhan)
)
alter table TINNHAN add constraint FK_TINNHAN_KHACHHANG foreign key (MaKH) references KHACHHANG(MaKH)

create table DANHGIA(
Id_danhgia int identity(1,1),
Masach int,
MaKH int, 
Diem int,
Textdanhgia text, 
timestamp timestamp
constraint PK_DANHGIA primary key (Masach, MaKH)
)
alter table DANHGIA add constraint FK_DANHGIA_SACH foreign key (Masach) references Sach(Masach)
alter table DANHGIA add constraint FK_DANHGIA_KHACHHANG foreign key (MaKH) references KHACHHANG(MaKH)

select YEAR(NgayDH) as Nam, MONTH(NgayDH) as Thang, sum(Trigia) as Tongdoanhso
into Thongke
from DONDATHANG
group by YEAR(NgayDH), MONTH(NgayDH)

create table ADMIN(
UserAdmin varchar(30) primary key,
PassAdmin varchar (30) not null,
HoTen nvarchar(50),
VaiTro varchar(30)
)
insert into admin values ('admin', '123', 'Nguyễn Ngọc Tuấn Anh', 'ADMIN')
Create database Apiwedfood
go

use Apiwedfood
go 

CREATE TABLE menu(
	menuid int IDENTITY (1,1) NOT NULL,
	menuname NVARCHAR(1000)  NOT NULL,
	menuavata  NVARCHAR(1000)  NOT NULL, 
	PRIMARY KEY (menuid)
)
INSERT INTO menu(menuname,menuavata)
VALUES(N'Bánh kem lớn',N'https://banhkemngonghinh.com/wp-content/uploads/2018/01/banh-kem-ngo-nghinh-de-thuong-ngon-dep-banh-kem-sinh-nhat-lon-3-tang-ngo-nghinh-de-thuong-voi-khuon-banh-tron-mau-do-va-dep-hon-voi-cac-canh-hoa-va-bong-hoa.jpg')
INSERT INTO menu(menuname,menuavata)
VALUES(N'Bánh kem nhỏ',N'https://afamilycdn.com/150157425591193600/2020/9/23/7-16008560685211826463980.jpg')
INSERT INTO menu(menuname,menuavata)
VALUES(N'Bánh kem trái cây',N'https://cuahangbanh.com/image/cache/catalog/abum-10/banh-kem-trai-cay-dep-nhat-550x550.jpg')

CREATE TABLE food ( 
	foodid  INT  IDENTITY (1,1) NOT NULL, 
	foodname NVARCHAR(1000)  NOT NULL, 
	menuid INT NOT NULL,
	foodprice INT NOT NULL,
	foodimghp  NVARCHAR(1000)  NOT NULL, 
	foodimg1  NVARCHAR(1000)  NOT NULL,
	foodimg2  NVARCHAR(1000) ,  
	foodimg3  NVARCHAR(1000)  ,
	foodimg4  NVARCHAR(1000)   ,
	foodDescriptions NTEXT  NOT NULL,
	foodInStock int,
	typefood int 
)
	GO
INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Bánh kem lớn 1 ',1,132999,
N'https://bizweb.dktcdn.net/thumb/1024x1024/100/423/207/products/f9302239-0893-4d9f-95c5-f5e533bd2018.jpg?v=1625458009847',
N'',N'https://cf.shopee.vn/file/a7785ae000ea41f065f21a9ac2eb3f87',
N'https://bizweb.dktcdn.net/thumb/large/100/333/744/files/mau-banh-kem-hinh-trai-tim-tang-ban-gai4.jpg?v=1543199234546',
N'https://tinphatbakery.com/wp-content/uploads/2019/04/Ba%CC%81nh-Kem-Tra%CC%81i-Tim-Ti%CC%80nh-Ye%CC%82u-52.jpg',
N'Đường kính bánh 18 – 20 cm, chiều cao bánh 8 – 10 cm. Bánh dùng cho 8 đến 10 người ăn. Không sử dụng chất bảo quản, đảm bảo vệ sinh an toàn thực phẩm. Hình dáng kiểu bánh tròn, gắn phụ kiện như mẫu.
Tặng kèm dao, nón, dao cắt bánh, dĩa, muỗng và nến cây hoặc nến số, nến sáng, pháo. Cam kết giống 100% mẫu mã và kích cỡ. Giao bánh tận nơi. Nhân bánh gồm có: Nhân bắp, mứt thơm, kiwi, dâu, chanh dây, việt quất,…',1,1)

INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Bánh kem lớn 2',1,123000,
N'https://banhkemsaigon.vn/files/sanpham/336/1/jpg/cl7-banh-kem-to-lich-gau-nho.jpg',
N'',
N'https://banhkemsaigon.vn/files/sanpham/336/1/jpg/cl7-banh-kem-to-lich-gau-nho.jpg',
N'https://banhkemsaigon.vn/files/sanpham/336/1/jpg/cl7-banh-kem-to-lich-gau-nho.jpg',
N'https://banhkemsaigon.vn/files/sanpham/336/1/jpg/cl7-banh-kem-to-lich-gau-nho.jpg',
N'Đường kính bánh 18 – 20 cm, chiều cao bánh 8 – 10 cm. Bánh dùng cho 8 đến 10 người ăn. Không sử dụng chất bảo quản, đảm bảo vệ sinh an toàn thực phẩm. Hình dáng kiểu bánh tròn, gắn phụ kiện như mẫu.
Tặng kèm dao, nón, dao cắt bánh, dĩa, muỗng và nến cây hoặc nến số, nến sáng, pháo. Cam kết giống 100% mẫu mã và kích cỡ. Giao bánh tận nơi. Nhân bánh gồm có: Nhân bắp, mứt thơm, kiwi, dâu, chanh dây, việt quất,…',1,0)


INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Bánh kem lớn 3',1,145999,
N'https://kinhdobakery.vn/files/thanhvien_upload/1/banhkemtomi3.jpg',
N'',
N'https://kinhdobakery.vn/files/thanhvien_upload/1/banhkemtomi3.jpg',
N'https://kinhdobakery.vn/files/thanhvien_upload/1/banhkemtomi3.jpg',
N'https://kinhdobakery.vn/files/thanhvien_upload/1/banhkemtomi3.jpg',
N'Đường kính bánh 18 – 20 cm, chiều cao bánh 8 – 10 cm. Bánh dùng cho 8 đến 10 người ăn. Không sử dụng chất bảo quản, đảm bảo vệ sinh an toàn thực phẩm. Hình dáng kiểu bánh tròn, gắn phụ kiện như mẫu.
Tặng kèm dao, nón, dao cắt bánh, dĩa, muỗng và nến cây hoặc nến số, nến sáng, pháo. Cam kết giống 100% mẫu mã và kích cỡ. Giao bánh tận nơi. Nhân bánh gồm có: Nhân bắp, mứt thơm, kiwi, dâu, chanh dây, việt quất,…',1,1)

INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Bánh kem lớn 4',1,115999,
N'https://banhkembo.com/wp-content/uploads/2021/03/BanhKemBo.com-Banh-Sinh-Nhat-Grand-Castella-8-3-2021-13.jpg',
N'',
N'https://banhkembo.com/wp-content/uploads/2021/03/BanhKemBo.com-Banh-Sinh-Nhat-Grand-Castella-8-3-2021-13.jpg',
N'https://banhkembo.com/wp-content/uploads/2021/03/BanhKemBo.com-Banh-Sinh-Nhat-Grand-Castella-8-3-2021-13.jpg',
N'https://banhkembo.com/wp-content/uploads/2021/03/BanhKemBo.com-Banh-Sinh-Nhat-Grand-Castella-8-3-2021-13.jpg',
N'Đường kính bánh 18 – 20 cm, chiều cao bánh 8 – 10 cm. Bánh dùng cho 8 đến 10 người ăn. Không sử dụng chất bảo quản, đảm bảo vệ sinh an toàn thực phẩm. Hình dáng kiểu bánh tròn, gắn phụ kiện như mẫu.
Tặng kèm dao, nón, dao cắt bánh, dĩa, muỗng và nến cây hoặc nến số, nến sáng, pháo. Cam kết giống 100% mẫu mã và kích cỡ. Giao bánh tận nơi. Nhân bánh gồm có: Nhân bắp, mứt thơm, kiwi, dâu, chanh dây, việt quất,…',1,0)


INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Bánh kem nhỏ 1',2,79999,
N'https://alo.flowers/wp-content/uploads/2021/09/banh-kem-sinh-nhat-mini-trang-tri-mau-sac-don-gian.jpg',
N'',
N'https://alo.flowers/wp-content/uploads/2021/09/banh-kem-sinh-nhat-mini-trang-tri-mau-sac-don-gian.jpg',
N'https://alo.flowers/wp-content/uploads/2021/09/banh-kem-sinh-nhat-mini-trang-tri-mau-sac-don-gian.jpg',
N'https://alo.flowers/wp-content/uploads/2021/09/banh-kem-sinh-nhat-mini-trang-tri-mau-sac-don-gian.jpg',
N'Đường kính bánh 5 – 10 cm, chiều cao bánh 3 – 7 cm. Bánh dùng cho 1 đến 2 người ăn. Không sử dụng chất bảo quản, đảm bảo vệ sinh an toàn thực phẩm. Hình dáng kiểu bánh tròn, gắn phụ kiện như mẫu.
Tặng kèm dao, nón, dao cắt bánh, dĩa, muỗng và nến cây hoặc nến số, nến sáng, pháo. Cam kết giống 100% mẫu mã và kích cỡ. Giao bánh tận nơi. Nhân bánh gồm có: Nhân bắp, mứt thơm, kiwi, dâu, chanh dây, việt quất,…',1,0)

INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Bánh kem nhỏ 2',2,89999,
N'https://bizweb.dktcdn.net/100/423/207/files/banh-kem-mini-trang-tri-don-gian-bat-mat.jpg?v=1625218567967',
N'',
N'https://bizweb.dktcdn.net/100/423/207/files/banh-kem-mini-trang-tri-don-gian-bat-mat.jpg?v=1625218567967',
N'https://bizweb.dktcdn.net/100/423/207/files/banh-kem-mini-trang-tri-don-gian-bat-mat.jpg?v=1625218567967',
N'https://bizweb.dktcdn.net/100/423/207/files/banh-kem-mini-trang-tri-don-gian-bat-mat.jpg?v=1625218567967',
N'Đường kính bánh 5 – 10 cm, chiều cao bánh 3 – 7 cm. Bánh dùng cho 1 đến 2 người ăn. Không sử dụng chất bảo quản, đảm bảo vệ sinh an toàn thực phẩm. Hình dáng kiểu bánh tròn, gắn phụ kiện như mẫu.
Tặng kèm dao, nón, dao cắt bánh, dĩa, muỗng và nến cây hoặc nến số, nến sáng, pháo. Cam kết giống 100% mẫu mã và kích cỡ. Giao bánh tận nơi. Nhân bánh gồm có: Nhân bắp, mứt thơm, kiwi, dâu, chanh dây, việt quất,…',1,1)

INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Bánh kem nhỏ 3',2,59000,
N'https://banhkemngonghinh.com/wp-content/uploads/2018/04/45-banh-kem-sinh-nhat-cupcake-gan-hinh-thu.jpg',
N'',
N'https://banhkemngonghinh.com/wp-content/uploads/2018/04/45-banh-kem-sinh-nhat-cupcake-gan-hinh-thu.jpg',
N'https://banhkemngonghinh.com/wp-content/uploads/2018/04/45-banh-kem-sinh-nhat-cupcake-gan-hinh-thu.jpg',
N'https://banhkemngonghinh.com/wp-content/uploads/2018/04/45-banh-kem-sinh-nhat-cupcake-gan-hinh-thu.jpg',
N'Đường kính bánh 5 – 10 cm, chiều cao bánh 3 – 7 cm. Bánh dùng cho 1 đến 2 người ăn. Không sử dụng chất bảo quản, đảm bảo vệ sinh an toàn thực phẩm. Hình dáng kiểu bánh tròn, gắn phụ kiện như mẫu.
Tặng kèm dao, nón, dao cắt bánh, dĩa, muỗng và nến cây hoặc nến số, nến sáng, pháo. Cam kết giống 100% mẫu mã và kích cỡ. Giao bánh tận nơi. Nhân bánh gồm có: Nhân bắp, mứt thơm, kiwi, dâu, chanh dây, việt quất,…',1,0)


INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Bánh kem nhỏ 4',2,39000,
N'https://product.hstatic.net/1000398438/product/mini_tim_faca36a41f7f4fb1b8862d6ecccd26cb_large.jpeg',
N'',
N'https://product.hstatic.net/1000398438/product/mini_tim_faca36a41f7f4fb1b8862d6ecccd26cb_large.jpeg',
N'https://product.hstatic.net/1000398438/product/mini_tim_faca36a41f7f4fb1b8862d6ecccd26cb_large.jpeg',
N'https://product.hstatic.net/1000398438/product/mini_tim_faca36a41f7f4fb1b8862d6ecccd26cb_large.jpeg',
N'Đường kính bánh 5 – 10 cm, chiều cao bánh 3 – 7 cm. Bánh dùng cho 1 đến 2 người ăn. Không sử dụng chất bảo quản, đảm bảo vệ sinh an toàn thực phẩm. Hình dáng kiểu bánh tròn, gắn phụ kiện như mẫu.
Tặng kèm dao, nón, dao cắt bánh, dĩa, muỗng và nến cây hoặc nến số, nến sáng, pháo. Cam kết giống 100% mẫu mã và kích cỡ. Giao bánh tận nơi. Nhân bánh gồm có: Nhân bắp, mứt thơm, kiwi, dâu, chanh dây, việt quất,…',1,0)


INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Bánh kem trái cây 1',3,199000,
N'https://chayphuongdong.com/wp-content/uploads/2020/07/e8ffcc07f6460a185357.jpg',
N'',
N'https://chayphuongdong.com/wp-content/uploads/2020/07/e8ffcc07f6460a185357.jpg',
N'https://chayphuongdong.com/wp-content/uploads/2020/07/e8ffcc07f6460a185357.jpg',
N'https://chayphuongdong.com/wp-content/uploads/2020/07/e8ffcc07f6460a185357.jpg',
N'Đường kính bánh 10 – 15 cm, chiều cao bánh 7 – 10 cm. Bánh dùng cho 6 đến 7 người ăn. Không sử dụng chất bảo quản, đảm bảo vệ sinh an toàn thực phẩm. Hình dáng kiểu bánh tròn, gắn phụ kiện như mẫu.
Tặng kèm dao, nón, dao cắt bánh, dĩa, muỗng và nến cây hoặc nến số, nến sáng, pháo. Cam kết giống 100% mẫu mã và kích cỡ. Giao bánh tận nơi. Nhân bánh gồm có: Nhân bắp, mứt thơm, kiwi, dâu, chanh dây, việt quất,…',1,1)

INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Bánh kem trái cây 2',3,229000,
N'https://banhkem360.com/uploads/file/banh-sinh-nhat-trai-cay-1-banhkem360.jpg',
N'',
N'https://banhkem360.com/uploads/file/banh-sinh-nhat-trai-cay-1-banhkem360.jpg',
N'https://banhkem360.com/uploads/file/banh-sinh-nhat-trai-cay-1-banhkem360.jpg',
N'https://banhkem360.com/uploads/file/banh-sinh-nhat-trai-cay-1-banhkem360.jpg',
N'Đường kính bánh 10 – 15 cm, chiều cao bánh 7 – 10 cm. Bánh dùng cho 6 đến 7 người ăn. Không sử dụng chất bảo quản, đảm bảo vệ sinh an toàn thực phẩm. Hình dáng kiểu bánh tròn, gắn phụ kiện như mẫu.
Tặng kèm dao, nón, dao cắt bánh, dĩa, muỗng và nến cây hoặc nến số, nến sáng, pháo. Cam kết giống 100% mẫu mã và kích cỡ. Giao bánh tận nơi. Nhân bánh gồm có: Nhân bắp, mứt thơm, kiwi, dâu, chanh dây, việt quất,…',1,0)


INSERT INTO food(foodname,menuid,foodprice,foodimghp,foodimg1,foodimg2,foodimg3,foodimg4,foodDescriptions,foodInStock,typefood)
VALUES(N'Bánh kem trái cây 3',3,279000,
N'https://banhkemdep.com/files/common/chia-se-nhung-mau-banh-sinh-nhat-trai-cay-thom-ngon-danh-cho-ban-dymc0.jpg',
N'',
N'https://banhkemdep.com/files/common/chia-se-nhung-mau-banh-sinh-nhat-trai-cay-thom-ngon-danh-cho-ban-dymc0.jpg',
N'https://banhkemdep.com/files/common/chia-se-nhung-mau-banh-sinh-nhat-trai-cay-thom-ngon-danh-cho-ban-dymc0.jpg',
N'https://banhkemdep.com/files/common/chia-se-nhung-mau-banh-sinh-nhat-trai-cay-thom-ngon-danh-cho-ban-dymc0.jpg',
N'Đường kính bánh 10 – 15 cm, chiều cao bánh 7 – 10 cm. Bánh dùng cho 6 đến 7 người ăn. Không sử dụng chất bảo quản, đảm bảo vệ sinh an toàn thực phẩm. Hình dáng kiểu bánh tròn, gắn phụ kiện như mẫu.
Tặng kèm dao, nón, dao cắt bánh, dĩa, muỗng và nến cây hoặc nến số, nến sáng, pháo. Cam kết giống 100% mẫu mã và kích cỡ. Giao bánh tận nơi. Nhân bánh gồm có: Nhân bắp, mứt thơm, kiwi, dâu, chanh dây, việt quất,…',1,0)



CREATE TABLE news(
  newsid INT IDENTITY (1,1) NOT NULL,
  newsname NVARCHAR(1000)  NOT NULL,
  newsavata  NVARCHAR(1000)  NOT NULL, 
  Descriptions NTEXT  NOT NULL,
  PRIMARY KEY (newsid)
)

INSERT INTO news(newsname,newsavata,Descriptions)
VALUES(N'Đặt Bánh Kem và Hoa Tươi Tặng Ngày Phụ Nữ 20/10 và 8/3',N'http://banhkemngon.vn/uploads/files/SEO%20(337).jpg',N'Hãy thể hiện sự tinh tế và bản lĩnh của mình với người bạn đời của mình qua ngày phụ nữ Việt Nam 20/10 này nhé. 
Hãy gọi theo đường dây nóng  012345678 để được tư vấn miễn phí và đặt hàng. 
Đặt bánh kem tặng mẹ và bạn gái ngày 20.10 mang ý nghĩa vô cùng quan trọng giúp gắn bó tình cảm và nâng tầm cao giá trị của cuộc sống.
Hãy liên hệ cho shop bánh kem ngon mỗi ngày để được tư vấn đặt bánh phù hợp nhất các bạn nhé.')


INSERT INTO news(newsname,newsavata,Descriptions)
VALUES(N'Đặt Bánh Kem Tặng Ngày Quốc Tế Phụ Nữ 20/10',N'http://banhkemngon.vn/uploads/files/SEO%20(763).jpg',
N'Hiện nay, những mẫu bánh kem tặng ngày 20/10 mang tới cho khách hàng và có những phản hồi khá tốt như Bánh kem Bắp, Bánh kem tươi, 
Bánh kem tiramisu, Bánh kem in hình tặng ngày 20/10 lên mặt bánh hay Bánh kem viết những dòng chữ ngọt ngào theo yêu cầu..v...v.. 
kèm theo đó là những bó hoa được các phái nữ đặc biệt yêu thích như hoa hồng ( hồng vàng, hồng phấn, hồng đỏ....), 
hoa hướng dương, hoa salem,... Liên hệ đặt hàng : 012345678')

INSERT INTO news(newsname,newsavata,Descriptions)
VALUES(N'Shop Bánh Kem Ngon Mỗi Ngày Tư Vấn Đặt Bánh Kem',N'https://chayphuongdong.com/wp-content/uploads/2020/07/e8ffcc07f6460a185357.jpg',
N'Shop Bánh Kem Ngon Mỗi Ngày tư vấn đặt bánh kem theo yêu cầu, 
chuyên cung cấp những mẫu bánh kem đẹp nhất và ý nghĩa nhất. Cửa hàng bánh kem ngon ở Sài Gòn luôn đưa tới cho khách hàng sự lựa chọn 
hài lòng và tuyệt đối nhằm mang đến cho quý khách hàng những mẫu bánh kem phù hợp với túi tiền và bữa tiệc sinh nhật. 
Chúng tôi luông nỗ lực mang đến cho khách hàng những sự tiện lợi trong khâu đặt bánh kem và lựa chọn bánh sinh nhật phù hợp.
Những mẫu bánh kem tươi giá rẻ luôn được khách hàng tin tưởng và sử dụng đặt hàng. Liên hệ tư vấn đặt bánh : 012345678. 
Đến với bánh kem ngon mỗi ngày quý khách hàng luôn được chăm sóc chu đáo và nhiệt tình nhất. Cảm ơn quý khách luôn đồng hàng cùng shop.')


 CREATE TABLE CustomerSP(
	 customerSPid int IDENTITY (1,1) NOT NULL,
	 customerSPname NVARCHAR(1000),
	 customerSPemail NVARCHAR(1000),
	 customerSPDescriptions NTEXT  NOT NULL,
	 PRIMARY KEY (customerSPid)
 )

 --Tạo table Slide 
create table slide(
	slideid int identity(1,1) NOT NULL,
	slidetitle nvarchar (1000) NOT NULL ,
	slidedescription nvarchar (1000),
	slideimg nvarchar(1000),
	slideActive int,
	slidetype int ,
)
insert into slide (slidetitle,slidedescription,slideimg,slideActive,slidetype )
values ( N'Bánh kem nhỏ',N'Những chiếc bánh kem xinh xắn đáng yêu, thích hợp cho những buổi tiệc sinh nhật nhỏ nhắn bên cạnh những người mình yêu quý
, với giá thành rất rẻ nhưng vẫn có thể cảm nhận trọn không khí sinh nhật','https://hanamihotel.com/wp-content/uploads/2020/03/tiem-banh-kem-vani-Da-Nang.jpg',1,1)
insert into slide (slidetitle,slidedescription,slideimg,slideActive,slidetype )
values ( N'Bánh kem trái cây',N'Một chiếc bánh kem cân bằng dinh dưỡng với những trái cây xanh tươi, giúp cho những hội chị em hay 
những người khác có nỗi niềm sợ béo phì có thể thoải mái tham gia những bữa tiệc sinh nhật mà không phải sợ lên cân','https://banhkemdep.com/files/common/chia-se-nhung-mau-banh-sinh-nhat-trai-cay-thom-ngon-danh-cho-ban-lk0qi.jpg',0,1)
insert into slide (slidetitle,slidedescription,slideimg,slideActive,slidetype )
values ( N'Bánh kem lớn',N'Một chiếc bánh kem ú nụ cho một bữa tiệc sinh nhật thật hoành tráng, thích hợp cho những bữa tiệc lớn,
 tạo những kỉ niệm đáng quý cho mọi người tham gia','https://ichef.bbci.co.uk/images/ic/1200xn/p060z50q.jpg',0,1)
 
CREATE TABLE Cart ( 
	Cartid  INT  IDENTITY (1,1) NOT NULL, 
	foodid INT,
	foodname NVARCHAR(1000)  NOT NULL, 
	foodprice INT NOT NULL,
	foodimghp  NVARCHAR(1000)  NOT NULL, 
	Allprice int  NOT NULL, 
    cartquantity INT,
	PRIMARY KEY (Cartid),
	customerid int   NOT NULL,
	CONSTRAINT PK_Customer_Cart FOREIGN KEY(customerid)
	REFERENCES Customer(customerid),
	)
	GO

	select * from Cart


	CREATE TABLE About ( 
	Abouttid  INT  IDENTITY (1,1) NOT NULL, 
	Abouttitle NVARCHAR(1000)  NOT NULL, 
	Aboutimg NVARCHAR(1000)  NOT NULL, 
	AboutDescriptions  NVARCHAR(1000)  NOT NULL, 
	PRIMARY KEY (Abouttid)
	)
	GO
	
	insert into About(Abouttitle,Aboutimg, AboutDescriptions)
     values(N'Tiệm bánh Chewy Junior',N'https://cdn.cet.edu.vn/wp-content/uploads/2020/03/kinh-doanh-tiem-banh-ngot.jpg',
	 N'Tiệm Bánh Xinh được ra đời với thông điệp mang đam mê của chúng tôi gửi gắm đến bạn qua những chiếc 
	 bánh ngọt và thức uống ngon, giá rẻ, vệ sinh và chất lượng luôn được đặt lên hàng đầu. 
	 Sự ra đời của mỗi chiếc bánh đều được chọn lọc kỹ lưỡng tâm huyết của đội ngũ chúng tôi từ khâu nguyên liệu, 
	 chế biến để khi đến tay của các bạn, chúng đều trở thành sản phẩm hoàn hảo nhất.')
	 insert into About(Abouttitle,Aboutimg, AboutDescriptions)
     values(N'MÔ HÌNH PHƯƠNG TÂY',N'https://images.foody.vn/res/g75/744393/prof/s640x400/foody-upload-api-foody-mobile-it-jpg-180524165421.jpg',
	 N'Tiệm Bánh được xây dựng và hoạt động theo mô hình phương Tây. Mỗi chiếc bánh được làm ra với phong cách mang đậm hương vị đến từ Pháp
	 và Mỹ – hai đất nước nổi tiếng tiên phong trong việc cho ra đời những món tráng miệng ngon và đẹp mắt bậc nhất thế giới.
	 ')
	

	
	CREATE TABLE Customer(
customerid int IDENTITY (1,1) NOT NULL,
customername NVARCHAR(1000)  NOT NULL,
customerusername NVARCHAR(1000)  NOT NULL,
customerpassword NVARCHAR(1000),
customeremail NVARCHAR(1000)  NOT NULL,
customernumber  NVARCHAR(1000)  NOT NULL,
customeraddress NVARCHAR(1000)  NOT NULL,
PRIMARY KEY (customerid)
)
INSERT INTO Customer(customername,customerusername,customerpassword,customeremail,customernumber ,customeraddress)
VALUES(N'Minh Toan', N'Tona', N'123456',N'tona@gamil.com','123456789','abcxyz')


	CREATE TABLE Bill ( 
BillId  INT  IDENTITY (1,1) NOT NULL, 
Customer NVARCHAR(1000)  NOT NULL, 
Phonenumber NVARCHAR(1000)  NOT NULL, 
Address  NVARCHAR(1000)  NOT NULL, 
customerid int   NOT NULL,
DayOrder datetime DEFAULT (getdate()),
Status  INT  NOT NULL, 
PRIMARY KEY (BillId),
CONSTRAINT PK_Customer FOREIGN KEY(customerid)
	REFERENCES Customer(customerid)
	)
	GO 


	CREATE TABLE BillDetail ( 
BiDid  INT  IDENTITY (1,1) NOT NULL, 
Quantity INT  NOT NULL, 
BillId Int,
foodname NVARCHAR(1000)  NOT NULL, 
foodprice INT NOT NULL,
Allprice int  NOT NULL, 
PRIMARY KEY (BiDid),
)



	CREATE TABLE Comments (
commentid int IDENTITY (1,1) NOT NULL,
foodid int  NOT NULL,
foodname NVARCHAR(1000) NOT NULL,
customername NVARCHAR(1000) NOT NULL,
commentDescriptions NVARCHAR(1000) NOT NULL,
PRIMARY KEY (Commentid)
)
go


CREATE TABLE admin (
adminid int IDENTITY (1,1) NOT NULL,
UserName NVARCHAR(1000) NOT NULL,
Password NVARCHAR(1000) NOT NULL,
PRIMARY KEY (adminid),
)
go

select * from admin
 

insert into admin(UserName, Password)
values(N'toan',N'toan')
insert into admin(UserName, Password)
values(N'hung',N'hung')

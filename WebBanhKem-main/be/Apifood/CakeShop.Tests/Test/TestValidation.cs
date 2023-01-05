using CakeShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CakeShop.ValidationTesting
{
    [TestClass]
    public class TestValidationCustomer
    {
      
        [TestMethod]
        public void Customer_TestMissingName()
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = "",
                Username = "user123",
                Password = "123123",
                Email = "abc@gav.com",
                Address = "abcxxz",
                Phone = "95336"
            };
            var lstErrors = ValidateModel(add);

            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Vui lòng nhập Họ tên")).Count() > 0, "Trường Name đã được nhập");
        }

        [TestMethod]
        public void Customer_TestMissingUsername()
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = "Nguyen Van A",
                Username = "",
                Password = "123456",
                Email = "abc@gav.com",
                Address = "abcxxz",
                Phone = "95336"
            };
            var lstErrors = ValidateModel(add);

            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Vui lòng nhập tên đăng nhập")).Count() > 0, "Trường Username đã được nhập");
        }


        [TestMethod]
        public void Customer_TestMissingPassword()
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = "Nguyen Van A",
                Username = "user123",
                Password = "",
                Email = "abc@gav.com",
                Address = "abcxxz",
                Phone = "95336"
            };
            var lstErrors = ValidateModel(add);

            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Vui lòng nhập Password")).Count() > 0, "Trường Password đã được nhập");
        }

        [TestMethod]
        public void Customer_TestMissingEmail()
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = "Name",
                Username = "user123",
                Password = "123456",
                Email = "",
                Address = "123 abc",
                Phone = "12345678"
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Vui lòng nhập Email")).Count() > 0, "Trường Email đã được nhập");
        }

        [TestMethod]
        public void Customer_TestMissingAddress()
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = "Name",
                Username = "user123",
                Password = "123456",
                Email = "email@c.com",
                Address = "",
                Phone = "12345678"
            };
            var lstErrors = ValidateModel(add);

            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Vui lòng nhập địa chỉ")).Count() > 0, "Trường địa chỉ đã được nhập");
        }

        [TestMethod]
        public void Customer_TestMissingPhone()
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = "Name",
                Username = "user123",
                Password = "123456",
                Email = "email@c.com",
                Address = "123 abc",
                Phone = ""
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Vui lòng nhập SDT")).Count() > 0, "Trường SDT đã được nhập");
        }

        [TestMethod]
        [DataRow("Nguyen Van A")]
        //[DataRow("Nguyen Van @")]
        //[DataRow("Nguyen Van 1")]
        public void Customer_TestNameShouldCorrectFormat(string name)
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = name,
                Username = "abc",
                Password = "123",
                Email = "abc@gav.com",
                Address = "abcxxz",
                Phone = "95336"
            };
            var lstErrors = ValidateModel(add);

            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Kí tự đặc biệt không được cho phép")).Count() == 0, "Kí tự đặc biệt không được cho phép");
        }


        [TestMethod]
        //[DataRow("Nguyen Van A")]
        [DataRow("Nguyen Van @")]
        [DataRow("Nguyen Van 1")]
        public void Customer_TestNameShouldNotCorrectFormat(string name)
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = name,
                Username = "abc",
                Password = "123",
                Email = "abc@gav.com",
                Address = "abcxxz",
                Phone = "95336"
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Kí tự đặc biệt không được cho phép")).Count() > 0,"Trường Name đã nhập đúng ràng buộc");
        }

        [TestMethod]
        [DataRow("user123")]
        //[DataRow("user12@")]
        //[DataRow("user")]
        public void Customer_TestUserNameShouldCorrectFormat(string username)
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = "Nguyen Van A",
                Username = username,
                Password = "123123",
                Email = "abc@gav.com",
                Address = "abcxxz",
                Phone = "95336"
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Kí tự đặc biệt không được cho phép.")).Count() == 0, "Kí tự đặc biệt không được cho phép.");

            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Độ dài tài khoản chứa 6 - 50 kí tự")).Count() == 0, "Độ dài tài khoản chứa 6 - 50 kí tự");
        }

        [TestMethod]
        //[DataRow("user123")]
        [DataRow("user12@")]
        [DataRow("user")]
        public void Customer_TestUserNameShouldNotCorrectFormat(string username)
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = "Nguyen Van A",
                Username = username,
                Password = "123123",
                Email = "abc@gav.com",
                Address = "abcxxz",
                Phone = "95336"
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Kí tự đặc biệt không được cho phép.")).Count() > 0 || 
                lstErrors.Where(x => x.ErrorMessage.Contains("Độ dài tài khoản chứa 6 - 50 kí tự")).Count() > 0, "Trường Username đã nhập đúng ràng buộc");
        }


        

        [TestMethod]
        [DataRow("123abc")]
        //[DataRow("123")]
        //[DataRow("12a")]
        public void Customer_TestPasswordShouldCorrectFormat(string password)
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = "Nguyen Van A",
                Username = "abc",
                Password = password,
                Email = "abc@gav.com",
                Address = "abcxxz",
                Phone = "95336"
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Mật khẩu phải chứa 6 kí tự trở lên")).Count() == 0, "Mật khẩu phải chứa 6 kí tự trở lên");
        }

        [TestMethod]
        //[DataRow("123abc")]
        [DataRow("123")]
        [DataRow("12a")]
        public void Customer_TestPasswordShoudNotCorrectFormat(string password)
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = "Nguyen Van A",
                Username = "abc",
                Password = password,
                Email = "abc@gav.com",
                Address = "abcxxz",
                Phone = "95336"
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Mật khẩu phải chứa 6 kí tự trở lên")).Count() > 0, "Trường Password đã nhập đúng ràng buộc");
        }



        [TestMethod]
        [DataRow("email@email.com")]
        //[DataRow("email.com")]
        //[DataRow("email@a@em.com")]
        public void Customer_TestEmailShouldCorrectFormat(string email)
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = "Nguyen Van A",
                Username = "abc",
                Password = "123456",
                Email = email,
                Address = "abcxxz",
                Phone = "95336"
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Vui lòng nhập đúng định dạng Email")).Count() == 0, "Trường Email đã nhập sai ràng buộc");
        }

        [TestMethod]
        //[DataRow("email@email.com")]
        [DataRow("email.com")]
        [DataRow("email@a@em.com")]
        public void Customer_TestEmailShoudNotCorrectFormat(string email)
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = "Nguyen Van A",
                Username = "abc",
                Password = "123456",
                Email = email,
                Address = "abcxxz",
                Phone = "95336"
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Vui lòng nhập đúng định dạng Email")).Count() > 0, "Trường Email đã nhập đúng ràng buộc");
        }


        [TestMethod]
        [DataRow("012345678")]
        //[DataRow("0123a45")]
        //[DataRow("0")]
        public void Customer_TestPhoneShouldCorrectFormat(string phone)
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = "Nguyen Van A",
                Username = "abc",
                Password = "123456",
                Email = "email@gmail.com",
                Address = "abcxxz",
                Phone = phone
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Chỉ cho phép kí tự số")).Count() == 0, "Chỉ cho phép kí tự số");
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Độ dài SĐT chứa 6 - 50 kí tự")).Count() == 0, "Độ dài SĐT chứa 6 - 50 kí tự");
        }

        [TestMethod]
        //[DataRow("012345678")]
        [DataRow("0123a45")]
        [DataRow("0")]
        public void Customer_TestPhoneShouldNotCorrectFormat(string phone)
        {
            Customer add = new Customer
            {
                Id = 2,
                Name = "Nguyen Van A",
                Username = "abc",
                Password = "123456",
                Email = "email@gmail.com",
                Address = "abcxxz",
                Phone = phone
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Chỉ cho phép kí tự số")).Count() > 0 ||
                lstErrors.Where(x => x.ErrorMessage.Contains("Độ dài SĐT chứa 6 - 50 kí tự")).Count() > 0, "Trường Phone đã nhập đúng ràng buộc");
        }



        //thu thap loi
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

    }

    [TestClass]
    public class TestValidationProduct
    {
        [TestMethod]

        public void Product_TestMissingProductNameImgDes()
        {
            Product add = new Product
            {
                Id = 1,
                ProductName = "",
                Price = 0,
                foodimghp = "abc123",
                foodDescriptions = "abcxyz",
                foodInStock = 1
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Vui lòng nhập ProductName")).Count() > 0);
        }

        [TestMethod]
        public void Product_TestMissingImg()
        {
            Product add = new Product
            {
                Id = 1,
                ProductName = "Productname",
                Price = 0,
                foodimghp = "",
                foodDescriptions = "abcxyz",
                foodInStock = 1
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Vui lòng nhập hình ảnh")).Count() > 0);
        }

        [TestMethod]
        public void Product_TestMissingDes()
        {
            Product add = new Product
            {
                Id = 1,
                ProductName = "ProductName",
                Price = 0,
                foodimghp = "abc123",
                foodDescriptions = "",
                foodInStock = 1
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Vui lòng nhập Mô tả")).Count() > 0);
        }


        [TestMethod]
        [DataRow("Banh kem 1")]
        //[DataRow("Banh kem @")]
        [DataRow("Banh kem")]
        public void Product_TestProductNameShouldCorrectFormat(string productName)
        {
            Product add = new Product
            {
                Id = 1,
                ProductName = productName,
                Price = 1,
                foodimghp = "abc",
                foodDescriptions = "aab",
                foodInStock = 1
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Kí tự đặc biệt không được cho phép.")).Count() == 0, "Kí tự đặc biệt không được cho phép.");
        }

        [TestMethod]
        //[DataRow("Banh kem 1")]
        [DataRow("Banh kem @")]
        //[DataRow("Banh kem")]
        public void Product_TestProductNameShouldNotCorrectForm(string productName)
        {
            Product add = new Product
            {
                Id = 1,
                ProductName = productName,
                Price = 1,
                foodimghp = "abc",
                foodDescriptions = "aab",
                foodInStock = 1
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Kí tự đặc biệt không được cho phép.")).Count() > 0, "ProductName đã nhập đúng ràng buộc");
        }

        [TestMethod]
        [DataRow(100)]
        //[DataRow(-1)]
        //[DataRow(0)]
        public void Product_TestPriceShouldCorrectFormat(int price)
        {
            Product add = new Product
            {
                Id = 1,
                ProductName = "Banh kem",
                Price = price,
                foodimghp = "abc",
                foodDescriptions = "aab",
                foodInStock = 1
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Giá tiền phải lớn hơn 0")).Count() == 0, "Giá tiền phải lớn hơn 0");
        }

        [TestMethod]
        //[DataRow(100)]
        [DataRow(-1)]
        //[DataRow(0)]
        public void Product_TestPriceShouldNotCorrectFormat(int price)
        {
            Product add = new Product
            {
                Id = 1,
                ProductName = "Product1",
                Price = price,
                foodimghp = "",
                foodDescriptions = "",
                foodInStock = 1
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Giá tiền phải lớn hơn 0")).Count() > 0, "Price đã nhập đúng ràng buộc");
        }



        [TestMethod]
        [DataRow("Banh kem duoc lam tu")]
        //[DataRow("Banh kem @")]
        [DataRow("Duoc xuat xu tu Cali")]
        public void Product_TestDescriptionShouldCorrectFormat(string des)
        {
            Product add = new Product
            {
                Id = 1,
                ProductName = "Banh kem",
                Price = 1000000,
                foodimghp = "abc",
                foodDescriptions = des,
                foodInStock = 1
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Kí tự đặc biệt không cho phép.")).Count() == 0, "Kí tự đặc biệt không cho phép.");
        }

        [TestMethod]
        //[DataRow("Banh kem duoc lam tu")]
        [DataRow("Banh kem @")]
        //[DataRow("Duoc xuat xu tu Cali")]
        public void Product_TestDescriptionShouldNotCorrectFormat(string des)
        {
            Product add = new Product
            {
                Id = 1,
                ProductName = "Banh kem",
                Price = 1000000,
                foodimghp = "abc",
                foodDescriptions = des,
                foodInStock = 1
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Kí tự đặc biệt không cho phép.")).Count() > 0, "Description đã nhập đúng ràng buộc");
        }

        [TestMethod]
        [DataRow(5)]
        [DataRow(0)]
        //[DataRow(-1)]
        public void Product_TestStockShouldCorrectFormat(int stock)
        {

            Product add = new Product
            {
                Id = 1,
                ProductName = "Banh kem",
                Price = 1000000,
                foodimghp = "abc",
                foodDescriptions = "Duoc xuat xu tu abc",
                foodInStock = stock
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Số lượng tồn phải lớn hơn hoặc bằng 0")).Count() == 0, "Số lượng tồn phải lớn hơn hoặc bằng 0");
        }

 

        [TestMethod]
        //[DataRow(5)]
        //[DataRow(0)]
        [DataRow(-1)]
        public void Product_TestStockShouldNotCorrectFormat(int stock)
        {

            Product add = new Product
            {
                Id = 1,
                ProductName = "Banh kem",
                Price = 1000000,
                foodimghp = "abc",
                foodDescriptions = "Duoc xuat xu tu abc",
                foodInStock = stock
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Số lượng tồn phải lớn hơn hoặc bằng 0")).Count() > 0, "Stock đã nhập đúng ràng buộc");
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}

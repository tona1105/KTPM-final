using System;
using System.ComponentModel.DataAnnotations;
//regex tieng viet co dau, chu so  va space:
//@"^([A-Za-z_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ0-9\s]*$)"


namespace StoreApp.Models
{
    public class Product
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập ProductName")]
        [RegularExpression(@"^([A-Za-z0-9\s]*$)", ErrorMessage = "Kí tự đặc biệt không được cho phép.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá")]
        [Range(1, int.MaxValue, ErrorMessage = "Giá tiền phải lớn hơn 0")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập hình ảnh")]
        public string foodimghp { get; set; }

        [RegularExpression(@"^([A-Za-z0-9\s]*$)", ErrorMessage = "Kí tự đặc biệt không cho phép.")]
        [Required(ErrorMessage = "Vui lòng nhập Mô tả")]
        public string foodDescriptions { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tồn kho")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn phải lớn hơn hoặc bằng 0")]
        public int? foodInStock { get; set; }
    }
}
function addProductversion() {
    //id san phẩm
    let ProductID = $('#ProductID').val();
    //id phiên bản sản phẩm
    let Versionid = $('#VersionID').val();
    //id tên phiên bản sản phẩm
    let VersionName = $('#VersionName').val();
    // giá phiên bản sản phẩm
    let VersionPrice = $('#VersionPrice').val();
    //trạng thái sản phẩm
    let VersionStatus = $('#VersionStatus').val();
    //Thêm phiên bản sản phẩm
    $.ajax({
        type: "POST",
        url: "/AddVersionProduct",
        dataType: "json",
        data: {
            VersionId: Versionid,
            ProductId: ProductID,
            VersionName: VersionName,
            ProductPrice: VersionPrice,
            ProductStatus: VersionStatus,

        },
        success: function (data) {
            if (data == true) {
                // danh sach id thuoc tinh
                const DataProperty = document.querySelectorAll('.DataProperty');
                // value thuoc tinh
                const InputPropertys = document.querySelectorAll('.InputProperty');
                // don vi thuoc tinh
                const DataInput = document.querySelectorAll('.data-input');

                let VersionProductid = $('#VersionID').val();
                let valueProperty = [];
                //vòng lập tạo đối tượng
                for (let i = 0; i < InputPropertys.length; i++) {
                    let val = InputPropertys[i].value;
                    val = val + DataInput[i].dataset.input;
                    let oj = { VersionId: VersionProductid, PropertiesId: DataProperty[i].dataset.dataproperty, Value: val };
                    valueProperty.push(oj);
                }
                //ajax thêm thông tin thông số kỹ thuật
                $.ajax({
                    type: "POST",
                    url: "/AddPropertyValue",
                    dataType: "json",
                    data: { valueProperty: valueProperty },
                    success: function (data) {
                        if (data == true) {

                            const ListQuantity = document.querySelectorAll('.input-quantity');
                            const ListColorId = document.querySelectorAll('.list-color-id');
                            let valueQuantity = [];

                            //vòng lặp lấy thông tin số lượng sản phẩm
                            for (let i = 0; i < ListQuantity.length; i++) {
                                let quantity = ListQuantity[i].value;
                                let color = ListColorId[i].dataset.colorid;
                                let oj = { VersionId: Versionid, ColorId: color, Quantity: quantity };
                                valueQuantity.push(oj);
                            }
                            $.ajax({
                                type: "POST",
                                url: "/AddVersionQuantity",
                                dataType: "json",
                                data: { versionQuantity: valueQuantity },
                                success: function (data) {
                                    if (data == true) {
                                        alert("Thêm sản phẩm thành công");
                                    } else {
                                        alert("Cập nhật số lượng cho sản phẩm thất bại");
                                    }
                                },
                                error: function () {
                                    alert("Cập nhật số lượng cho sản phẩm thất bại");
                                }
                            });
                        } else {
                            alert("Thêm thông tin thông số kỹ thuật sản phẩm thất bại");
                        }
                    },
                });
            } else {
                alert("Thêm sản phẩm thất bại");
            }
        },
        error: function () {
            alert("Thêm sản phẩm thất bại");
        }
    });
}


if ($('#deleteProduct')) {
    $('#deleteProduct').click(function () {
        $('#preview').attr("src", "#");
    });
}
if ($('#form-Product')) {
    $('#form-Product').submit(function (e) {
        if (!checkCode($('#ProductId').val())) {
            setError(document.querySelector('#ProductId'));
            e.preventDefault();
        } else {
            setTrue(document.querySelector('#ProductId'));
        }
        if ($('#ProuctName').val() == "") {
            setError(document.querySelector('#ProuctName'));
            e.preventDefault();
        }
        else {
            setTrue(document.querySelector('#ProuctName'));
        }

        if (document.getElementById('preview').src.includes("#") == true) {
            alert("Chưa chọn hình");
            e.preventDefault();
        }
        
        //if (checkCode($('#ProductId').val()) && $('#ProuctName').val() != "" && document.getElementById('preview').src.includes("#") == false) {
        //    e.preventDefault();
        //    $.ajax({
        //        context: this,
        //        type: "POST",
        //        url: "/CheckProductId",
        //        dataType: "json",
        //        data: { ProductId: $('#ProductId').val() },
        //        success: function (data) {
        //            if (data == false) {
        //                alert("Mã sản phẩm đã tồn tại");
        //            } else {
        //                this.submit();
        //            }
        //        },
        //        error: function () {
        //            alert("Cập nhật thất bại");
        //        }
        //    });
           
        //}
    });
}

if ($('#form-color')) {
    $('#form-color').submit(function (e) {
        if ($('#ColorDescription').val() == "") {
            setError(document.querySelector('#ColorDescription'));
            e.preventDefault();
        }
        else {
            setTrue(document.querySelector('#ColorDescription'));
        }
        if (document.getElementById('preview').src.includes("#") == true) {
            alert("Chưa chọn hình");
            e.preventDefault();
        }
    });
}
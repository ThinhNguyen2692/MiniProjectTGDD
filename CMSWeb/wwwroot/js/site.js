$(".showProduct").click(function () {
    if ($('#show').hasClass("show")) {
        $('#show').removeClass("show");
    } else {
        $('#show').addClass("show");
    }
});

const imageDelete = document.getElementById('img-delete');

if ($(".btn-delete-brands")) {
    $(".btn-delete-brands").click(function (event) {
        let key = this.value.split("#",2);
        let id = key[0];
        let path = key[1];
        console.log(imageDelete.src);
        $.ajax({
            type: "POST",
            url: "/DeleteBrands",
            dataType: "json",
            data: {
                id: id
            },
            success: function (data) {
                if (data != null) {
                  
                    $(".value-brands").html("");

                    for (var item in data) {
                        var htmlstring = $(".value-brands").html();
                        console.log(data[item]);
                        console.log(data[item].brandId);
                        $(".value-brands").html("");
                        $(".value-brands").html(htmlstring + '<tr><td><img style="display: block;max-width:230px;max-height:95px;width: auto;height: auto; border-radius: 0;" src = "/images/' + data[item].brandPhoto + '" /> </td > <td> ' + data[item].brandId + ' </td> <td>' + data[item].brandName + ' </td><td> ' + data[item].brandId + ' </td><td style="width:200px;"><div><a class="btn btn btn-outline-danger" href="/FromUpdateBrands?id=' + data[item].brandId + '">Cập nhật</a><button class="btn btn-delete-brands btn-outline-danger" value="' + data[item].brandId + '#' + data[item].brandPhoto + '"> Xóa</button></div></td></tr > ');
                        $.ajax({
                            type: "POST",
                            url: "/DeleteImage",
                            dataType: "json",
                            data: {
                                path: path
                            },
                            success: function (data) {

                                alert("Xoa file thanh cong");
                            }
                        });
                    }
                }
            },
            error: function () {
                alert("Xóa thất bại, có thể chuyển trạng thại về ngưng kinh doanh");
            }
        })
       
    }
    )

}

const formAddProperties = document.querySelector('#form-add-properties');
const PropertiesName = document.querySelector('#PropertiesName');


formAddProperties.addEventListener("submit", function (e) {
    if (PropertiesName.value == "") {
        setError(PropertiesName);
        e.preventDefault();
    } else {
        setTrue(bransId);
    }
});
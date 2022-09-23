

function GEtDetail(OrderId) {

    $.ajax({
        type: 'POST',
        url: '/PurchaseOrderDetail',
        dataType: 'json',
        data: { OrderId: OrderId },
        success: function (data) {
            console.log(data.PurchaseOrderDetails.$values);
            var html = "";
            data.PurchaseOrderDetails.$values.forEach(function (item2) {
                var htmlvalue2 = "";
                item2.GiftDetails.$values.forEach(function (item) {
                    htmlvalue2 += '<div style="margin-left: 60px;">tên sản phẩm: ' + item.ProuctName + '</div><div style="margin-left: 60px;">giá sản phẩm: ' + item.ProductPrice + '</div><div style="margin-left: 60px;"><img style="width: 20px; height: 20px; " src="/images/ProductDefault/' + item.ProductPhoto + '"/></div><div style="margin-left: 60px;">Số lượng: ' + item.GiftQuantiy + '</div>';
                })
                html += '<div style="margin-left: 30px;">tên sản phẩm: ' + item2.OrderProudctName + '</div><div style="margin-left: 30px;">giá sản phẩm: ' + item2.OrderPrice + '</div><img style="margin-left: 30px;width: 20px; height: 20px;" src="https://localhost:7079/images/ProductDefault/' + item2.OrderProductPhoto + '"/><div style="margin-left: 30px;"> khuyến mãi</div>' + htmlvalue2;
            });
            // success callback function
            $(".modal-body").html('<div>Mã hóa đơn:' + data.OrderId + ' Số điện thoại khách hàng:' + data.CustomerPhone +'</div><div> Danh sách sản phẩm</div>' + html + '<div>Tổng tiền: tổng khuyến mãi: thành tiền</div> <div>Địa chỉ: </div> ');
           // $(".modal-body").html("jveh");
        },
        error: function () {
            $(".modal-body").html("tui");
        }
    });
}

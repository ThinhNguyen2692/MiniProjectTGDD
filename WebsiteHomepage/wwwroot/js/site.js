function usd() {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "https://portal.vietcombank.com.vn/Usercontrols/TVPortal.TyGia/pXML.aspx?b=10",
        dataType: 'json',
        success: function (data) {

            console.log(data);
        }
    });
}
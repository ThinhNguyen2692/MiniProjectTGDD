
function UpdataSpecification(id, typeid) {

    const intputSpecificaltion = document.querySelector('.intputSpecification-' + id);
    $.ajax({
        type: "POST",
        url: "/UpdataSpecification",
        dataType: "json",
        data: {
            SpecificationsId: id,
            Typeid: typeid,
            SpecificationsName: intputSpecificaltion.value
            
        },
        success: function (data) {
            if (data == true) {
                alert("Cập nhật thành công");
            }
            else {
                alert("Cập nhật thất bại");
            }
        },
        error: function () {
            alert("Cập nhật thất bại");
        }
    })
}


function UpdateProperty(id, Specificaltionid) {

    const intputSpecificaltion = document.querySelector('.InputProperty-'+ id);
    const input = document.querySelector('.Input-' + id);
    console.log(input.value);

    $.ajax({
        type: "POST",
        url: "/UpdataProperty",
        dataType: "json",
        data: {
            PropertiesId: id,
            SpecificationsId: Specificaltionid,
            PropertiesName: intputSpecificaltion.value,
            PropertiesDescription: input.value
        },
        success: function (data) {
            if (data == true) {
                alert("Cập nhật thành công");
            }
            else {
                alert("Cập nhật thất bại");
            }
        },
        error: function () {
            alert("Cập nhật thất bại");
        }
    })
}


$('#addType').click(function () {
    const id = $("#TypeId").val();
    const name = $('#TypeName').val();
    $.ajax({
        type: "POST",
        url: "/UpdataType",
        dataType: "json",
        data: {
            Typeid: id,
            Typename: name
        },
        success: function (data) {
            if (data == true) {
                alert("Cập nhật thành công");
            }
            else {
                alert("Cập nhật thất bại");
            }
        },
        error: function () {
            alert("Cập nhật thất bại");
        }
    })

});





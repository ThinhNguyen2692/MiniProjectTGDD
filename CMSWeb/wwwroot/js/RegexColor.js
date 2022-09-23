if ($('#form-color')) {
    $('#form-color').submit(function (e) {
        if ($('.ColorDescription').val() == "") {
            setError(document.querySelector('.ColorDescription'));
            e.preventDefault();
        }
        else {
            setTrue(document.querySelector('.ColorDescription'));
        }
        if (document.getElementById('preview').src.includes("#") == true) {
            alert("Chưa chọn hình");
            e.preventDefault();
        }
    });
}
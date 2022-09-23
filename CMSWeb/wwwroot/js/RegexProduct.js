if ($('.form-Product')) {

    if ($('.ProductId')) {
        document.querySelector('.ProductId').addEventListener("keyup", function (e) {

            if (!checkCode($('.ProductId').val())) {
                setError(document.querySelector('.ProductId'));

            } else {
                setTrue(document.querySelector('.ProductId'));
            }
        })
    }
    if ($('.ProuctName')) {
        document.querySelector('.ProuctName').addEventListener("keyup", function (e) {
            if ($('.ProuctName').val() == "") {
                setError(document.querySelector('.ProuctName'));

            } else {

                setTrue(document.querySelector('.ProuctName'));
            }
        })
    }


    $('.form-Product').submit(function (e) {
        if (!checkCode($('.ProductId').val())) {
            setError(document.querySelector('.ProductId'));
            e.preventDefault();
        } else {
            setTrue(document.querySelector('.ProductId'));
        }
        if ($('.ProuctName').val() == "") {
            setError(document.querySelector('.ProuctName'));
            e.preventDefault();
        }
        else {
            setTrue(document.querySelector('.ProuctName'));
        }

        if (document.getElementById('preview').src.includes("#") == true) {
            alert("Chưa chọn hình");
            e.preventDefault();
        }


    });
}


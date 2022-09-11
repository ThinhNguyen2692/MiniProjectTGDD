//hàm thay đổi htm thông báo ký nhập sai
    function setError(input) {
        input.classList.add('is-invalid');
        input.classList.remove('is-valid');
    }
    //hàm thay đổi html thông báo nhập mã đúng
    function setTrue(input) {
        input.classList.add('is-valid');
        input.classList.remove('is-invalid');
    }
    // hàm kiểm tra mã thương hiệu
function checkCode(inputVaule) {
    const regex = /^\w{1,25}$/; //ký tự không lên quá 25 ký tự
    return regex.test(inputVaule);
}
// hàm kiểm tra ten thương hiệu
function checkTen(inputVaule) {
    const regex = /^.+$/; // không được bỏ trống
    return regex.test(inputVaule);
}



const formDemo = document.querySelector('#form-brands');
const bransId = document.querySelector('.BrandId');
const bransName = document.querySelector('.BrandName');
const bransImage = document.getElementById('preview');
const fileImage = document.querySelector('.fileImage');



if (formDemo) {

    if (bransId) {
        bransId.addEventListener("keyup", function (e) {
          
            if (!checkCode(bransId.value)) {
                setError(bransId);

            } else {
                setTrue(bransId);
            }
        })
    }
    if (bransName) {
        bransName.addEventListener("keyup", function (e) {
            if (bransName.value == "") {
                setError(bransName);

            } else {

                setTrue(bransName);
            }
        })
    }
    
    formDemo.addEventListener("submit", function (e) {
        if (bransName.value == "") {
            setError(bransName);
            e.preventDefault();
        } else {
            console.log(bransName.value);
            setTrue(bransName);
        }
        if (!checkCode(bransId.value)) {
            setError(bransId);
            e.preventDefault();
        } else {
            setTrue(bransId);
        }
        if (bransImage.src.includes("#") == true) {
            alert("Chưa chọn hình");
            e.preventDefault();
        }
      
        
    });
}



////form nhập thông tin ngành hàng (3 form)
const formAddType = document.querySelector('#form-add-type');
const TypeId = document.querySelector('.TypeId');
const TypeName = document.querySelector('.TypeName');

if (formAddType) {

    if (TypeName) {
        TypeName.addEventListener("keyup", function (e) {
            if (TypeName.value == "") {
                setError(TypeName);

            } else {

                setTrue(TypeName);
            }
        })
    }

    formAddType.addEventListener("submit", function (e) {
        if (TypeName.value == "") {
            setError(TypeName);
            e.preventDefault();
        } else {
            setTrue(bransName);
        }
        if (!checkCode(TypeId.value)) {
            setError(TypeId);
            e.preventDefault();
        } else {
            setTrue(bransId);
        }
    });
}


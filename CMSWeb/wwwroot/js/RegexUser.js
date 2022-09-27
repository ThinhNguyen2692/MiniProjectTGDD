const UserPhone = document.querySelector(".UserPhone");
const FormUser = document.querySelector('#form-User');


    FormUser.addEventListener("submit", function (e) {

        console.log(UserPhone.value)
        if (!checkPhone(UserPhone.value)) {
            setError(UserPhone);
            e.preventDefault();
        } else {
            setTrue(UserPhone);
        }
       
       

    })

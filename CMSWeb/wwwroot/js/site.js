

$(".showProduct").click(function () {
    if ($('#show').hasClass("show")) {
        $('#show').removeClass("show");
    } else {
        $('#show').addClass("show");
    }
});

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




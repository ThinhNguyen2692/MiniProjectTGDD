const formAddSpecifitication = document.querySelector('#form-add-Specification');
const SpecificationName = document.querySelector('#SpecificationsName');

formAddSpecifitication.addEventListener("submit", function (e) {
    if (SpecificationName.value == "") {
        setError(SpecificationName);
        e.preventDefault();
    } else {
        setTrue(bransId);
    }
});
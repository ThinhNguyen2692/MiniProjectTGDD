const formAddSpecifitication = document.querySelector('#form-add-Specification');
const SpecificationName = document.querySelector('.SpecificationName');

formAddSpecifitication.addEventListener("submit", function (e) {

    if (SpecificationName) {
        SpecificationName.addEventListener("keyup", function (e) {
            if (SpecificationName.value == "") {
                setError(SpecificationName);

            } else {

                setTrue(SpecificationName);
            }
        })
    }

    if (SpecificationName.value == "") {
        setError(SpecificationName);
        e.preventDefault();
    } else {
        setTrue(bransId);
    }
});
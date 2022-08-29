fileImage.onchange = evt => {

    const [file] = fileImage.files

    if (file) {

        preview.src = URL.createObjectURL(file);

        $("#preview").removeClass("hidden");

    }

}
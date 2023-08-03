$(function () {
    let bases64;
    
    $("#UploadFileDtos_File").change(function () {
        var fileName = $(this)[0].files[0].name;
        var extension = fileName.substr(fileName.length - 4);
        let i = 2;
        if (extension == ".png") {
            let base64 = "";
            var reader = new FileReader();
            reader.readAsDataURL($(this)[0].files[0]);
            reader.onload = function () {
                $("#productInput_image").val(reader.result);
            };
            
            i = 0;
        }
        if (i != 0) {
            if (extension == ".jpg") {
                i = 0;
                let base64 = "";
                var reader = new FileReader();
                reader.readAsDataURL($(this)[0].files[0]);
                reader.onload = function () {
                    base64 = reader.result;
                };
                $("#productInput_image").val(base64);
                $("#productInput_image").text(base64);
                console.log($("#productInput_image").val());
            }
        }
        if (i != 0) {
            if (extension == "jpeg") {
                i = 0;
                let base64 = "";
                var reader = new FileReader();
                reader.readAsDataURL($(this)[0].files[0]);
                reader.onload = function () {
                    base64 = reader.result;
                };
                $("#productInput_image").val(base64);
                $("#productInput_image").text(base64);
                console.log($("#productInput_image").val());
            }
        }
        if (i == 2) {
            console.log("Hata");
            Swal.fire({
                title: "HATA",
                text: "Lutfen Resim Dosyasi Seciniz!",
                icon: "error",  //"warning", "error", "success" and "info".
                timer: 9000,
                button: {
                    text: "Tamam", //Buton yazýsý
                    value: true,
                    visible: true, //Görünsün mü? true, false
                    className: "", //class deðiþtirmek istersen
                    closeModal: true, //Modal kapatýlsýn mý, true, false
                },
                showCancelButton: false,
                showConfirmButton: false
            }).then(function () {
                $("#UploadFileDtos_File").val("");
            });
        }
        else {
            $("#UploadFileDtos_Name").val(fileName);
        }

    });

    function getBase64(file) {
        var reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = function () {
            console.log(reader.result);
        };
        reader.onerror = function (error) {
            console.log('Error: ', error);
        };
    }

   
});
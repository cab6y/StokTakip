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


/*
Please try with devices with camera!
*/

/*
Reference: 
https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getUserMedia
https://developers.google.com/web/updates/2015/07/mediastream-deprecations?hl=en#stop-ended-and-active
https://developer.mozilla.org/en-US/docs/Web/API/WebRTC_API/Taking_still_photos
*/

// reference to the current media stream
var mediaStream = null;

// Prefer camera resolution nearest to 1280x720.
var constraints = {
    audio: false,
    video: {
        width: { ideal: 640 },
        height: { ideal: 480 },
        facingMode: "environment"
    }
};

async function getMediaStream(constraints) {
    try {
        mediaStream = await navigator.mediaDevices.getUserMedia(constraints);
        let video = document.getElementById('cam');
        video.srcObject = mediaStream;
        video.onloadedmetadata = (event) => {
            video.play();
        };
    } catch (err) {
        console.error(err.message);
    }
};

async function switchCamera(cameraMode) {
    try {
        // stop the current video stream
        if (mediaStream != null && mediaStream.active) {
            var tracks = mediaStream.getVideoTracks();
            tracks.forEach(track => {
                track.stop();
            })
        }

        // set the video source to null
        document.getElementById('cam').srcObject = null;

        // change "facingMode"
        constraints.video.facingMode = cameraMode;

        // get new media stream
        await getMediaStream(constraints);
    } catch (err) {
        console.error(err.message);
        alert(err.message);
    }
}

function takePicture() {
    let canvas = document.getElementById('canvas');
    let video = document.getElementById('cam');
    let photo = document.getElementById('photo');
    let context = canvas.getContext('2d');

    const height = video.videoHeight;
    const width = video.videoWidth;

    if (width && height) {
        canvas.width = width;
        canvas.height = height;
        context.drawImage(video, 0, 0, width, height);
        var data = canvas.toDataURL('image/png');
        photo.setAttribute('src', data);
        document.getElementById('productInput_image').value = data;
    } else {
        clearphoto();
    }
}

function clearPhoto() {
    let canvas = document.getElementById('canvas');
    let photo = document.getElementById('photo');
    let context = canvas.getContext('2d');

    context.fillStyle = "#AAA";
    context.fillRect(0, 0, canvas.width, canvas.height);
    var data = canvas.toDataURL('image/png');
    photo.setAttribute('src', data);
}

document.getElementById('switchFrontBtn').onclick = (event) => {
    switchCamera("user");
}

document.getElementById('switchBackBtn').onclick = (event) => {
    switchCamera("environment");
}

document.getElementById('snapBtn').onclick = (event) => {
    takePicture();
    event.preventDefault();
}

clearPhoto();
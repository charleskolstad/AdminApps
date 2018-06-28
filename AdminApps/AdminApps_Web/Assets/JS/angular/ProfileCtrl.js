angular.module("Admin").controller("ProfileCtrl", function ($http, $scope, dataUrl) {

    $scope.ProfileImage = function (element) {
        document.getElementById("ProfileCancel").classList.remove('cancel-image');

        let reader = new FileReader();
        reader.onload = function (event) {
            image.setAttribute('crossOrigin', 'anonymous');
            image.src = event.target.result;
            setupCanvas("ProfileCanvas");
            image.onload = onImageLoad.bind(this);
        }
        reader.readAsDataURL(element.files[0]);

        document.getElementById("ProfileSlider").oninput = updateScale.bind(this);
    }

    $scope.cancelFile = function () {
        document.getElementById("ProfileFile").value = "";
        ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
        document.getElementById("ProfileCancel").classList.add('cancel-image');
    }
});
console.log('💩💩💩💩💩💩')


window.imageErrorCheck = {
    checkImage: function (imageUrl) {
        return new Promise((resolve, reject) => {
            var img = new Image();
            img.onload = function () {
                resolve(true); // Image loaded successfully
            };
            img.onerror = function () {
                resolve(false); // Image failed to load
                console.log('failed to load image')
            };
            img.src = imageUrl;
            if (img.complete) {
                resolve(true); // Image is already loaded
            }
        });
    }
};
console.log('💩💩💩💩💩💩')


window.imageErrorCheck = {
    checkImage: function (imageUrl, callback) {
        var img = new Image();
        img.onload = function () {
            callback(true); // Image loaded successfully
            console.log(' loaded ');

        };
        img.onerror = function () {
            callback(false); // Image failed to load
            console.log(' not loaded');

        };
        img.src = imageUrl;
    }
};
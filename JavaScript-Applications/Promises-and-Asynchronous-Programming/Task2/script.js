let promise = new Promise((resolve, reject) => {
    showMessage();
    setTimeout(function (resolve) {
        window.location = "http://google.com";
    }, 2000);
});

function showMessage() {
    window.confirm("You will be redirected to Google!");
}
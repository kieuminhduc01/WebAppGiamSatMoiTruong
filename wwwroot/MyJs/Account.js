function checkSignin() {
    var username_str = document.getElementById("username").value;
    var password_str = document.getElementById("password").value;
    $.ajax({
        url: "Accounts/isSignIn",
        type: "POST",

        data: {
            username: username_str,
            password: password_str
        },
        success: function (response) {
            if (response) {
                window.location.href = "Home/Index";
            } else if (!response) {
                document.getElementById("errorLogin").innerText = "Wrong Username or Password !";
            } else {
                alert(response);
            }

        },
        error: function (response) {
            alert(response);
        }
    });
}
var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

$(function () {
    $("#contactForm").validate(
        {
            rules:
            {

                email:
                {
                    required: true,
                    email: true
                },
                password:
                {
                    required: true,
                    minlength: 5
                }
            },
            messages:
            {

                email:
                {
                    required: "Email cannot be empty"
                },
                password:
                {
                    required: "Please provide a password",
                    minlength: "Your password must be at least 5 characters long"
                }
            }
        });

});
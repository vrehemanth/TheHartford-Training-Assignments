const form = document.getElementById("form");

form.addEventListener("submit", function(e){
    e.preventDefault();

    document.querySelectorAll(".error").forEach(el => el.innerText = "");
    document.getElementById("successMsg").innerText = "";

    let valid=true;
    const name=document.getElementById("name").value.trim();
    const email=document.getElementById("email").value.trim();
    const mobile=document.getElementById("mobile").value.trim();
    const request=document.getElementById("requestType").value;
    const policy=document.getElementById("policyType").value;
    const message=document.getElementById("message").value.trim();
    const rating=document.querySelector('input[name="rating"]:checked');

    // Name validation
    if(name===""){
        document.getElementById("nameError").innerText = "Name is required";
        valid = false;
    }

    // Email validation
    if(email===""){
        document.getElementById("emailError").innerText = "Email is required";
        valid = false;
    }

    // Mobile validation
    if(!/^\d{10}$/.test(mobile)){
        document.getElementById("mobileError").innerText = "Enter valid 10 digit mobile number";
        valid = false;
    }

    // Request type validation
    if(request===""){
        document.getElementById("requestError").innerText = "Select request type";
        valid = false;
    }

    // Policy type validation
    if(policy===""){
        document.getElementById("policyError").innerText="Select policy type";
        valid = false;
    }

    // Message validation
    if(message.length<10){
        document.getElementById("messageError").innerText = "Minimum 10 characters required";
        valid = false;
    }

    // Rating validation
    if(!rating){
        document.getElementById("ratingError").innerText = "Select rating";
        valid = false;
    }

    // If all validations pass
    if(valid){
        document.getElementById("successMsg").innerText="Thank you! Your enquiry has been successfully submitted.";
        form.reset();
    }
});
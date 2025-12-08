// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
  function loadUsers() {
    fetch("/Users?handler=List")
      .then(response => response.json())
      .then(data => {
        let html = "<ul>";
        data.forEach(user => {
          html += `<li>Id: ${user.id}, Name: ${user.name}</li>`;
        });
        html += "</ul>";
        document.getElementById("result").innerHTML = html;
      });
  }


document.getElementById("registerForm").addEventListener("submit", function(event) 
{
    if (!checkform(event, this)) 
    {
        event.preventDefault();
    }
});

  //Register user with Regex
function checkform(event, form) {
    var name = document.getElementById("name").value;
    var password = document.getElementById("password").value;
    
    console.warn(name.toString());
    if(!/(?:[A-Za-z] [A-Za-z])/.test(name)) {
        alert("Username must contain spaces");
        return false;
    }
    
    if (password.length <= 7 ||
        !/\w*[A-Z]/g.test(password) ||
        !/\w*[a-z]/g.test(password) ||
        !/\d/.test(password)) {
        alert("Password must be more than 7 characters\nPassword must contain at least one uppercase letter\nPassword must contain at least one lowercase letter\nPassword must contain at least one digit");
        return false;
    }
    alert("You have registered a user")
    return true;
}

// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
  function loadUsers() {
    fetch("/Users?handler=List")
      .then(response => response.json())
      .then(data => {
        let html = "<ul>";
        data.forEach(user => {
          html += `<li>Id: ${user.id}, Name: ${user.name}, Password: ${user.password}</li>`;
        });
        html += "</ul>";
        document.getElementById("result").innerHTML = html;
      });
  }

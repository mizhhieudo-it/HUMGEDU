$(document).ready(function () {
$.ajax({
    url: 'https://localhost:44305/api/KeSach',
    type: 'Get',
}).done(function (reponse, status, data) {
    console.log("oke");
    console.log(data);
}).fail(function (reponse, status, data) {
    console.log(data);
    console.log("not oke");


})
});

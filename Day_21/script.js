function getUser() {

fetch("https://randomuser.me/api/")
.then(response => response.json())
.then(data => {

const user = data.results[0]

const name = user.name.first + " " + user.name.last
const email = user.email
const picture = user.picture.large

document.getElementById("user").innerHTML = `
<h3>${name}</h3>
<p>${email}</p>
<img src="${picture}" width="150">
`

})
.catch(error => console.log(error))

}
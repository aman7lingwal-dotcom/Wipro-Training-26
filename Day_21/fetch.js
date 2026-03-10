fetch("https://dummy.restapiexample.com/api/v1/employees")
.then(response => response.json())
.then(data => {

console.log("Employee Data:")
console.log(data)

})
.catch(error => console.log("Error:", error))
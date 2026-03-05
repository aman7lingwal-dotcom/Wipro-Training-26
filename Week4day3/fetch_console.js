const apiUrl = "https://dummy.restapiexample.com/api/v1/employees";

fetch(apiUrl)
  .then(response => {
    if (!response.ok) {
      throw new Error("Network response was not ok " + response.status);
    }
    return response.json();
  })
  .then(data => {
    console.log("Employees data:", data);
  })
  .catch(error => {
    console.error("Fetch error:", error);
  });
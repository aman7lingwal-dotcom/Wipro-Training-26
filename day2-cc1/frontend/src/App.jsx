import { useEffect, useState } from "react";
import UserList from "./Userlist";
import UserForm from "./Userform";

function App() {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5001/users")
      .then((res) => res.json())
      .then((data) => setUsers(data));
  }, []);

  const handleUserAdded = (newUser) => {
    setUsers([...users, newUser]);
  };

  return (
    <div style={{ padding: "20px" }}>
      <h1>User Management System</h1>

      <UserForm onUserAdded={handleUserAdded} />

      <UserList users={users} />
    </div>
  );
}

export default App;
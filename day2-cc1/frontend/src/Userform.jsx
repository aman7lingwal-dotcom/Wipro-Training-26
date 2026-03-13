import { useState } from "react";

function UserForm({ onUserAdded }) {
  const [name, setName] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!name.trim()) return;

    const response = await fetch("http://localhost:5001/users", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ name }),
    });

    if (response.ok) {
      const newUser = await response.json();
      onUserAdded(newUser);
      setName("");
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Add User</h2>

      <input
        type="text"
        placeholder="Enter name"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />

      <button type="submit">Add User</button>
    </form>
  );
}

export default UserForm;
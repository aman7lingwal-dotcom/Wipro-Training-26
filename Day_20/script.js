// Select elements
const form = document.querySelector('#todo-form');
const input = document.querySelector('#todo-input');
const ul = document.querySelector('#todo-list');
const countDisplay = document.querySelector('#count');

// Add Task
form.addEventListener('submit', function(event) {

    event.preventDefault();

    const task = input.value.trim();

    if (task !== '') {

        const li = document.createElement('li');
        li.textContent = task;

        // Create Delete Button
        const deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';

        li.appendChild(deleteBtn);
        ul.appendChild(li);

        input.value = '';

        // Update counter automatically
        countDisplay.textContent = ul.children.length;

        // Delete Task
        deleteBtn.addEventListener('click', function() {
            ul.removeChild(li);

            // Update counter after delete
            countDisplay.textContent = ul.children.length;
        });
    }
});
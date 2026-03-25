"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TaskManager = void 0;
class TaskManager {
    constructor() {
        this.users = [];
        this.tasks = [];
    }
    createUser(name, email) {
        const user = {
            id: this.users.length + 1,
            name,
            email
        };
        this.users.push(user);
        return user;
    }
    createTask(title) {
        const task = {
            id: this.tasks.length + 1,
            title,
            status: "Pending"
        };
        this.tasks.push(task);
        return task;
    }
    assignTask(taskId, userId) {
        const task = this.tasks.find(t => t.id === taskId);
        if (task) {
            task.assignedTo = userId;
        }
    }
    completeTask(taskId) {
        const task = this.tasks.find(t => t.id === taskId);
        if (task) {
            task.status = "Completed";
        }
    }
    getTasks() {
        return this.tasks;
    }
}
exports.TaskManager = TaskManager;
//# sourceMappingURL=TaskManger.js.map
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.handleCommand = handleCommand;
const TaskManger_1 = require("../services/TaskManger");
const manager = new TaskManger_1.TaskManager();
function handleCommand(args) {
    const command = args[2];
    switch (command) {
        case "create-user":
            const name = args[3];
            const email = args[4];
            manager.createUser(name, email);
            console.log(`User created: ${name}`);
            break;
        case "create-task":
            const title = args[3];
            manager.createTask(title);
            console.log(`Task created: ${title}`);
            break;
        case "list-tasks":
            console.log(manager.getTasks());
            break;
        case "complete-task":
            const id = Number(args[3]);
            manager.completeTask(id);
            console.log("Task completed");
            break;
        default:
            console.log("Unknown command");
    }
}
//# sourceMappingURL=command.js.map
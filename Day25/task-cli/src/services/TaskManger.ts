import { IUser } from "../models/IUser"
import { ITask } from "../models/ITask"

export class TaskManager {

  private users: IUser[] = []
  private tasks: ITask[] = []

  createUser(name: string, email: string) {

    const user: IUser = {
      id: this.users.length + 1,
      name,
      email
    }

    this.users.push(user)
    return user
  }

  createTask(title: string) {

    const task: ITask = {
      id: this.tasks.length + 1,
      title,
      status: "Pending"
    }

    this.tasks.push(task)
    return task
  }

  assignTask(taskId: number, userId: number) {

    const task = this.tasks.find(t => t.id === taskId)

    if (task) {
      task.assignedTo = userId
    }
  }

  completeTask(taskId: number) {

    const task = this.tasks.find(t => t.id === taskId)

    if (task) {
      task.status = "Completed"
    }
  }

  getTasks() {
    return this.tasks
  }

}
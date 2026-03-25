export type TaskStatus = "Pending" | "Completed"

export interface ITask {
  id: number
  title: string
  status: TaskStatus
  assignedTo?: number
}